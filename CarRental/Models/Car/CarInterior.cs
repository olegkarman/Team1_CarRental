using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models.Car;

internal class CarInterior : AbstractInterior, IComponent
{
    // PROPERTIES

    public override required KnownColor Color { get; set; } // FROM System.Drawing, BASE COLORS ENUM.
    public override required MaterialInterior Material { get; init; }
    public override ComponentStatus Status { get; set; }

}
