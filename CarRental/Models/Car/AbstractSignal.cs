using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal abstract class AbstractSignal : IComponent
{
    // PROPERTIES

    public abstract PitchComponent Pitch { get; init; }
    public abstract required ComponentStatus Status { get; set; }
}
