using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car
{
    public class LightsPattern
    {
        // PROPERTIES

        public int LightsStatusInitialIndex { get; init; }
        public int LightsStatusEndIndex { get; init; }

        public int ColorLightsInitial { get; init; }
        public int ColorLightsEnd { get; init; }
        public int PowerLightsInitial { get; init; }
        public int PowerLightsEnd { get; init; }
    }
}
