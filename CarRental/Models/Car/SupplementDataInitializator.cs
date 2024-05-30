using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarRental.Models.Car;

internal class SupplementDataInitializator
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS METHOD OF DATA-CLASSES INITIALIZATION.

    // METHODS

    public CarMechanic InitializeMechanic()
    {
        
    }

    public Dictionary<string, CarSelectPattern> InitializeModelsPatternsDictionary(PatternInitializator patternInit, BrandRecord[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
    {
        return patternInit.ChoosePatternForModel(brandRecords, dataWarehouse);
    }

    public BrandRecord[] InitializeBrandRecordsArray(PatternInitializator patternInitializator, BrandModelsNamesDataSheet data)
    {
        return patternInitializator.InitializeBrandRecords(data);
    }

    PatternInitializator InitializePatternInitializator()
    {
        return new PatternInitializator();
    }

    public BrandModelsNamesDataSheet InitializeDataSheet()
    {
        return new BrandModelsNamesDataSheet();
    }

    public Depot InitializeDepot()
    {
        return new Depot();
    }
}
