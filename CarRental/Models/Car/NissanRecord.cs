using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class NissanRecord : ICarRecordable
{
    public string BrandName { get; } = "Nissan";
    public string[] Models { get; } = ["Nis1", "Nis2", "Nis3"];
}
