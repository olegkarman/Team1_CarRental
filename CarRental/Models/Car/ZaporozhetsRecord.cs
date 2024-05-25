using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class ZaporozhetsRecord : ICarRecordable
{
    public string BrandName { get; } = "Zaporozhets";
    public string[] Models { get; } = ["ZAZ-966V", "ZAZ-965", "ZAZ-968"];
}
