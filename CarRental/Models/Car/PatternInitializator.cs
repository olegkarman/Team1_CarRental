using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

public class PatternInitializator
{
    // THE PURPOSE OF THE CLASS:
    // // TO INITIALIZE A PATTERN-CLAS INSTANCE AND COLLECTION OF PATTERN CLASS INSTANCES.

    // FIELDS

    private StringBuilder _nameBuilder;

    // CONSTRUCTORS

    public PatternInitializator()
    {
        this._nameBuilder = new StringBuilder();
    }

    // METHODS

    // TO CREATE THE ARRAY OF BRAND-RECORDS INSTANCES WITH KNWLEDGE OF DATA USED.
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

    // TO CREATE INSTANCE OF PATTERN-CLASS.
    public SelectPattern ChoosePatternForModel(string name, string brand, string model, BrandModelsNamesDataSheet dataWarehouse)
    {
        // USE INITIALIZATOR INSTEAD OF EXTENSIVE CONSTRUCTORS.
        SelectPattern pattern = new SelectPattern
        {
            Name = name,
            Brand = brand,
            Model = model,
            StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][0],
            StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][1],

            EngineStatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][2],
            EngineStatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][3],

            TransmissionStatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][4],
            TransmissionStatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][5],

            InteriorStatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][6],
            InteriorStatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][7],

            WheelsStatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][8],
            WheelsStatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][9],

            LightsStatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][10],
            LightsStatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][11],

            SignalStatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][12],
            SignalStatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][13],

            ColorCarInitial = dataWarehouse.ModelPatternDataDictionary[model][14],
            ColorCarEnd = dataWarehouse.ModelPatternDataDictionary[model][15],
            PriceCarInitial = dataWarehouse.ModelPatternDataDictionary[model][16],
            PriceCarEnd = dataWarehouse.ModelPatternDataDictionary[model][17],
            MaxFuelCapacityInitial = dataWarehouse.ModelPatternDataDictionary[model][18],
            MaxFuelCapacityEnd = dataWarehouse.ModelPatternDataDictionary[model][19],
            CurrentFuelInitial = dataWarehouse.ModelPatternDataDictionary[model][20],
            CurrentFuelEnd = dataWarehouse.ModelPatternDataDictionary[model][21],
            SpeedCoeficientInitial = dataWarehouse.ModelPatternDataDictionary[model][22],
            SpeedCoeficientEnd = dataWarehouse.ModelPatternDataDictionary[model][23],

            AverageFuelConsumptionInitial = dataWarehouse.ModelPatternDataDictionary[model][24],
            AverageFuelConsumptionEnd = dataWarehouse.ModelPatternDataDictionary[model][25],
            FuelInitial = dataWarehouse.ModelPatternDataDictionary[model][26],
            FuelEnd = dataWarehouse.ModelPatternDataDictionary[model][27],
            TypeEngineInitial = dataWarehouse.ModelPatternDataDictionary[model][28],
            TypeEngineEnd = dataWarehouse.ModelPatternDataDictionary[model][29],
            PowerEngineInitial = dataWarehouse.ModelPatternDataDictionary[model][30],
            PowerEngineEnd = dataWarehouse.ModelPatternDataDictionary[model][31],

            TypeTransmissionInitial = dataWarehouse.ModelPatternDataDictionary[model][32],
            TypeTransmissionEnd = dataWarehouse.ModelPatternDataDictionary[model][33],
            SpeedCountInitial = dataWarehouse.ModelPatternDataDictionary[model][34],
            SpeedCountEnd = dataWarehouse.ModelPatternDataDictionary[model][35],

            ColorInteriorInitial = dataWarehouse.ModelPatternDataDictionary[model][36],
            ColorInteriorEnd = dataWarehouse.ModelPatternDataDictionary[model][37],
            MaterialInteriorInitial = dataWarehouse.ModelPatternDataDictionary[model][38],
            MaterialInteriorEnd = dataWarehouse.ModelPatternDataDictionary[model][39],

            MaterialWheelsInitial = dataWarehouse.ModelPatternDataDictionary[model][40],
            MaterialWheelsEnd = dataWarehouse.ModelPatternDataDictionary[model][41],
            SizeWheelsInitial = dataWarehouse.ModelPatternDataDictionary[model][42],
            SizeWheelsEnd = dataWarehouse.ModelPatternDataDictionary[model][43],
            TireInitial = dataWarehouse.ModelPatternDataDictionary[model][44],
            TireEnd = dataWarehouse.ModelPatternDataDictionary[model][45],

            ColorLightsInitial = dataWarehouse.ModelPatternDataDictionary[model][46],
            ColorLightsEnd = dataWarehouse.ModelPatternDataDictionary[model][47],
            PowerLightsInitial = dataWarehouse.ModelPatternDataDictionary[model][48],
            PowerLightsEnd = dataWarehouse.ModelPatternDataDictionary[model][49],

            PitchInitial = dataWarehouse.ModelPatternDataDictionary[model][50],
            PitchEnd = dataWarehouse.ModelPatternDataDictionary[model][51]
        };

        return pattern;
    }

    // OVERLOAD OF THE METHOD TO CREATE DICTIONARY OF MODEL-GENERATION PATTERN, A BASIC COMPLECTATION LOGIC.
    public Dictionary<string, SelectPattern> ChoosePatternForModel(BrandRecord[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
    {
        Dictionary<string, SelectPattern> dictionary = new Dictionary<string, SelectPattern>();
        foreach (BrandRecord record in brandRecords)
        {
            foreach (string model in record.Models)
            {
                dictionary.Add(model, ChoosePatternForModel($"{model.ToUpper()} + {DateTime.Now}", record.BrandName, model, dataWarehouse));
            }
        }

        return dictionary;
    }
}
