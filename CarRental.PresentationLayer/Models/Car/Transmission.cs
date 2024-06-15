using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

namespace CarRental.Data.Models.Car;

public class Transmission
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public required string SerialNumber { get; init; }
    public required TypeTransmission Type { get; init; }
    public int SpeedCount { get; init; }
    public ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Type)} = {Type} | {nameof(this.SpeedCount)} = {SpeedCount} | {nameof(this.Status)} = {Status} }}";
    }
}
