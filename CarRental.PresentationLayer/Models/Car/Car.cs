using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;
using CarRental.Data.Models.Car.Abstractions;

namespace CarRental.Data.Models.Car;

public class Car : ICar
{
    // THE PURPOSE OF THE CLASS:
    // // A MAIN TYPE CLASS THAT DEFINES THE BEHAVIOR OF A CAR ABSTRACTION.

    // FIELDS

    private const string _noInfo = "NO INFO";
    public readonly int year;
    private float _mileage;   // AVTOPROBIG.
    private float _currentFuel;
    private int _maxFuelCapacity;

    // PROPERTIES

    public required AbstractEngine Engine
    {
        get;
        set;
    }

    public Guid CarId { get; init; }

    public required AbstractInterior Interior { get; set; }
    public required AbstractWheels Wheels { get; set; }
    public required AbstractTransmission Transmission { get; set; }

    public IDossierable Dossier { get; set; }

    public int SpeedCoeficient { get; init; }   // RE-WORK PLEASE.

    public AbstractLights Lights { get; set; }
    public AbstractSignal Signal { get; set; }
    public KnownColor Color { get; set; }
    public int MaxSpeed { get; private set; }    // IT BASE ON CHACTERISTIC OF CAR LIKE ENGINE.
    public int Price { get; set; }
    public required string VinCode { get; init; }

    public int Year
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

    public required float Mileage
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
    public required int MaxFuelCapacity
    {
        get
        {
            return _maxFuelCapacity;
        }

        init
        {
            _maxFuelCapacity = value;
        }
    }

    // A SMALL AUTO-VALIDATION.
    public float CurrentFuel
    {
        get
        {
            return _currentFuel;
        }

        set
        {
            _currentFuel = value;
        }
    }

    public string Model { get; init; }
    public string Brand { get; init; }
    public TransportStatus Status { get; set; }
    public List<Inspection.Inspection> Inspections { get; set; }
    public Deal Deal { get; set; }
    public bool IsFitForUse { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Brand)} = {Brand} | {nameof(this.Model)} = {Model} | {nameof(this.Engine)} = {Engine} | {nameof(this.Transmission)} = {Transmission} | {nameof(this.Wheels)} = {Wheels} | {nameof(this.Interior)} = {Interior} | {nameof(this.Color)} = {Color} | {nameof(this.VinCode)} = {VinCode} | {nameof(this.Price)} = {Price} | {nameof(this.IsFitForUse)} = {IsFitForUse} | {nameof(this.Status)} = {Status} | {nameof(CarId)} = {CarId} }}";
    }

    private void SetMaxSpeed()
    {
        MaxSpeed = this.Engine.Power * this.SpeedCoeficient;
    }
}
