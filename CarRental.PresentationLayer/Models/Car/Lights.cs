using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

namespace CarRental.Data.Models.Car;

public class Lights
{
    // THE PURPOSE OF THE CLASS:
    // // A COMPONENT OF A CAR.

    // PROPERTIES

    public required string SerialNumber { get; init; }
    public KnownColor Color { get; init; }
    public PowerComponent Power { get; init; }
    public required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Color)} = {Color} | {nameof(this.Power)} = {Power} | {nameof(this.Status)} = {Status} }}";
    }
}
