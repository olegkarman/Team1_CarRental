using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class VolkswagenRecord : ICarRecordable
{
    public string BrandName { get; } = "Volkswagen";
    public string[] Models { get; } = ["Wag1", "Wag2", "Wag3"];
}
