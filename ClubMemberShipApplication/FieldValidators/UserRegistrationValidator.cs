using System;
using ClubMemberShipApplication.Data;
using FieldValidationApi;
using static ClubMemberShipApplication.FieldValidators.FieldContants;

namespace ClubMemberShipApplication.FieldValidators
{
	public class UserRegistrationValidator: IFieldValidator
	{
		const int FirstName_Min_Length = 2;
		const int FirstName_Max_Length = 100;
        const int LastName_Min_Length = 2;
        const int LastName_Max_Length = 100;

        delegate bool EmailExistsDel(string emailAddress);

		FieldValidatorDel _fieldValidatorDel = null;
		RequiredValidDel _requiredValidDel = null;
		StringLengthValidDel _stringLenghtValidDel = null;
		DateValidDel _dateValidDel = null;
		PatternMatchValidDel _patternMatchValidDel = null;
		CompareFieldValidDel _compareFieldValidDel = null;
		EmailExistsDel _emailExistDel = null;
		string[] _fieldArray = null;
        IRegister _register;

        public UserRegistrationValidator(IRegister register)
		{
			_register = register;
		}

		public string[] FieldArray
		{
			get
			{
				if (_fieldArray == null)
					_fieldArray = new string[Enum.GetValues(typeof(FieldContants.UserRegistrationField)).Length];
				return _fieldArray;
			}
		}
		public FieldValidatorDel ValidatorDel =>_fieldValidatorDel;


        void IFieldValidator.InitializeValidatorDelegates()
        {
			_fieldValidatorDel = new FieldValidatorDel(ValidField);

			_emailExistDel = new EmailExistsDel(_register.EmailExists);

			_requiredValidDel = CommonFieldValidatorFunction.RequiredFieldValidDel;
			_stringLenghtValidDel = CommonFieldValidatorFunction.StringLengthFieldValidDel;
			_dateValidDel = CommonFieldValidatorFunction.DateFieldValidDel;
			_patternMatchValidDel = CommonFieldValidatorFunction.PatternMatchFieldValidDel;
			_compareFieldValidDel = CommonFieldValidatorFunction.FieldsCompareValidDel;
        }

		private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
		{
			fieldInvalidMessage = "";
			FieldContants.UserRegistrationField userRegistrationField = (FieldContants.UserRegistrationField)fieldIndex;
			switch (userRegistrationField)
			{
				case FieldContants.UserRegistrationField.EmailAddress:
					fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
					fieldInvalidMessage = (fieldInvalidMessage== "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionvalidationPatterns.Email_Address_RegEx_Pattern)) ? $"You must enter a valid email address:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : fieldInvalidMessage;
                    fieldInvalidMessage = (fieldInvalidMessage == "" && _emailExistDel(fieldValue)) ? $"This email address already exist. Please try again{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : fieldInvalidMessage;
                    break;
                case FieldContants.UserRegistrationField.FirstName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLenghtValidDel(fieldValue, FirstName_Min_Length, FirstName_Max_Length)) ? $"The length for field: {Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)} must be between {FirstName_Min_Length} and {FirstName_Max_Length}" : fieldInvalidMessage;
                    break;
                case FieldContants.UserRegistrationField.LastName:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_stringLenghtValidDel(fieldValue, LastName_Min_Length, LastName_Max_Length)) ? $"The length for field: {Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)} must be between {LastName_Min_Length} and {LastName_Max_Length}" : fieldInvalidMessage;
                    break;
                case FieldContants.UserRegistrationField.Password:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionvalidationPatterns.Strong_Password_RegEx_Pattern)) ? $"Your password must contain at least 1 small-case letter, 1 capital letter, 1 special character and the length should be between 6 - 10 characters : {Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : fieldInvalidMessage;
                    break;
                case FieldContants.UserRegistrationField.PasswordCompare:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_compareFieldValidDel(fieldValue, fieldArray[(int)FieldContants.UserRegistrationField.Password])) ? $"Your entry did not match your password {Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : fieldInvalidMessage;
                    break;
                case FieldContants.UserRegistrationField.DateOfBirth:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_dateValidDel(fieldValue, out DateTime validDateTime)) ? $"You did not enter a valid date {Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : fieldInvalidMessage;
                    break;
                case FieldContants.UserRegistrationField.PhoneNumber:
					fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
					fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionvalidationPatterns.SEN_PhoneNumber_RegEx_Pattern)) ? $"You did not enter a valid phone number {Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : fieldInvalidMessage;
					break;
                case FieldContants.UserRegistrationField.AddressFirstLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    break;
                case FieldContants.UserRegistrationField.AddressSecondLine:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    break;
                case FieldContants.UserRegistrationField.AddressCity:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    break;
                case FieldContants.UserRegistrationField.PostCode:
                    fieldInvalidMessage = (!_requiredValidDel(fieldValue)) ? $"You must enter a value for field:{Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : "";
                    fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchValidDel(fieldValue, CommonRegularExpressionvalidationPatterns.SEN_Post_Code_RegEx_Pattern)) ? $"You did not enter a valid post code {Enum.GetName(typeof(FieldContants.UserRegistrationField), userRegistrationField)}" : fieldInvalidMessage;
                    break;
                default:
					throw new ArgumentNullException("This field does not exist");
			}
			return (fieldInvalidMessage == "");
		}
    }
}

