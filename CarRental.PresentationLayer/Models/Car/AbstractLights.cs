﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Enumerables;
using CarRental.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

public abstract class AbstractLights : IComponent
{
    // THE PURPOSE OF THE CLASS:
    // // A CAR'S COMPONENT ABSTRACTION.

    // PROPERTIES

    public abstract PowerComponent Power { get; init; }
    public abstract KnownColor Color { get; init; }
    public abstract required ComponentStatus Status { get; set; }
}
