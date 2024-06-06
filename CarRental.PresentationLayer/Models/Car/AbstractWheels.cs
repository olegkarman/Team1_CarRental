using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;
using CarRental.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Models.Car;

internal abstract class AbstractWheels : IComponent
{
    // THE PURPOSE OF THE CLASS:
    // // A CAR'S COMPONENT ABSTRACTION.

    // PROPERTIES

    public abstract required string SerialNumber { get; init; }
    public abstract MaterialWheel Material { get; init; }
    public abstract int Size { get; init; }
    public abstract required TypeTire Tire { get; set; }
    public abstract ComponentStatus Status { get; set; }
}
