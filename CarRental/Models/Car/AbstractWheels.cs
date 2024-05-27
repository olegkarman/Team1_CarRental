using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

internal abstract class AbstractWheels : IComponent
{
    // PROPERTIES

    public abstract MaterialWheel Material { get; init; }
    public abstract int Size { get; init; }
    public abstract required TypeTire Tire { get; set; }
    public abstract ComponentStatus Status { get; set; }
}
