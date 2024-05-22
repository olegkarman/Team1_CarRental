using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarEngine
{
    // FIELDS

    internal required string SerialNumber { get; init; }

    // PROPERTIES

    public FuelEngine fuel { get; init; }
    public TypeEngine type { get; init; }
}
