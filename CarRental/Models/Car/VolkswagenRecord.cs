using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class VolkswagenRecord : ICarRecordable
{
    public string BrandName { get; } = "Volkswagen";
    public string[] Models { get; } = ["Golf", "Passat", "Polo", "Jetta", "Multivan", "Bora", "Touareg", "Touran", "Caddy Life", "Lamando", "ID.3"];
}
