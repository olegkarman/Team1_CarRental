using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car.Abstractions;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Models.Car;

public class Engine : AbstractEngine
{
    // THE PURPOSE OF THE CLASS:
    // // A COMPONENT OF A CAR.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public override string SerialNumber { get; init; }
    public override required int AverageFuelConsumption { get; set; }
    public override FuelEngine Fuel { get; init; }
    public override TypeEngine Type { get; init; }
    public override required int Power { get; set; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Type)} = {Type} | {nameof(Power)} = {Power} | {nameof(this.Fuel)} = {Fuel} | {nameof(this.AverageFuelConsumption)} = {AverageFuelConsumption} | {nameof(this.Status)} = {Status} }}";
    }
}
