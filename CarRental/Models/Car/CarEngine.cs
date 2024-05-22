using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarEngine
{
    public FuelEngine fuel { get; init; }
    public TypeEngine type { get; init; }
}
