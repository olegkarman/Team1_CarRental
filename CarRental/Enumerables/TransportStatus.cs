using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
