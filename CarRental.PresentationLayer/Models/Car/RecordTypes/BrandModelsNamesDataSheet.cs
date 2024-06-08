using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Models.Car.RecordTypes;

public record class BrandModelsNamesDataSheet
{
    // THE PURPOSE OF THE CLASS:
    // // IT IS A MAIN DATA HOLDER CLASS.

    // PROPERTIES

    public string[] BrandNamesData { get; init; }
    public string[] ModelNamesData { get; init; }
    public Dictionary<string, int[]> ModelPatternDataDictionary { get; init; }

    // CONSTRUCTORS

    public BrandModelsNamesDataSheet()
    {
    
    }
}
