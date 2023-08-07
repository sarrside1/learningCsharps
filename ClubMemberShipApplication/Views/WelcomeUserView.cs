using System;
using ClubMemberShipApplication.FieldValidators;
using ClubMemberShipApplication.Models;

namespace ClubMemberShipApplication.Views
{
	public class WelcomeUserView: IView
	{
		User _user = null;
		public WelcomeUserView(User user)
		{
            _user = user;
		}

        public IFieldValidator FieldValidator => throw new NotImplementedException();

        public void RunView()
        {
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Hi {_user.FirstName}!! {Environment.NewLine}Welcome to the cycling club");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}

