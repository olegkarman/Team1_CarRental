using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

namespace CarRental.Data.Models.Car;

public class Engine
{
    // THE PURPOSE OF THE CLASS:
    // // A COMPONENT OF A CAR.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public string SerialNumber { get; init; }
    public required int AverageFuelConsumption { get; set; }
    public FuelEngine Fuel { get; init; }
    public TypeEngine Type { get; init; }
    public required int Power { get; set; }
    public required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Type)} = {Type} | {nameof(Power)} = {Power} | {nameof(this.Fuel)} = {Fuel} | {nameof(this.AverageFuelConsumption)} = {AverageFuelConsumption} | {nameof(this.Status)} = {Status} }}";
    }
}
