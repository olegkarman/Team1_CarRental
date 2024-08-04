using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Enumerables;

public enum TransportStatus : byte
{
    unknown = 0,
    available = 1,
    rented = 2,
    sold = 3,
    inRepair = 4,
    unavailable = 200
}
