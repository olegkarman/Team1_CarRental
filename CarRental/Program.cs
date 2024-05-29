using CarRental.Models.ConsoleHelper;
using CarRental.Models.Login;
using CarRental.Models.Portal;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        ConsoleHelper.ApplyConsoleStyles();
        var login = new Login();
        var (user, isCustomer) = login.StartLogin();
        var portal = new Portal(user, isCustomer);
        ConsoleHelper.ClearConsoleWithDelay(2);
        portal.ShowMainMenu();
    }
}
