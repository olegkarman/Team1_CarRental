using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Car;

namespace CarRental.Interfaces;

public interface ICar
{
    internal AbstractEngine Engine { get; set; }
    internal AbstractInterior Interior { get; set; }
    internal AbstractWheels Wheels { get; set; }
    internal AbstractTransmission Transmission { get; set; }
    internal bool Drive(ICanDrive driver, float averageSpeed, int drivingTime);
}
