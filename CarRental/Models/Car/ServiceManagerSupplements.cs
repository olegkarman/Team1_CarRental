using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarRental.Models.Car;

internal class ServiceManagerSupplements
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS FIELDS ARE ALL NECCESSARY CLASSES TO CREATE CAR-CLASS INSTANCE.

    // FIELDS

    // PROPERTIES

    internal BrandModelsNamesDataSheet BrandModelsDataSheet { get; init; }
    internal Depot DepotService { get; init; }
    internal Dictionary<string, CarSelectPattern> ModelsPatterns { get; init; }
    internal BrandRecord[] BrandRecords { get; init; }
    internal CarMechanic Mechanic { get; init; }
}
