using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car.Seeds
{
    public class GeneralModelPattern
    {
        public int StatusInitialIndex { get; init; }
        public int StatusEndIndex { get; init; }

        public int ColorCarInitial { get; init; }
        public int ColorCarEnd { get; init; }
        public int PriceCarInitial { get; init; }
        public int PriceCarEnd { get; init; }
        public int MaxFuelCapacityInitial { get; init; }
        public int MaxFuelCapacityEnd { get; init; }
        public int CurrentFuelInitial { get; init; }
        public int CurrentFuelEnd { get; init; }
        public int SpeedCoeficientInitial { get; init; }
        public int SpeedCoeficientEnd { get; init; }
    }
}
