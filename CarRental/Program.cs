using CarRental.Models.ConsoleHelper;
using CarRental.Models.Login;
using CarRental.Models.Portal;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        //
        // YPARKHOMENKO, TEST...
        //// Starting point. Show menu, etc.
        //Console.WriteLine("Showing menu");
        //CarRental.Models.Car.WeylandYutaniCarRepairShopPortal.DisplayMenu();
        //

        ConsoleHelper.ApplyConsoleStyles();
        var login = new Login();
        var userInSystem = login.StartLogin();
        var portal = new Portal(userInSystem.UserData, userInSystem.isCusomer);
        ConsoleHelper.ClearConsoleWithDelay(2);
        portal.StartMainMenu();
    }
}
