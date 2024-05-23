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

    // FROM System.Drawing, BASE COLORS ENUM.
    public KnownColor Color { get; set; }
    public MaterialInterior Material { get; init; }

}