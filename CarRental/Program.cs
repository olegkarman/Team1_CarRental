using CarRental.Models.Login;
using CarRental.Models.Portal;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        // Starting point. Show menu, etc.
        var login = new Login();
        var user = login.StartLogin();
        var portal = new Portal();
    }
}
