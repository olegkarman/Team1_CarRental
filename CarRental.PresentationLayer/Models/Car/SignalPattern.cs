using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car
{
    public class SignalPattern
    {
        // PROPERTIES

        public int SignalStatusInitialIndex { get; init; }
        public int SignalStatusEndIndex { get; init; }

        public int PitchInitial { get; init; }
        public int PitchEnd { get; init; }
    }
}
