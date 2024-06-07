using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car
{
    public class EnginePattern
    {
        // PROPERTIES

        public int EngineStatusInitialIndex { get; init; }
        public int EngineStatusEndIndex { get; init; }

        public int AverageFuelConsumptionInitial { get; init; }
        public int AverageFuelConsumptionEnd { get; init; }
        public int FuelInitial { get; init; }
        public int FuelEnd { get; init; }
        public int TypeEngineInitial { get; init; }
        public int TypeEngineEnd { get; init; }
        public int PowerEngineInitial { get; init; }
        public int PowerEngineEnd { get; init; }
    }
}
