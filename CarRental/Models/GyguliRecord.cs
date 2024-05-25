using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;

internal record class GyguliRecord
{
    public string brandName = "Gyguli";
    public string[] Models { get; } = ["VAZ-2101", "VAZ-2102", "VAZ-2103", "VAZ-2106", "VAZ-2105", "VAZ-2107", "VAZ-2104"];
}
