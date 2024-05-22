using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;
internal class Customer
{
    public const float BasicDiscount = 0.5f;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public readonly string IdNumber;
    public required string DrivingLicenseNumber { get; set; }

    [SetsRequiredMembers]
    public Customer(string? firstName, string? lastName, string idNumber, string drivingLicenseNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        IdNumber = idNumber;
        DrivingLicenseNumber = drivingLicenseNumber;
    }




    /*FirstName: string
    LastName: string
    IdNumber: string
    PassportNumber: string
    DrivingLicenseNumber: string
    DateOfBirth: DateTime
    RentalDate: DateTime(if rented)
    PurchaseDate: DateTime(if purchased)
    Gender: string
    Methods:
    RentCar(Car car)
    BuyCar(Car car)
    ReturnCar(Car car)
    PayMoney(double amount)*/
}
