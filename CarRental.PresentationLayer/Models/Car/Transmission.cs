using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Data.Models.Car;

public class Transmission : AbstractTransmission
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public override required string SerialNumber { get; init; }
    public override required TypeTransmission Type { get; init; }
    public int SpeedCount { get; init; }
    public override ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(this.Type)} = {Type} | {nameof(this.SpeedCount)} = {SpeedCount} | {nameof(this.Status)} = {Status} }}";
    }
}
