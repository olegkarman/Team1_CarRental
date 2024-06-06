using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

internal class Wheels : AbstractWheels
{
    // PROPERTIES

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
