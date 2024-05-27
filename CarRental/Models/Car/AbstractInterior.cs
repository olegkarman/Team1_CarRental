using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Enumerables;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

internal abstract class AbstractInterior : IComponent
{
    // PROPERTIES

    public abstract required KnownColor Color { get; set; }
    public abstract required MaterialInterior Material { get; init; }
    public abstract required ComponentStatus Status { get; set; }
}
