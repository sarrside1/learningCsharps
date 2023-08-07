using System;
using System.Text.RegularExpressions;

namespace FieldValidationApi
{
	public delegate bool RequiredValidDel(String field);
    public delegate bool StringLengthValidDel(String field, int min, int max);
    public delegate bool DateValidDel(String field, out DateTime dateTime);
    public delegate bool PatternMatchValidDel(String field, string pattern);
    public delegate bool CompareFieldValidDel(String field, string fieldValCompare);

    public class CommonFieldValidatorFunction
	{
		private static RequiredValidDel _requiredValidDel = null;
        private static StringLengthValidDel _stringLengthValidDel = null;
        private static DateValidDel _dateValidDel = null;
        private static PatternMatchValidDel _patternMatchValidDel = null;
        private static CompareFieldValidDel _compareFieldValidDel = null;

        public static RequiredValidDel RequiredFieldValidDel
        {
            get
            {
                if (_requiredValidDel == null)
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                return _requiredValidDel;
            }
        }
        public static StringLengthValidDel StringLengthFieldValidDel
        {
            get
            {
                if (_stringLengthValidDel == null)
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);
                return _stringLengthValidDel;
            }
        }
        public static DateValidDel DateFieldValidDel
        {
            get
            {
                if (_dateValidDel == null)
                    _dateValidDel = new DateValidDel(DateFieldValid);
                return _dateValidDel;
            }
        }
        public static PatternMatchValidDel PatternMatchFieldValidDel
        {
            get
            {
                if (_patternMatchValidDel == null)
                    _patternMatchValidDel = new PatternMatchValidDel(FieldPatternValid);
                return _patternMatchValidDel;
            }
        }

        public static CompareFieldValidDel FieldsCompareValidDel
        {
            get
            {
                if (_compareFieldValidDel == null)
                    _compareFieldValidDel = new CompareFieldValidDel(FieldComparisonValid);
                return _compareFieldValidDel;
            }
        }
        private static bool RequiredFieldValid(string fieldValue)
        {
            if (!string.IsNullOrEmpty(fieldValue))
                return true;
            return false;
        }

        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
                return true;
            return false;
        }
        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
                return true;
            return false;
        }
        private static bool FieldPatternValid(string fieldValue, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            if (regex.IsMatch(fieldValue))
                return true;
            return false;
        }
        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2))
                return true;
            return false;
        }
    }
}

