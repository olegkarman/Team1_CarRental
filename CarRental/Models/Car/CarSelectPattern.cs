using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarSelectPattern : ICarSelectivePattern
{
    // FIELDS

    private readonly char[] _charMap;

    // PROPERTIES

    public string PatternName { get; init; }

    // CONSTRUCTORS

    public CarSelectPattern()
    {
        this._charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        this.PatternName = "DefaultPattern";
    }
}
