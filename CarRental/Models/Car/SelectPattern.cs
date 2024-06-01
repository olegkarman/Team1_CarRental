using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

public class SelectPattern : ICarSelectivePattern
{
    // THE PURPOSE OF THE CLASS:
    // // A DATA-HOLDER OF A PATTERN NECCESSARY TO GENERATE A CAR INSTANCE.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    #region PROPERTIES

    public Dictionary<string, int> Values;

    public char[] charMap { get; init; }

    //// STATUS S{ECTION
                                                 
    //// CAR-RECORD SECTION                                                                   
                                                
    // PROPERTIES                               
                                                
    public string Name { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }

    #endregion

    // CONSTRUCTORS

    public SelectPattern()
    {
        this.charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    }
}
