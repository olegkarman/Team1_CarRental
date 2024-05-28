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

    public readonly string IdNumber;
    public required string DrivingLicenseNumber { get; set; }

    [SetsRequiredMembers]
    public Customer(string? firstName, string? lastName, string idNumber, string drivingLicenseNumber, DateTime dateOfBirth, string password, string userName) : base(firstName, lastName, dateOfBirth, password , userName)
    {
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
