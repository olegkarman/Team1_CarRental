using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarLights : AbstractLights
{
    // PROPERTIES

    public override KnownColor Color { get; init; }
    public override PowerComponent Power { get; init; }
    public override required ComponentStatus Status { get; set; }
}
