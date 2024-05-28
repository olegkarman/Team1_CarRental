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

    //public void InitializeDictionaries(BrandModelsNamesDataSheet brandModelsNamseData)
    //{
    //    this.ModelsZaporozhets = new Dictionary<string, string>();

    //    for (int index = 0; index < 3; index = index + index)
    //    {
    //        this.ModelsZaporozhets.Add(this.ModelNamesData[index], this.BrandNamesData[0]);
    //    }

    //    this.ModelsPeugeot = new Dictionary<string, string>();

    //    for (int index = 3; index < 14; index = index + index)
    //    {
    //        this.ModelsPeugeot.Add(this.ModelNamesData[index], this.BrandNamesData[1]);
    //    }

    //    this.ModelsVolkswagen = new Dictionary<string, string>();

    //    for (int index = 14; index < 24; index = index + index)
    //    {
    //        this.ModelsVolkswagen.Add(this.ModelNamesData[index], this.BrandNamesData[2]);
    //    }

    //    this.ModelsNissan = new Dictionary<string, string>();

    //    for (int index = 25; index < 35; index = index + index)
    //    {
    //        this.ModelsNissan.Add(this.ModelNamesData[index], this.BrandNamesData[3]);
    //    }

    //    this.ModelsGyguli = new Dictionary<string, string>();

    //    for (int index = 36; index < 42; index = index + index)
    //    {
    //        this.ModelsGyguli.Add(this.ModelNamesData[index], this.BrandNamesData[4]);
    //    }

    //    this.ModelsJeep = new Dictionary<string, string>();

    //    for (int index = 43; index < 52; index = index + index)
    //    {
    //        this.ModelsJeep.Add(this.ModelNamesData[index], this.BrandNamesData[5]);
    //    }
    //}

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
