using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models.Car;

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
    // public bool IsFitForUse { get; set; } — NINA BABINETS.

    // FIELDS

    private const string _invalidCar = "NO INFO";
    internal readonly int Year;

    // PROPERTIES

    public AbstractEngine Engine { get; set; }
    public AbstractInterior Interior { get; set; }
    public AbstractWheels Wheels { get; set; }
    public AbstractTransmission Transmission { get; set; }
    public KnownColor Color { get; set; }
    public int Price { get; set; }

    internal required string SerialNumber { get; init; }
    internal string Model { get; init; }
    internal string Brand { get; init; }
    internal TransportStatus Status { get; set; }
    public bool IsFitForUse { get; set; }

    // CONSTRUCTORS

    public Car()
    {
        Year = 0;
        SerialNumber = _invalidCar;
        Model = _invalidCar;
        Brand = _invalidCar;
    }

    public Car(int year, string serialNumber, string model, string brand)
    {
        Year = year;
        SerialNumber = serialNumber;
        Model = model;
        Brand = brand;
    }

    // METHODS


}
