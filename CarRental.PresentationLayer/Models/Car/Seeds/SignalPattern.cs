using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car.Seeds
{
    public class SignalPattern
    {
        // PROPERTIES

        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int PitchInitial { get; init; }
        public int PitchEnd { get; init; }
    }
}
