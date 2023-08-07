using System;
using ClubMemberShipApplication.Models;

namespace ClubMemberShipApplication.Data
{
	public class LoginUser: ILogin
	{
		public LoginUser()
		{
		}

        public User Login(string emailAddress, string password)
        {
            User user = null;
            using(var dbContext = new ClubMemberShipDbContext())
            {
                user = dbContext.Users.FirstOrDefault(u => u.EmailAddress.Trim().ToLower() == emailAddress.Trim().ToLower() && u.Password.Equals(password));
            }
            return user;
        }
    }
}

