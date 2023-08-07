using System;
using ClubMemberShipApplication.Data;
using ClubMemberShipApplication.FieldValidators;

namespace ClubMemberShipApplication.Views
{
	public class UserRegistrationView: IView
	{
		IFieldValidator _fieldValidator = null;
		IRegister _register = null;
		public UserRegistrationView(IRegister register, IFieldValidator fieldValidator)
		{
			_fieldValidator = fieldValidator;
			_register = register;
		}

        public IFieldValidator FieldValidator { get => _fieldValidator; }

        public void RunView()
        {
			CommonOutputText.WriteMainHeading();
			CommonOutputText.WriteRegisterHeading();
			_fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.EmailAddress] = GetInputFromUser(FieldContants.UserRegistrationField.EmailAddress, "Please enter your email address");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.FirstName] = GetInputFromUser(FieldContants.UserRegistrationField.FirstName, "Please enter your first name");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.LastName] = GetInputFromUser(FieldContants.UserRegistrationField.LastName, "Please enter your last name");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.DateOfBirth] = GetInputFromUser(FieldContants.UserRegistrationField.DateOfBirth, "Please enter your date of birth");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.Password] = GetInputFromUser(FieldContants.UserRegistrationField.Password, "Please enter your password");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.PasswordCompare] = GetInputFromUser(FieldContants.UserRegistrationField.PasswordCompare, "Please confirm your password");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.AddressFirstLine] = GetInputFromUser(FieldContants.UserRegistrationField.AddressFirstLine, "Please enter your first address line ");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.AddressSecondLine] = GetInputFromUser(FieldContants.UserRegistrationField.AddressSecondLine, "Please enter your second address line");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.AddressCity] = GetInputFromUser(FieldContants.UserRegistrationField.AddressCity, "Please enter your address city");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.PhoneNumber] = GetInputFromUser(FieldContants.UserRegistrationField.PhoneNumber, "Please enter your phone number");
            _fieldValidator.FieldArray[(int)FieldContants.UserRegistrationField.PostCode] = GetInputFromUser(FieldContants.UserRegistrationField.PostCode, "Please enter your code postal");
			RegisterUser();
		}

		private void RegisterUser()
		{
			_register.Register(_fieldValidator.FieldArray);

			CommonOutputFormat.ChangeFontColor(FontTheme.Success);
			Console.WriteLine("You have successfully registered. Please press any key to login");
		}

		private string GetInputFromUser(FieldContants.UserRegistrationField field, string promptText)
		{
			string fieldValue = "";
			do
			{
				Console.WriteLine(promptText);
				fieldValue = Console.ReadLine();
			} while (!FieldValid(field, fieldValue));
			return fieldValue;
		}

		private bool FieldValid(FieldContants.UserRegistrationField field, string fieldValue)
		{
			if(!_fieldValidator.ValidatorDel((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
			{
				CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
				Console.WriteLine(invalidMessage);
				CommonOutputFormat.ChangeFontColor(FontTheme.Default);
				return false;
			}

			return true;
		}
    }
}

