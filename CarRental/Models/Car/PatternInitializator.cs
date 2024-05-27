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

    private BrandModelsNamesDataSheet _dataWarehouse;

    // CONSTRUCTORS

    internal PatternInitializator(BrandModelsNamesDataSheet dataWarehouse)
    {
        this._dataWarehouse = dataWarehouse;
        //ModelPatternDataDictionary =
    }

    // METHODS

    public CarSelectPattern GeneratePatternForModel (string name, string brand, string model)
    {
        CarSelectPattern pattern = new CarSelectPattern
        (
            name,
            brand,
            model,
            _dataWarehouse.ModelPatternDataDictionary[model]
        );

        return pattern;
    }

}
