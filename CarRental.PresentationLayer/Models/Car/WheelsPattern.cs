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

        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int MaterialInitial { get; init; }
        public int MaterialEnd { get; init; }
        public int SizeInitial { get; init; }
        public int SizeEnd { get; init; }
        public int TireInitial { get; init; }
        public int TireEnd { get; init; }
    }
}
