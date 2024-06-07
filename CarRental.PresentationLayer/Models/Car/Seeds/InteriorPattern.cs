using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car.Seeds
{
    public class InteriorPattern
    {
        // PROPERTIES

        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int ColorInitial { get; init; }
        public int ColorEnd { get; init; }
        public int MaterialInitial { get; init; }
        public int MaterialEnd { get; init; }
    }
}
