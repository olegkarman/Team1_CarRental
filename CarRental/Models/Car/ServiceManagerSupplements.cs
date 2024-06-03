using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Car.RecordTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Models.Car;

internal class ServiceManagerSupplements
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS FIELDS ARE ALL NECCESSARY CLASSES TO CREATE CAR-CLASS INSTANCE.

    // FIELDS

    // PROPERTIES

    internal BrandModelsNamesDataSheet BrandModelsDataSheet { get; init; }
    internal Depot DepotService { get; init; }
    internal Dictionary<string, SelectPattern> ModelsPatterns { get; init; }
    internal BrandRecord[] BrandRecords { get; init; }
    internal Mechanic Mechanic { get; init; }
}
