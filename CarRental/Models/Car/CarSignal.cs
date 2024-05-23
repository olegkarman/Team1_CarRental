using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarSignal : AbstractSignal
{
    public override PitchComponent Pitch { get; init; }
    public override ComponentStatus Status { get; set; }
}
