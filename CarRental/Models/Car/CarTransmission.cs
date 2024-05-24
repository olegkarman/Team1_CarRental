using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarTransmission : AbstractTransmission
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    internal override required string SerialNumber { get; init; }
    public override required TypeTransmission Type { get; init; }
    public int SpeedCount { get; init; }
    public override required ComponentStatus Status { get; set; }

    // CONSTRUCTORS

    public CarTransmission()
    {
        this.SerialNumber = _noInfo;
        this.Type = 0;
        this.SpeedCount = 0;
        this.Status = 0;
    }

    public CarTransmission(string serialNumber, TypeTransmission type, int speedCount, ComponentStatus status)
    {
        this.SerialNumber = serialNumber;
        this.Type = type;
        this.SpeedCount = speedCount;
        this.Status = status;
    }
}
