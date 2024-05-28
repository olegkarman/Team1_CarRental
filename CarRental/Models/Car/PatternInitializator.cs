using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarRental.Models.Car;

internal class PatternInitializator
{
    // FIELDS

    // METHODS

    public CarSelectPattern GeneratePatternForModel (BrandModelsNamesDataSheet dataWarehouse, string name, string brand, string model)
    {
        CarSelectPattern pattern = new CarSelectPattern
        (
            name,
            brand,
            model,
            dataWarehouse.ModelPatternDataDictionary[model]
        );

        return pattern;
    }

}
