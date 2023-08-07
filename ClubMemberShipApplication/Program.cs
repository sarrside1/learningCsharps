using ClubMemberShipApplication.Views;

namespace ClubMemberShipApplication
{
    class Program
    {
        static void Main(String[] args)
        {
            IView mainView = Factory.GetMainViewObject();
            mainView.RunView();
            Console.ReadKey();
        }
    }
}