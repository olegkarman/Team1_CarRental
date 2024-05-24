using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class ZaporoghetsRecord : ICarRecordable
{
    public string BrandName { get; } = "Zaporoghets";
    public string[] Models { get; } = ["Zap1", "Zap2", "Zap3"];
}
