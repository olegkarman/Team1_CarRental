using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car
{
    public class InteriorPattern
    {
        // PROPERTIES

        public int InteriorStatusInitialIndex { get; init; }
        public int InteriorStatusEndIndex { get; init; }

        public int ColorInteriorInitial { get; init; }
        public int ColorInteriorEnd { get; init; }
        public int MaterialInteriorInitial { get; init; }
        public int MaterialInteriorEnd { get; init; }
    }
}
