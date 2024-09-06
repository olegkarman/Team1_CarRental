using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.Data.Models;

public class Customer : User
{
    // FIELDS
    
    public const float BasicDiscount = 0.5f;

    // PROPERTIES

    public List<Deal?> Deals { get; set; }
    public List<Car?>? Cars { get; set; }
    public string PassportNumber { get; init; }
    public required string DrivingLicenseNumber { get; set; }

    // CONSTRUCTORS

    public Customer()
    {
        Deals = new List<Deal?>();
        Cars = new List<Car?>();
    }

    [SetsRequiredMembers]
    public Customer(string? firstName, string? lastName, string passportNumber, string drivingLicenseNumber, DateTime dateOfBirth, string password, string userName) : base(firstName, lastName, dateOfBirth, password, userName)
    {
        PassportNumber = passportNumber;
        DrivingLicenseNumber = drivingLicenseNumber;
        Deals = new List<Deal>();

        Cars = new List<Car>();
    }

    // METHODS

   public override string ToString()
   {
        return $"{{ {nameof(FirstName)} = {this.FirstName} | {nameof(LastName)} = {this.LastName} | {nameof(DateOfBirth)} = {this.DateOfBirth} | {nameof(UserName)} = {this.UserName} | {nameof(IdNumber)} = {this.IdNumber} | }}";
   }
}
