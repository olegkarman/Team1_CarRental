using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car.Abstractions;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Interfaces;

public interface ICar
{
    public AbstractEngine Engine { get; set; }
    public AbstractInterior Interior { get; set; }
    public AbstractWheels Wheels { get; set; }
    public AbstractTransmission Transmission { get; set; }
}
