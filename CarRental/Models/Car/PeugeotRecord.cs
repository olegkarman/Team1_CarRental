using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class PeugeotRecord : ICarRecordable
{
    public string BrandName { get; } = "Peugeot";
    public string[] Models { get; } = ["Peugeot-204", "Peugeot-J7", "Peugeot-305", "Peugeot-J9", "Peugeot-P4", "Peugeot-406", "Peugeot-6007", "Peugeot-107", "Peugeot-908", "Bipper", "Peugeot-108"];
}
