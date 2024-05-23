using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models.Car;

internal abstract class AbstractInterior : IComponent
{
    // PROPERTIES

    public abstract required KnownColor Color { get; set; }
    public abstract MaterialInterior Material { get; init; }
    public abstract required ComponentStatus Status { get; set; }
}
