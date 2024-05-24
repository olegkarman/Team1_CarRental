﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarEngine : AbstractEngine
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    internal override string SerialNumber { get; init; }
    internal override required int AverageFuelConsumption { get; set; }
    public override FuelEngine Fuel { get; init; }
    public override TypeEngine Type { get; init; }
    internal override required int Power { get; set; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    public CarEngine()
    {
        this.SerialNumber = _noInfo;
        this.AverageFuelConsumption = int.MaxValue; // SHOULD BE IMPOSSIBLE TO DRIVE.
        this.Fuel = 0;
        this.Type = 0;
        this.Power = 0;
        this.Status = 0;
    }
}
