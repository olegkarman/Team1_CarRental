using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

namespace CarRental.Data.Models.Car;

public class Wheels
{
    // PROPERTIES

    public required string SerialNumber { get; init; }
    public required MaterialWheel Material { get; init; }
    public required int Size { get; init; }
    public required TypeTire Tire { get; set; }
    public ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {

        return $"{{ {nameof(this.Material)} = {Material} | {nameof(this.Size)} = {Size} | {nameof(this.Tire)} = {Tire} | {nameof(this.Status)} = {Status} }}";
    }
}
