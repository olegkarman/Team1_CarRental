using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Enumerables;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Models.Car;

internal class Interior : AbstractInterior
{
    // THE PURPOSE OF THE CLASS:
    // // A COMPONENT OF A CAR.

    // PROPERTIES

    public override required KnownColor Color { get; set; } // FROM System.Drawing, BASE COLORS ENUM.
    public override required MaterialInterior Material { get; init; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Material)} = {Material} | {nameof(this.Color)} = {Color} | {nameof(this.Status)} = {Status} }}";
    }
}
