using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models.Car;

internal abstract class AbstractInterior : IComponent
{
    public abstract required KnownColor Color { get; set; }
    public abstract required MaterialInterior Material { get; init; }
    public abstract ComponentStatus Status { get; set; }
}
