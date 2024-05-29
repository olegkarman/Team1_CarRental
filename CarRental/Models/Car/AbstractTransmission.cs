using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

internal abstract class AbstractTransmission : IComponent
{
    // THE PURPOSE OF THE CLASS:
    // // A CAR'S COMPONENT ABSTRACTION.

    // PROPERTIES

    internal abstract required string SerialNumber { get; init; }
    public abstract required TypeTransmission Type { get; init; }
    public abstract ComponentStatus Status { get; set; }
}
