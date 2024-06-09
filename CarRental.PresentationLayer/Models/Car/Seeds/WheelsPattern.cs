﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Models.Car.Seeds
{
    public class WheelsPattern
    {
        // PROPERTIES

        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int MaterialInitial { get; init; }
        public int MaterialEnd { get; init; }
        public int SizeInitial { get; init; }
        public int SizeEnd { get; init; }
        public int TireInitial { get; init; }
        public int TireEnd { get; init; }
    }
}