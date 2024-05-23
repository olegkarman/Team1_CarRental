using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarEngine : AbstractEngine
{
    // PROPERTIES

    internal override string SerialNumber { get; init; }
    internal override required int AverageFuelConsumption { get; set; }
    public override FuelEngine Fuel { get; init; }
    public override TypeEngine Type { get; init; }
    internal override required int Power { get; set; }
    public override required ComponentStatus Status { get; set; }
}
