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
}
