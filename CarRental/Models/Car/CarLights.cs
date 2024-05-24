﻿using System;
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

    // CONSTRUCTORS

    public CarLights()
    {
        this.Color = 0;
        this.Power = 0;
        this.Status = 0;
    }

    public CarLights(KnownColor color, PowerComponent power, ComponentStatus status)
    {
        this.Color = color;
        this.Power = power;
        this.Status = status;
    }
}
