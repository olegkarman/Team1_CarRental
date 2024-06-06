using System.Diagnostics.CodeAnalysis;
using CarRental.Models;

namespace CarRental.Models;
public class Customer : User
{
    public List<Deal> Deals { get; set; }
    public const float BasicDiscount = 0.5f;
    public string PassportNumber { get; init; }
    public required string DrivingLicenseNumber { get; set; }

    [SetsRequiredMembers]
    public Customer(string? firstName, string? lastName, string passportNumber, string drivingLicenseNumber, DateTime dateOfBirth, string password, string userName) : base(firstName, lastName, dateOfBirth, password, userName)
    {
        PassportNumber = passportNumber;
        DrivingLicenseNumber = drivingLicenseNumber;
        Deals = new List<Deal>();
    }

    public void BuyCar(Car.Car car)
    {
        var newDeal = new Deal(PassportNumber, car.VinCode, "purchase", car.Price);
        Deals.Add(newDeal);
        car.Status = Enumerables.TransportStatus.sold;
    }

    public void RentCar(Car.Car car)
    {
        var newDeal = new Deal(PassportNumber, car.VinCode, "rental", car.Price);
        Deals.Add(newDeal);
        car.Status = Enumerables.TransportStatus.rented;
    }

    public void ShowMyDeals()
    {
        for (int i = 0; i < Deals.Count; i++)
        {
            Console.WriteLine(Deals[i].ToString());
        }
    }
}
