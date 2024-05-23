using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models.Car;

internal class Car
{

    #region COMMENTARY OF O. KARMANSKYI

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

    // O. KARMANSKYI
    /*
        Car:
        Can be rented by a Customer
        Can be purchased by a Customer
        Can be sent to repair by an Inspector
        Can be inspected by an Inspector
        Can be part of a Deal
        Customer:
        Can rent a Car
        Can purchase a Car
        Can return a rented Car
        Can pay money for a rented or purchased Car
        Can be a party to a Deal
        Inspector:
        Can inspect a Car
        Can record the results of an inspection
        Can remove a Car from the system if it is deemed unfit for use
        Inspection:
        Is performed by an Inspector
        Is associated with a specific Car
        Has a result that indicates whether the Car is fit for use
        Deal:
        Is created between a Company and a Customer
        Involves a specific Car
        Has a type (purchase or rental)
        Has a price*/
        
        #endregion

    // FIELDS

    private const string _noInfo = "NO INFO";
    internal readonly int Year;
    private int _mileage;   // AVTOPROBIG.

    #region PROPERTIES

    // PROPERTIES

    public required AbstractEngine Engine { get; set; }
    public required AbstractInterior Interior { get; set; }
    public required AbstractWheels Wheels { get; set; }
    public required AbstractTransmission Transmission { get; set; }

    public required int SpeedCoeficient { get; set; }   // RE-WORK PLEASE.

    public KnownColor Color { get; set; }
    public int MaxSpeed { get; set; }    // IT BASE ON CHACTERISTIC OF CAR LIKE ENGINE.

    // CANNOT SET THIS FROM THE OUTSIDE.

    public int Price { get; set; }

    internal required string VinCode { get; init; }

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

    internal int CurrentFuel
    {
        get
        {
            return CurrentFuel;
        }

        set
        {
            if (value < 0)
            {
                CurrentFuel = 0;
            }
            // IT CANNOT BE LARGER THAN MAX FUEL.
            else if (value >= this.MaxFuelCapacity)
            {
                CurrentFuel = MaxFuelCapacity;
            }
            else
            {
                CurrentFuel = value;
            }
        }
    }

    internal string Model { get; init; }
    internal string Brand { get; init; }
    internal TransportStatus Status { get; set; }
    public bool IsFitForUse { get; set; }

    #endregion

    // CONSTRUCTORS

    public Car()
    {
        Year = 0;
        VinCode = _noInfo;
        Model = _noInfo;
        Brand = _noInfo;
    }

    public Car(int year, string serialNumber, string model, string brand)
    {
        Year = year;
        VinCode = serialNumber;
        Model = model;
        Brand = brand;
    }

    // METHODS

    public bool LetsDrive(IDriveable driver)
    {
        this.SetMaxSpeed();  // SET MAX SPEED BASED ON ENGINE AND SPEED COEFICIENT.

        // STOP METHOD IF NO FUEL.
        if (CurrentFuel == 0)
        {
            return false;
        }
        else
        {
            driver.Drive(this.MaxSpeed, out int averageSpeed, out int drivingTime);

            // A CAR CANNOT DRIVE WITHOUT REFILLING THE FUEL STOCK.
            if (drivingTime > this.CurrentFuel / this.Engine.AverageFuelConsumption)
            {
                drivingTime = this.CurrentFuel / this.Engine.AverageFuelConsumption;
            }

            // TO INCREASE AVTOPROBIG.
            this._mileage = this._mileage + (averageSpeed * drivingTime);

            return true;
        }
    }

    private void SetMaxSpeed()
    {
        MaxSpeed = this.Engine.Power * this.SpeedCoeficient;
    }
}
