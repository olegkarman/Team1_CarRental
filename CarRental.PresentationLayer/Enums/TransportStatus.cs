using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Enums;

public enum TransportStatus : byte
{
    Unknown = 0,
    Available = 1,
    Rented = 2,
    Sold = 3,
    InRepair = 4,
    Unavailable = 200
}
