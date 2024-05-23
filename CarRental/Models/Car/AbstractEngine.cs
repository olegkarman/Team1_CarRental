using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal abstract class AbstractEngine
{
    // PROPERTIES

    internal abstract required string SerialNumber { get; init; }
    public abstract required FuelEngine Fuel { get; init; }
    public abstract required TypeEngine Type { get; init; }
    internal abstract required int AverageFuelConsumption { get; set; }
    internal abstract required int Power { get; set; }
}
