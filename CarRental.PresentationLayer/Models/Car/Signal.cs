﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car.Abstractions;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Models.Car;

public class Signal : AbstractSignal
{
    // PROPERTIES

    public override required string SerialNumber { get; init; }
    public override PitchComponent Pitch { get; init; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Pitch)} = {Pitch} | {nameof(this.Status)} = {Status} }}";
    }
}

