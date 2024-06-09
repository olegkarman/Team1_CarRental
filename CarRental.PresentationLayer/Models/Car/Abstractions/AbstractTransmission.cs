using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Models.Car.Abstractions;

public abstract class AbstractTransmission : IComponent
{
    // THE PURPOSE OF THE CLASS:
    // // A CAR'S COMPONENT ABSTRACTION.

    // PROPERTIES

    public abstract required string SerialNumber { get; init; }
    public abstract required TypeTransmission Type { get; init; }
    public abstract ComponentStatus Status { get; set; }
}
