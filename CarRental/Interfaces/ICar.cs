using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Interfaces;

public interface ICar
{
    internal Models.Car.AbstractEngine Engine { get; set; }
    internal Models.Car.AbstractInterior Interior { get; set; }
    internal Models.Car.AbstractWheels Wheels { get; set; }
    internal Models.Car.AbstractTransmission Transmission { get; set; }
    //internal bool Drive(ICanDrive driver, float averageSpeed, int drivingTime);
}
