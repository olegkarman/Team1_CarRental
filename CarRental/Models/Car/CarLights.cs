using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;

namespace CarRental.Models.Car;

internal class CarLights : AbstractLights
{
    // THE PURPOSE OF THE CLASS:
    // // A COMPONENT OF A CAR.

    // PROPERTIES

    public override KnownColor Color { get; init; }
    public override PowerComponent Power { get; init; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Color)} = {Color} | {nameof(this.Power)} = {Power} | {nameof(this.Status)} = {Status} }}";
    }
}
