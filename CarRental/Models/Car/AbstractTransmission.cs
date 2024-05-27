using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal abstract class AbstractTransmission : IComponent
{
    // PROPERTIES

    internal abstract required string SerialNumber { get; init; }
    public abstract required TypeTransmission Type { get; init; }
    public abstract ComponentStatus Status { get; set; }
}
