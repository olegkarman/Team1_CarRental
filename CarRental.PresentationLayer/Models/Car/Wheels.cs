using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car.Abstractions;

namespace CarRental.Data.Models.Car;

public class Wheels : AbstractWheels
{
    // PROPERTIES

    public override required string SerialNumber { get; init; }
    public override required MaterialWheel Material { get; init; }
    public override required int Size { get; init; }
    public override required TypeTire Tire { get; set; }
    public override ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {

        return $"{{ {nameof(this.Material)} = {Material} | {nameof(this.Size)} = {Size} | {nameof(this.Tire)} = {Tire} | {nameof(this.Status)} = {Status} }}";
    }
}
