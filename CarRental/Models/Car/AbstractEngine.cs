﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

internal abstract class AbstractEngine : IComponent
{
    // PROPERTIES

    internal abstract string SerialNumber { get; init; }
    public abstract FuelEngine Fuel { get; init; }
    public abstract TypeEngine Type { get; init; }
    internal abstract required int AverageFuelConsumption { get; set; }
    internal abstract required int Power { get; set; }
    public abstract ComponentStatus Status { get; set; }
}