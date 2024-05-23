using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarSignal : AbstractSignal
{
    // PROPERTIES

    public override PitchComponent Pitch { get; init; }
    public override required ComponentStatus Status { get; set; }
}
