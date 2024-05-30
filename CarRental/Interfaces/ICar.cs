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
    public Models.Car.AbstractEngine Engine { get; set; }
    public Models.Car.AbstractInterior Interior { get; set; }
    public Models.Car.AbstractWheels Wheels { get; set; }
    public Models.Car.AbstractTransmission Transmission { get; set; }
    public bool Drive(ICanDrive driver, float averageSpeed, int drivingTime);
}
