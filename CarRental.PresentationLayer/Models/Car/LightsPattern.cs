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

        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int ColorInitial { get; init; }
        public int ColorEnd { get; init; }
        public int PowerInitial { get; init; }
        public int PowerEnd { get; init; }
    }
}
