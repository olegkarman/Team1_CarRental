using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models.Car;

internal class CarInterior
{
    // FIELDS

    internal required string SerialNumber { get; init; }

    // PROPERTIES

    // FROM System.Drawing, BASE COLORS ENUM.
    public KnownColor Color { get; set; }
    public MaterialInterior Material { get; init; }

}
