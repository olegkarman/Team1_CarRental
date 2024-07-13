using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Models.Checkup;
using CarRental.Data.Enums;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.Data.Models.Automobile;

public class Car
{
    // THE PURPOSE OF THE CLASS:
    // // A MAIN TYPE CLASS THAT DEFINES THE BEHAVIOR OF A CAR ABSTRACTION.

    // FIELDS

    private const string _noInfo = "NO INFORMATION";
    //private readonly int? _year;
    private float? _mileage;   // AVTOPROBIG.
    private float? _currentFuel;
    private int? _maxFuelCapacity;

    // PROPERTIES

    public required Guid CarId { get; init; }
    public required string VinCode { get; init; }
    public required string Model { get; init; }
    public required string Brand { get; init; }
    public required string NumberPlate { get; set; }
    public required int Price { get; set; }

    public string? Engine { get; set; }
    public string? Transmission { get; set; }
    public string? Interior { get; set; }
    public string? Wheels { get; set; }
    public string? Lights { get; set; }
    public string? Signal { get; set; }
    public KnownColor? Color { get; set; }
    public int? NumberOfSeats { get; set; }
    public int? NumberOfDoors { get; set; }

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

        set
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

    public int? Year { get; init; }

    public TransportStatus? Status { get; set; }
    public bool? IsFitForUse { get; set; }

    public Deal? Engagement { get; set; }
    public List<Inspection>? Inspections { get; set; }
    public List<Repair>? Repairs { get; set; }
    public Customer? Owner { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Brand)} = {Brand} | {nameof(this.Model)} = {Model} | {nameof(this.Year)} = {Year} | {nameof(this.Engine)} = {Engine} | {nameof(this.Transmission)} = {Transmission} | {nameof(this.Wheels)} = {Wheels} | {nameof(this.Interior)} = {Interior} | {nameof(this.Color)} = {Color} | {nameof(this.VinCode)} = {VinCode} | {nameof(this.Price)} = {Price} | {nameof(this.IsFitForUse)} = {IsFitForUse} | {nameof(this.Status)} = {Status} | {nameof(this.CarId)} = {CarId} | {nameof(this.NumberPlate)} = {NumberPlate} | {nameof(this.Owner)} = {Owner} |}}";
    }
}