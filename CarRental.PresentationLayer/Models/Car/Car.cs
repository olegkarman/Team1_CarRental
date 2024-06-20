using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Enums;

namespace CarRental.Data.Models.Car;

public class Car
{
    // THE PURPOSE OF THE CLASS:
    // // A MAIN TYPE CLASS THAT DEFINES THE BEHAVIOR OF A CAR ABSTRACTION.

    // FIELDS

    private const string _noInfo = "NO INFORMATION";
    public readonly int year;
    private float? _mileage;   // AVTOPROBIG.
    private float? _currentFuel;
    private int? _maxFuelCapacity;

    // PROPERTIES

    public string? Engine { get; set; }

    public required Guid CarId { get; init; }

    public string? Interior { get; set; }
    public string? Wheels { get; set; }
    public string? Transmission { get; set; }

    public string? Lights { get; set; }
    public string? Signal { get; set; }
    public KnownColor? Color { get; set; }
    public int? MaxSpeed { get; private set; }
    public required int Price { get; set; }
    public required string VinCode { get; init; }

    public float? Mileage
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

    public int? MaxFuelCapacity
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

    public float? CurrentFuel
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

    public required string Model { get; init; }
    public required string Brand { get; init; }
    public required string NumberPlate { get; set; }
    public TransportStatus? Status { get; set; }
    public bool? IsFitForUse { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Brand)} = {Brand} | {nameof(this.Model)} = {Model} | {nameof(this.Engine)} = {Engine} | {nameof(this.Transmission)} = {Transmission} | {nameof(this.Wheels)} = {Wheels} | {nameof(this.Interior)} = {Interior} | {nameof(this.Color)} = {Color} | {nameof(this.VinCode)} = {VinCode} | {nameof(this.Price)} = {Price} | {nameof(this.IsFitForUse)} = {IsFitForUse} | {nameof(this.Status)} = {Status} | {nameof(CarId)} = {CarId} }}";
    }
}