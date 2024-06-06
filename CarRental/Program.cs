using System.Collections;
using CarRental.BussinessLayer.Managers;
using CarRental.Models;
using CarRental.Models.ConsoleHelper;
using CarRental.Models.Login;
using CarRental.Models.Portal;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        int currentYear = 2023;
        var obj = (object)currentYear;
            obj.GetType();

        ArrayList list = new ArrayList();
        list.Add(currentYear);

        var v = (int)list[0];


        //
        // YPARKHOMENKO, TEST...
        //// Starting point. Show menu, etc.
        //Console.WriteLine("Showing menu");
        //CarRental.Models.Car.WeylandYutaniCarRepairShopPortal.DisplayMenu();
        //



        var a = new DealManager();
        var b = a.GetAllDealsJson();
        //Console.WriteLine(b);

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
