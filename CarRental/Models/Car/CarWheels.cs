using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarWheels
{
    public MaterialWheel Material { get; init; }
    public int Size { get; init; }
    internal TypeTire Tire { get; set; }
}
