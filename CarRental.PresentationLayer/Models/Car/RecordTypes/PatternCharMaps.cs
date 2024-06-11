using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models.Car.RecordTypes;

internal record class PatternCharMaps
{
    // PROPERTIES

    internal List<char[]> CharMaps { get; init; }

    // CONSTRUCTOR

    public PatternCharMaps()
    {
        this.CharMaps = new List<char[]>();
        this.CharMaps.Add(['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9']);
        this.CharMaps.Add(['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']);
        this.CharMaps.Add(['0', '1', '2', '3', '4', '5', '6', '7', '8', '9']);
    }
}
