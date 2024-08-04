﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;
using CarRental.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

internal abstract class AbstractTransmission : IComponent
{
    // THE PURPOSE OF THE CLASS:
    // // A CAR'S COMPONENT ABSTRACTION.

    // PROPERTIES

    internal abstract required string SerialNumber { get; init; }
    public abstract required TypeTransmission Type { get; init; }
    public abstract ComponentStatus Status { get; set; }
}