using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarTransmission
{
    // FIELDS

    internal required string SerialNumber { get; init; }

    // PROPERTIES

    public TypeTransmission type { get; init; }
    public int SpeedCount { get; init; }
}
