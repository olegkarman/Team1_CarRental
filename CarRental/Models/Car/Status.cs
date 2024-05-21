using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal enum TransportStatus : byte
{
    unavailable = 0,
    available = 1,
    rented = 2,
    sold = 3,
    repair = 4,
    unknown = 200
}
