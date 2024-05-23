using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarTransmission : AbstractTransmission
{
    // FIELDS

    // PROPERTIES

    internal override required string SerialNumber { get; init; }
    public TypeTransmission type { get; init; }
    public int SpeedCount { get; init; }
}
