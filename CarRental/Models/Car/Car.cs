using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Enumerables;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

internal class Car : Interfaces.ICar
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
    internal readonly int year;
    private float _mileage;   // AVTOPROBIG.
    private float _currentFuel;
    private int _maxFuelCapacity;

    #region PROPERTIES

    // PROPERTIES

    public required AbstractEngine Engine
    {
        get;
        //{
        //    return Engine;
        //}

        set;
        //{
        //    _current = value;
        //    // AFTER EVERY ENGINE SET UPDATE MAX SPEED.
        //    this.SetMaxSpeed();
        //}
    }
    public required AbstractInterior Interior { get; set; }
    public required AbstractWheels Wheels { get; set; }
    public required AbstractTransmission Transmission { get; set; }

    public required ICarRecordable Record { get; set; }

    public int SpeedCoeficient { get; init; }   // RE-WORK PLEASE.

    public AbstractLights Lights { get; set; }
    public AbstractSignal Signal { get; set; }
    public KnownColor Color { get; set; }
    public int MaxSpeed { get; private set; }    // IT BASE ON CHACTERISTIC OF CAR LIKE ENGINE.
    public int Price { get; set; }
    internal required string VinCode { get; init; }

    public ICanDrive LastDriver { get; set; }

    internal int Year
    {
        get
        {
            return year;
        }

        // init-only SETTER FOR READONLY VALUE.
        init
        {
            year = value;
        }
    }

    internal required float Mileage
    {
        get
        {
            return _mileage;
        }

        set
        {
            _mileage = value;
        }
    }

    // THE MAX FUEL CAPACITY AND THE CURRENT FUEL CAPACITY OF A CAR CANNOT BE LESS THAN ZERO.
    internal required int MaxFuelCapacity
    {
        get
        {
            return _maxFuelCapacity;
        }

        init
        {
            if (value < 0)
            {
                _maxFuelCapacity = 0;
            }
            else
            {
                _maxFuelCapacity = value;
            }
        }
    }

    // A SMALL AUTO-VALIDATION.
    internal float CurrentFuel
    {
        get
        {
            return _currentFuel;
        }

        set
        {
            if (value < 0)
            {
                _currentFuel = _currentFuel - value;

                // IT CANNOT BE LESS THAN ZERO.
                if (_currentFuel < 0)
                {
                    _currentFuel = 0;
                }
            }

            // IT CANNOT BE LARGER THAN THE MAX FUEL.
            else if (value >= this.MaxFuelCapacity)
            {
                _currentFuel = _maxFuelCapacity;
            }
            else
            {
                _currentFuel = value;
            }
        }
    }

    internal string Model { get; init; }
    internal string Brand { get; init; }
    internal TransportStatus Status { get; set; }
    public bool IsFitForUse { get; set; }

    #endregion

    #region CONSTRUCTORS

    // CONSTRUCTORS

    //public Car
    //(
    //    int year,
    //    string serialNumber,
    //    string brand,
    //    string model,
    //    int maxFuelCapacity
    //)
    //{
    //    this.Year = year;
    //    this.VinCode = serialNumber;
    //    this.Brand = brand;
    //    this.Model = model;
    //    this._maxFuelCapacity = maxFuelCapacity;
    //}

    #endregion

    #region METHODS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Brand)} = {Brand} | {nameof(this.Model)} = {Model} | {nameof(this.Engine)} = {Engine} | {nameof(this.Transmission)} = {Transmission} | {nameof(this.Wheels)} = {Wheels} | {nameof(this.Interior)} = {Interior} | {nameof(this.Color)} = {Color} | {nameof(this.VinCode)} = {VinCode} | {nameof(this.Price)} = {Price} | {nameof(this.IsFitForUse)} = {IsFitForUse} | {nameof(this.Status)} = {Status} }}";
    }

    public bool Drive(ICanDrive driver, float averageSpeed, int drivingTime)
    {
        this.LastDriver = driver;

        // STOP METHOD IF NO FUEL.
        if ((this.CurrentFuel == 0) || (drivingTime <= 0))
        {
            return false;
        }
        else if (this.CurrentFuel < (this.Engine.AverageFuelConsumption * averageSpeed * drivingTime))
        {
            return false;
        }
        else
        {
            // TO INCREASE AVTOPROBIG AND DECREASE FUEL LEVEL.
            this._mileage = this._mileage + (averageSpeed * drivingTime);
            this.CurrentFuel = this.CurrentFuel - (this.Engine.AverageFuelConsumption * averageSpeed * drivingTime);

            return true;
        }
    }

    private void SetMaxSpeed()
    {
        MaxSpeed = this.Engine.Power * this.SpeedCoeficient;
    }

    #endregion
}
