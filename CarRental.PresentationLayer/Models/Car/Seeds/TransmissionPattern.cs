using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car.Seeds
{
    public class TransmissionPattern
    {
        // PROPERTIES

        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int TypeInitial { get; init; }
        public int TypeEnd { get; init; }
        public int SpeedCountInitial { get; init; }
        public int SpeedCountEnd { get; init; }
    }
}
