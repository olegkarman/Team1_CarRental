using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Enumerables;

namespace CarRental.Models.Car;

internal class CarInterior : AbstractInterior
{
    // PROPERTIES

    public override required KnownColor Color { get; set; } // FROM System.Drawing, BASE COLORS ENUM.
    public override required MaterialInterior Material { get; init; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    //public CarInterior(KnownColor color, MaterialInterior material, ComponentStatus status)
    //{
    //    this.Color = color;
    //    this.Material = material;
    //    this.Status = status;
    //}

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Material)} = {Material} | {nameof(this.Color)} = {Color} | {nameof(this.Status)} = {Status} }}";
    }
}
