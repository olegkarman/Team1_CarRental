using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarSignal : AbstractSignal
{
    // PROPERTIES

    public override PitchComponent Pitch { get; init; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    [SetsRequiredMembersAttribute]

    public CarSignal()
    {
        this.Pitch = 0;
        this.Status = 0;
    }

    public CarSignal(PitchComponent pitch, ComponentStatus status)
    {
        this.Pitch = pitch;
        this.Status = status;
    }
}
