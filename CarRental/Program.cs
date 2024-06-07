using CarRental.BussinessLayer.Managers;
using CarRental.Data.Models.Login;
using CarRental.Data.Models.Portal;
using CarRental.Models;

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
        var (user, isCustomer) = login.StartLogin();
        var portal = new Portal(user, isCustomer);
        var portalManager = new PortalManager(portal);
        ConsoleHelper.ClearConsoleWithDelay(2);
        portalManager.StartMainMenu();

    }

    public static class Class1
    {

    }

}
