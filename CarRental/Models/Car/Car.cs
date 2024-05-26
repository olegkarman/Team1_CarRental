using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;

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
    private float _mileage;   // AVTOPROBIG.

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
        //    Engine = value;
        //    // AFTER EVERY ENGINE SET UPDATE MAX SPEED.
        //    this.SetMaxSpeed();
        //}
    }
    public required AbstractInterior Interior { get; set; }
    public required AbstractWheels Wheels { get; set; }
    public required AbstractTransmission Transmission { get; set; }

    public int SpeedCoeficient { get; init; }   // RE-WORK PLEASE.

    public AbstractLights Lights { get; set; }
    public AbstractSignal Signal { get; set; }
    public KnownColor Color { get; set; }
    public int MaxSpeed { get; set; }    // IT BASE ON CHACTERISTIC OF CAR LIKE ENGINE.
    public int Price { get; set; }
    internal required string VinCode { get; init; }

    public ICanDrive LastDriver { get; set; }

    // THE MAX FUEL CAPACITY AND THE CURRENT FUEL CAPACITY OF A CAR CANNOT BE LESS THAN ZERO.
    internal required int MaxFuelCapacity
    {
        get;
        //{
        //    return MaxFuelCapacity;
        //}

        init;
        //{
        //    if (value < 0)
        //    {
        //        MaxFuelCapacity = 0;
        //    }
        //    else
        //    {
        //        MaxFuelCapacity = value;
        //    }
        //}
    }

    internal float CurrentFuel
    {
        get;
        //{
        //    return CurrentFuel;
        //}

        set;
        //{
        //    if (value < 0)
        //    {
        //        CurrentFuel = 0;
        //    }
        //    // IT CANNOT BE LARGER THAN MAX FUEL.
        //    else if (value >= this.MaxFuelCapacity)
        //    {
        //        CurrentFuel = MaxFuelCapacity;
        //    }
        //    else
        //    {
        //        CurrentFuel = value;
        //    }
        //}
    }

    internal ICarRecordable Record;

    internal string Model { get; init; }
    internal string Brand { get; init; }
    internal TransportStatus Status { get; set; }
    public bool IsFitForUse { get; set; }

    #endregion

    #region CONSTRUCTORS

    // CONSTRUCTORS

    [SetsRequiredMembersAttribute]

    public Car()
    {
        this.Year = 0;
        this.VinCode = _noInfo;
        this.Model = _noInfo;
        this.Brand = _noInfo;
        this.Engine = new CarEngine();
        this.Transmission = new CarTransmission();
        this.Wheels = new CarWheels();
        this.Interior = new CarInterior();
        this.Lights = new CarLights();
        this.Signal = new CarSignal();
        this.Color = 0;
        this.Price = 0;
        this.SpeedCoeficient = 0;
        this._mileage = 0;
        this.MaxFuelCapacity = 0;
        this.CurrentFuel = 0;

    }

    [SetsRequiredMembersAttribute]

    public Car
    (
    int year,
    string serialNumber,
    string brand,
    string model,
    KnownColor color,
    int price,
    int maxFuelCapacity,
    int currentFuel,
    int speedCoeficient,
    TransportStatus status,
    bool isFitForUse,
    AbstractEngine engine,
    AbstractTransmission transmission,
    AbstractInterior interior,
    AbstractWheels wheels,
    AbstractLights lights,
    AbstractSignal signal
    )
    {
        this.Year = year;
        this.VinCode = serialNumber;
        this.Brand = brand;
        this.Model = model;
        this.Color = color;
        this.Price = price;
        this.MaxFuelCapacity = maxFuelCapacity;
        this.CurrentFuel = currentFuel;
        this.SpeedCoeficient = speedCoeficient;
        this.Status = status;
        this.IsFitForUse = isFitForUse;
        this.Engine = engine;
        this.Transmission = transmission;
        this.Interior = interior;
        this.Wheels = wheels;
        this.Lights = lights;
        this.Signal = signal;
    }

    [SetsRequiredMembersAttribute]

    public Car
    (
        // CAR ARGUMENTS.
        int year,
        string serialNumber,
        string brand,
        string model,
        KnownColor color,
        int price,
        int maxFuelCapacity,
        int currentFuel,
        int speedCoeficient,
        TransportStatus status,
        bool isFitForUse,

        // ENGINE ARGUMENTS.
        string serialNumberEngine,
        int averageFuelConsumption,
        FuelEngine fuel,
        TypeEngine typeEngine,
        int powerEngine,
        ComponentStatus statusEngine,

        // TRANSMISSION ARGUMENTS.
        string serialNumberTransmission,
        TypeTransmission typeTransmission,
        int speedCount,
        ComponentStatus statusTransmission,

        // INTERIOR ARGUMENTS.
        KnownColor colorInterior,
        MaterialInterior materialInterior,
        ComponentStatus statusInterior,

        // WHEELS ARGUMENTS.
        MaterialWheel materialWheels,
        int sizeWheels,
        TypeTire tire,
        ComponentStatus statusWheels,

        //LIGHTS ARGUMENTS.
        KnownColor colorLights,
        PowerComponent powerLights,
        ComponentStatus statusLights,

        // SIGNAL ARGUMENTS.
        PitchComponent pitch,
        ComponentStatus statusSignal
    )
    {
        this.Year = year;
        this.VinCode = serialNumber;
        this.Brand = brand;
        this.Model = model;
        this.Color = color;
        this.Price = price;
        this.MaxFuelCapacity = maxFuelCapacity;
        this.CurrentFuel = currentFuel;
        this.SpeedCoeficient = speedCoeficient;
        this.Status = status;
        this.IsFitForUse = isFitForUse;

        this.Engine = new CarEngine
        (
            serialNumberEngine,
            averageFuelConsumption,
            fuel,
            typeEngine,
            powerEngine,
            statusEngine
        );

        this.Transmission = new CarTransmission
        (
            serialNumberTransmission,
            typeTransmission,
            speedCount,
            statusTransmission
        );

        this.Interior = new CarInterior
        (
            colorInterior,
            materialInterior,
            statusInterior
        );

        this.Wheels = new CarWheels
        (
            materialWheels,
            sizeWheels,
            tire,
            statusWheels
        );

        this.Lights = new CarLights
        (
            colorLights,
            powerLights,
            statusLights
        );

        this.Signal = new CarSignal
        (
            pitch,
            statusSignal
        );
    }

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
