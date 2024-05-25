using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class NissanRecord : ICarRecordable
{
    public string BrandName { get; } = "Nissan";
    public string[] Models { get; } = ["Patrol", "Skyline", "GT-R", "Serena", "Altima", "V-Drive", "Elgrand", "Sylphy", "X-Trail", "Murano", "Qashqai"];
}
