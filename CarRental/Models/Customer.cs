using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;
internal class Customer : User
{
    public const float BasicDiscount = 0.5f;
    public string PassportNumber { get; init; }
    public required string DrivingLicenseNumber { get; set; }

    [SetsRequiredMembers]
    public Customer(string? firstName, string? lastName, string passportNumber, string drivingLicenseNumber, DateTime dateOfBirth, string password, string userName) : base(firstName, lastName, dateOfBirth, password , userName)
    {
        PassportNumber = passportNumber;
        DrivingLicenseNumber = drivingLicenseNumber;
    }




    
}
