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

    private StringBuilder _nameBuilder;

    // PROPERTIES

    //internal Dictionary<string, string> ModelsZaporozhets { get; init; }
    //internal Dictionary<string, string> ModelsPeugeot { get; init; }
    //internal Dictionary<string, string> ModelsVolkswagen { get; init; }
    //internal Dictionary<string, string> ModelsNissan { get; init; }
    //internal Dictionary<string, string> ModelsGyguli { get; init; }
    //internal Dictionary<string, string> ModelsJeep { get; init; }

    // CONSTRUCTORS

    internal PatternInitializator()
    {
        this._nameBuilder = new StringBuilder();
    }

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

    public BrandRecord[] InitializeBrandRecords(BrandModelsNamesDataSheet dataSheet)
    {
        BrandRecord[] records =
        [
            // ZAPOROZHETS
            new BrandRecord
            (
                // ID
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[0].ToUpper()),

                // ZAPOROZHETS
                dataSheet.BrandNamesData[0],

                // SELECTS PROPER NAMES FOR THE ARRAY AND COPY IT INTO AN ARRAY AND THEN INTO RECORD-CLASS.
                dataSheet.ModelNamesData[0..2]
            ),

            // PEUGEOT
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[1].ToUpper()),

                dataSheet.BrandNamesData[1],

                dataSheet.ModelNamesData[3..13]
            ),

            // VOLKSWAGEN
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[2].ToUpper()),

                dataSheet.BrandNamesData[2],

                dataSheet.ModelNamesData[14..24]
            ),

            // NISSAN
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[3].ToUpper()),

                dataSheet.BrandNamesData[3],

                dataSheet.ModelNamesData[25..35]
            ),

            // GYGULI
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[4].ToUpper()),

                dataSheet.BrandNamesData[4],

                dataSheet.ModelNamesData[36..42]
            ),

            // JEEP
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[5].ToUpper()),

                dataSheet.BrandNamesData[5],

                dataSheet.ModelNamesData[43..52]
            )
        ];

        return records;
    }

    public CarSelectPattern ChoosePatternForModel(string name, string brand, string model, BrandModelsNamesDataSheet dataWarehouse)
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

    // TO CREATE DICTIONARY OF MODEL-GENERATION PATTERN, A BASIC COMPLECTATION LOGIC.
    public Dictionary<string, CarSelectPattern> ChoosePatternForModel(BrandRecord[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
    {
        Dictionary<string, CarSelectPattern> dictionary = new Dictionary<string, CarSelectPattern>();
        foreach (BrandRecord record in brandRecords)
        {
            foreach (string model in record.Models)
            {
                dictionary.Add(model, ChoosePatternForModel($"{model.ToUpper()} + {DateTime.Now}", record.Name, model, dataWarehouse));
            }
        }

        return dictionary;
    }
}
