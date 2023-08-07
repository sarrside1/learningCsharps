using System;
using ClubMemberShipApplication.Data;
using ClubMemberShipApplication.FieldValidators;
using ClubMemberShipApplication.Models;

namespace ClubMemberShipApplication.Views
{
	public class UserLoginView: IView
	{
        ILogin _login = null;

        public UserLoginView(ILogin login)
		{
            _login = login;
		}

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            CommonOutputText.WriteLoginHeading();
            Console.WriteLine("Please enter your email address?");
            string emailAddress = Console.ReadLine();
            Console.WriteLine("Please enter your your password?");
            string password = Console.ReadLine();
            User user = _login.Login(emailAddress, password);
            if(user != null)
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("Invalid Credentials");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}

