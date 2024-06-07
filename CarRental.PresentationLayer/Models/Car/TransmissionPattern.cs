using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car
{
    public class TransmissionPattern
    {
        // PROPERTIES

        public int TransmissionStatusInitialIndex { get; init; }
        public int TransmissionStatusEndIndex { get; init; }

        public int TypeTransmissionInitial { get; init; }
        public int TypeTransmissionEnd { get; init; }
        public int SpeedCountInitial { get; init; }
        public int SpeedCountEnd { get; init; }
    }
}
