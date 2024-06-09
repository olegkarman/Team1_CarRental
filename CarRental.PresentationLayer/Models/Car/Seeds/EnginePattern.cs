using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car.Seeds
{
    public class EnginePattern
    {
        // PROPERTIES

        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int AverageFuelConsumptionInitial { get; init; }
        public int AverageFuelConsumptionEnd { get; init; }
        public int FuelInitial { get; init; }
        public int FuelEnd { get; init; }
        public int TypeInitial { get; init; }
        public int TypeEnd { get; init; }
        public int PowerInitial { get; init; }
        public int PowerEnd { get; init; }
    }
}
