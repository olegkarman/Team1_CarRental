using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;

namespace CarRental.Models.Car;

internal class CarWheels : AbstractWheels
{
    // PROPERTIES

    public override required MaterialWheel Material { get; init; }
    public override required int Size { get; init; }
    public override required TypeTire Tire { get; set; }
    public override ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    //public CarWheels(MaterialWheel material, int size, TypeTire tire)
    //{
    //    this.Material = material;
    //    this.Size = size;
    //    this.Tire = tire;
    //}

    // METHODS

    public override string ToString()
    {

        return $"{{ {nameof(this.Material)} = {Material} | {nameof(this.Size)} = {Size} | {nameof(this.Tire)} = {Tire} | {nameof(this.Status)} = {Status} }}";
    }
}
