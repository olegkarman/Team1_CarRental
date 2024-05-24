using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarWheels : AbstractWheels
{
    // PROPERTIES

    public override required MaterialWheel Material { get; init; }
    public override required int Size { get; init; }
    public override required TypeTire Tire { get; set; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    public CarWheels()
    {
        this.Material = 0;
        this.Size = 0;
        this.Tire = 0;
        this.Status = 0;
    }

    public CarWheels(MaterialWheel material, int size, TypeTire tire, ComponentStatus status)
    {
        this.Material = material;
        this.Size = size;
        this.Tire = tire;
        this.Status = status;
    }
}
