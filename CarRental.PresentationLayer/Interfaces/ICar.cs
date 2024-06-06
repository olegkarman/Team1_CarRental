using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Car;



// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Data.Interfaces;

public interface ICar
{
    internal AbstractEngine Engine { get; set; }
    internal AbstractInterior Interior { get; set; }
    internal AbstractWheels Wheels { get; set; }
    internal AbstractTransmission Transmission { get; set; }
}
