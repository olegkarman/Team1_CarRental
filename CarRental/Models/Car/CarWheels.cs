using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarWheels : AbstractWheels
{
    // PROPERTIES

    public override required MaterialWheel Material { get; init; }
    public override required int Size { get; init; }
    public override required TypeTire Tire { get; set; }
    public override required ComponentStatus Status { get; set; }
}
