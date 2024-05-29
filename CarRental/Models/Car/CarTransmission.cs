﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;

namespace CarRental.Models.Car;

internal class CarTransmission : AbstractTransmission
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    internal override required string SerialNumber { get; init; }
    public override required TypeTransmission Type { get; init; }
    public int SpeedCount { get; init; }
    public override ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Type)} = {Type} | {nameof(this.SpeedCount)} = {SpeedCount} | {nameof(this.Status)} = {Status} }}";
    }
}
