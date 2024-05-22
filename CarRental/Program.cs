using CarRental.Models;

class CarRentalPortal
{
    static void Main(string[] args)
    {
        // Starting point. Show menu, etc.
        var login = new Login();
        login.StartLogin();
    }
}
