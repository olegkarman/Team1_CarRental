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
    private int _mileage;   // AVTOPROBIG.

    // PROPERTIES

    public AbstractEngine Engine { get; set; }
    public AbstractInterior Interior { get; set; }
    public AbstractWheels Wheels { get; set; }
    public AbstractTransmission Transmission { get; set; }

    public required int SpeedCoeficient { get; set; }   // RE-WORK PLEASE.

    public KnownColor Color { get; set; }
    public int MaxSpeed { get; set; }    // IT BASE ON CHACTERISTIC OF CAR LIKE ENGINE.

    // CANNOT SET THIS FROM THE OUTSIDE.

    public int Price { get; set; }

    internal required string SerialNumber { get; init; }

    // THE MAX FUEL CAPACITY AND THE CURRENT FUEL CAPACITY OF A CAR CANNOT BE LESS THAN ZERO.
    internal required int MaxFuelCapacity
    {
        get
        {
            return MaxFuelCapacity;
        }

        init
        {
            if (value < 0)
            {
                MaxFuelCapacity = 0;
            }
            else
            {
                MaxFuelCapacity = value;
            }
        }
    }

    internal int CurrentFuelCapacity
    {
        get
        {
            return CurrentFuelCapacity;
        }

        set
        {
            if (value < 0)
            {
                CurrentFuelCapacity = 0;
            }
            else
            {
                CurrentFuelCapacity = value;
            }
        }
    }

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

    private void SetMaxSpeed()
    {
        MaxSpeed = this.Engine.Power * SpeedCoeficient;
    }

    public bool LetsDrive(IDriveable driver)
    {
        SetMaxSpeed();  // SET MAX SPEED BASED ON ENGINE AND SPEED COEFICIENT.
        
        // STOP METHOD IF NO FUEL.
        if (this.CurrentFuelCapacity == 0)
        {
            return false;
        }
        else
        {
            driver.Drive(this.MaxSpeed, out int averageSpeed, out int drivingTime);

            // A CAR CANNOT DRIVE WITHOUT REFILLING THE FUEL STOCK.
            if (drivingTime > CurrentFuelCapacity / this.Engine.AverageFuelConsumption)
            {
                drivingTime = CurrentFuelCapacity / this.Engine.AverageFuelConsumption;
            }

            // TO INCREASE AVTOPROBIG.
            this._mileage = this._mileage + (averageSpeed * drivingTime);

            return true;
        }
    }
}
