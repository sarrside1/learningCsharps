using System;
using ClubMemberShipApplication.FieldValidators;
using ClubMemberShipApplication.Models;

namespace ClubMemberShipApplication.Data
{
	public class RegisterUser: IRegister
	{
		public RegisterUser()
		{
		}

        public bool EmailExists(string emailAddress)
        {
            bool emailExist = false;
            using(var dbContext = new ClubMemberShipDbContext())
            {
                emailExist = dbContext.Users.Any(u => u.EmailAddress.ToLower().Trim() == emailAddress.ToLower().Trim());
            }
            return emailExist;
        }

        public bool Register(string[] fields)
        {
            using(var dbContext = new ClubMemberShipDbContext())
            {
                User user = new User
                {
                    EmailAddress = fields[(int)FieldContants.UserRegistrationField.EmailAddress],
                    FirstName = fields[(int)FieldContants.UserRegistrationField.FirstName],
                    LastName = fields[(int)FieldContants.UserRegistrationField.LastName],
                    Password = fields[(int)FieldContants.UserRegistrationField.Password],
                    DateOfBirth = DateTime.Parse(fields[(int)FieldContants.UserRegistrationField.DateOfBirth]),
                    PhoneNumber = fields[(int)FieldContants.UserRegistrationField.PhoneNumber],
                    AddressFirstLine = fields[(int)FieldContants.UserRegistrationField.AddressFirstLine],
                    AddressSecondLine = fields[(int)FieldContants.UserRegistrationField.AddressSecondLine],
                    AddressCity = fields[(int)FieldContants.UserRegistrationField.AddressCity],
                    PostCode = fields[(int)FieldContants.UserRegistrationField.PostCode]
                };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}

