﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;

namespace CarRental.Data.Interfaces;

public interface IComponent
{
    public string SerialNumber { get; init;  }
    public ComponentStatus Status { get; set; }
}