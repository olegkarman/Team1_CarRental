using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarEngine : AbstractEngine
{
    // FIELDS

    // PROPERTIES

    internal override required string SerialNumber { get; init; }
    internal override required int AverageFuelConsumption { get; set; }
    public override required FuelEngine Fuel { get; init; }
    public override required TypeEngine Type { get; init; }
}
