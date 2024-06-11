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

   
}
