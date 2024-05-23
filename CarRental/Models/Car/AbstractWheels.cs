using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal abstract class AbstractWheels : IComponent
{
    public abstract required MaterialWheel Material { get; init; }
    public abstract required int Size { get; init; }
    public abstract TypeTire Tire { get; set; }
    public abstract ComponentStatus Status { get; set; }
}
