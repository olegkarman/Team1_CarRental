using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;

namespace CarRental.Data.Models;
public class Customer : User
{
    public const float BasicDiscount = 0.5f;    // CONST-S SHOULD BE ON TOP.
    public List<Deal> Deals { get; set; }
    public List<Car>? Cars { get; set; }
    public string PassportNumber { get; init; }
    public required string DrivingLicenseNumber { get; set; }

    [SetsRequiredMembers]
    public Customer(string? firstName, string? lastName, string passportNumber, string drivingLicenseNumber, DateTime dateOfBirth, string password, string userName) : base(firstName, lastName, dateOfBirth, password, userName)
    {
        PassportNumber = passportNumber;
        DrivingLicenseNumber = drivingLicenseNumber;
        Deals = new List<Deal>();

        // ADDED THIS PROPERTIES (YPARKHOMENKO).
        Cars = new List<Car>();
    }

   // BECAUSE THERE IS NO ANY SHOW-INFORMATION METHOD IN THE CUSTOMER MANAGER.
   public override string ToString()
   {
        return $"{{ {nameof(FirstName)} = {this.FirstName} | {nameof(LastName)} = {this.LastName} | {nameof(DateOfBirth)} = {this.DateOfBirth} | {nameof(UserName)} = {this.UserName} | {nameof(IdNumber)} = {this.IdNumber} | }}";
   }
}
