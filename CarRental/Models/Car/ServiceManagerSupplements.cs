using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

internal class ServiceManagerSupplements
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS FIELDS ARE ALL NECCESSARY CLASSES TO CREATE CAR-CLASS INSTANCE.

    // FIELDS

    // PROPERTIES

    internal required BrandModelsNamesDataSheet BrandModelsDataSheet { get; init; }
    internal required Depot DepotService { get; init; }
    internal required Dictionary<string, SelectPattern> ModelsPatterns { get; init; }
    internal required BrandRecord[] BrandRecords { get; init; }
    internal required Mechanic Mechanic { get; init; }
}
