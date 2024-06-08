using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Interfaces;

public interface IComponent
{
    public string SerialNumber { get; init;  }
    public ComponentStatus Status { get; set; }
}
