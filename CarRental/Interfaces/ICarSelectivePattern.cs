﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Interfaces;

public interface ICarSelectivePattern : IPatternable
{
    // PROPERTIES

    public char[] charMap { get; init; }

    public int StatusInitialIndex { get; init; }
    public int StatusEndIndex { get; init; }

    public int EngineStatusInitialIndex { get; init; }
    public int EngineStatusEndIndex { get; init; }

    public int TransmissionStatusInitialIndex { get; init; }
    public int TransmissionStatusEndIndex { get; init; }

    public int InteriorStatusInitialIndex { get; init; }
    public int InteriorStatusEndIndex { get; init; }

    public int WheelsStatusInitialIndex { get; init; }
    public int WheelsStatusEndIndex { get; init; }

    public int LightsStatusInitialIndex { get; init; }
    public int LightsStatusEndIndex { get; init; }

    public int SignalStatusInitialIndex { get; init; }
    public int SignalStatusEndIndex { get; init; }
}
