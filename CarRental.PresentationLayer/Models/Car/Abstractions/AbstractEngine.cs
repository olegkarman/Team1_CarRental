﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Data.Models.Car.Abstractions;

public abstract class AbstractEngine : IComponent
{
    // THE PURPOSE OF THE CLASS:
    // // A CAR'S COMPONENT ABSTRACTION.

    // PROPERTIES

    public abstract string SerialNumber { get; init; }
    public abstract FuelEngine Fuel { get; init; }
    public abstract TypeEngine Type { get; init; }
    public abstract required int AverageFuelConsumption { get; set; }
    public abstract required int Power { get; set; }
    public abstract ComponentStatus Status { get; set; }
}