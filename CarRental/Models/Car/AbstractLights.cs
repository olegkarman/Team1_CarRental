using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Enumerables;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

internal abstract class AbstractLights : IComponent
{
    // THE PURPOSE OF THE CLASS:
    // // A CAR'S COMPONENT ABSTRACTION.

    // PROPERTIES

    public abstract PowerComponent Power { get; init; }
    public abstract KnownColor Color { get; init; }
    public abstract required ComponentStatus Status { get; set; }
}
