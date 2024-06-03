using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car.RecordTypes;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

internal record class PatternCharMaps
{
    // PROPERTIES

    internal char[][] CharMaps { get; init; }

    // CONSTRUCTOR

    public PatternCharMaps()
    {
        CharMaps[0] = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
        CharMaps[1] = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'];
        CharMaps[2] = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    }
}
