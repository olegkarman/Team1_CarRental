﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarWheels : AbstractWheels, IComponent
{
    // PROPERTIES

    public MaterialWheel Material { get; init; }
    public int Size { get; init; }
    internal TypeTire Tire { get; set; }
    public ComponentStatus Status { get; set; }
}
