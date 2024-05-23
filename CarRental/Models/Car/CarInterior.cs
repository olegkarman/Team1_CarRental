﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models.Car;

internal class CarInterior : AbstractInterior
{
    // PROPERTIES

    public override required KnownColor Color { get; set; } // FROM System.Drawing, BASE COLORS ENUM.
    public override MaterialInterior Material { get; init; }
    public override required ComponentStatus Status { get; set; }
}
