using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Enumerables;

namespace CarRental.Models.Car;

internal abstract class AbstractLights : IComponent
{
    // PROPERTIES

    public abstract PowerComponent Power { get; init; }
    public abstract KnownColor Color { get; init; }
    public abstract required ComponentStatus Status { get; set; }
}
