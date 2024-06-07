using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car
{
    public class WheelsPattern
    {
        // PROPERTIES

        public int WheelsStatusInitialIndex { get; init; }
        public int WheelsStatusEndIndex { get; init; }

        public int MaterialWheelsInitial { get; init; }
        public int MaterialWheelsEnd { get; init; }
        public int SizeWheelsInitial { get; init; }
        public int SizeWheelsEnd { get; init; }
        public int TireInitial { get; init; }
        public int TireEnd { get; init; }
    }
}
