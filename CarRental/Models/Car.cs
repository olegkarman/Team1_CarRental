using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;

internal class Car
{
    //THE COMMENT OF O. KARMANSKYI.
    /*VinCode: string
    SerialNumber: string
    TransmissionType: string
    Model: string
    Brand: string
    Year: int
    Status: string (available, rented, sold, in repair, etc.)
    Methods:
    TakeCarFromParking()
    SendToRepair()
    Refuel()
    RemoveCar()*/

    // FIELDS

    private const string _invalidCar = "Car has no mark";
    internal readonly int Year;

    // PROPERTIES

    internal required string SerialNumber { get; init; }
    internal string Model { get; init; }
    internal string Brand { get; init; }

    // CONSTRUCTORS

    public Car(int year)
    {
        this.Year = year;
    }

    // METHODS


}
