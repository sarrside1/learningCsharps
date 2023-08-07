using System;
using ClubMemberShipApplication.FieldValidators;

namespace ClubMemberShipApplication.Views
{
	public class MainView: IView
	{
        IView _registerView;
        IView _loginView;

        public MainView(IView registerView, IView loginView)
		{
            _registerView = registerView;
            _loginView = loginView;
		}

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();
            Console.WriteLine("Please press 'l' to login or 'r' to Register");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            if(consoleKey == ConsoleKey.R)
            {
                RunUserRegistrationView();
                RunLoginView();
            }
            else if(consoleKey == ConsoleKey.L)
            {
                RunLoginView();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("GoodBye");
                Console.ReadKey();
            }
        }

        private void RunUserRegistrationView()
        {
            _registerView.RunView();
        }

        private void RunLoginView()
        {
            _loginView.RunView();
        }
    }
}

