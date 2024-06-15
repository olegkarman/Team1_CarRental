﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car.RecordTypes;
using CarRental.Data.Models.Car.Seeds;

namespace CarRental.Data.Models.Car;

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

    public Brand[] InitializeBrandRecords(BrandModelsNamesDataSheet dataSheet)
    {
        Brand[] records =
        [
            new Brand
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[0].ToUpper()),

                dataSheet.BrandNamesData[0],

                dataSheet.ModelNamesData[0..2]
            ),

            new Brand
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[1].ToUpper()),

                dataSheet.BrandNamesData[1],

                dataSheet.ModelNamesData[3..13]
            ),

            new Brand
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[2].ToUpper()),

                dataSheet.BrandNamesData[2],

                dataSheet.ModelNamesData[14..24]
            ),

            new Brand
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[3].ToUpper()),

                dataSheet.BrandNamesData[3],

                dataSheet.ModelNamesData[25..35]
            ),

            new Brand
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[4].ToUpper()),

                dataSheet.BrandNamesData[4],

                dataSheet.ModelNamesData[36..42]
            ),

            new Brand
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[5].ToUpper()),

                dataSheet.BrandNamesData[5],

                dataSheet.ModelNamesData[43..52]
            )
        ];

        return records;
    }

    public ModelComponentsPattern ChoosePatternForModel(string name, string brand, string model, BrandModelsNamesDataSheet dataWarehouse)
    {
        PatternCharMaps charMaps = new PatternCharMaps();

        ModelComponentsPattern pattern = new ModelComponentsPattern
        {
            Name = name,
            Brand = brand,
            Model = model,
            charMap = charMaps.CharMaps[0],

            General = new GeneralModelPattern
            {
                StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][0],
                StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][1],

                ColorCarInitial = dataWarehouse.ModelPatternDataDictionary[model][14],
                ColorCarEnd = dataWarehouse.ModelPatternDataDictionary[model][15],
                PriceCarInitial = dataWarehouse.ModelPatternDataDictionary[model][16],
                PriceCarEnd = dataWarehouse.ModelPatternDataDictionary[model][17],
                MaxFuelCapacityInitial = dataWarehouse.ModelPatternDataDictionary[model][18],
                MaxFuelCapacityEnd = dataWarehouse.ModelPatternDataDictionary[model][19],
                CurrentFuelInitial = dataWarehouse.ModelPatternDataDictionary[model][20],
                CurrentFuelEnd = dataWarehouse.ModelPatternDataDictionary[model][21],
                SpeedCoeficientInitial = dataWarehouse.ModelPatternDataDictionary[model][22],
                SpeedCoeficientEnd = dataWarehouse.ModelPatternDataDictionary[model][23]
            },

            Engine = new EnginePattern
            {
                StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][2],
                StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][3],

                AverageFuelConsumptionInitial = dataWarehouse.ModelPatternDataDictionary[model][24],
                AverageFuelConsumptionEnd = dataWarehouse.ModelPatternDataDictionary[model][25],
                FuelInitial = dataWarehouse.ModelPatternDataDictionary[model][26],
                FuelEnd = dataWarehouse.ModelPatternDataDictionary[model][27],
                TypeInitial = dataWarehouse.ModelPatternDataDictionary[model][28],
                TypeEnd = dataWarehouse.ModelPatternDataDictionary[model][29],
                PowerInitial = dataWarehouse.ModelPatternDataDictionary[model][30],
                PowerEnd = dataWarehouse.ModelPatternDataDictionary[model][31],
            },

            Transmission = new TransmissionPattern
            {
                StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][4],
                StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][5],

                TypeInitial = dataWarehouse.ModelPatternDataDictionary[model][32],
                TypeEnd = dataWarehouse.ModelPatternDataDictionary[model][33],
                SpeedCountInitial = dataWarehouse.ModelPatternDataDictionary[model][34],
                SpeedCountEnd = dataWarehouse.ModelPatternDataDictionary[model][35]
            },

            Interior = new InteriorPattern
            {
                StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][6],
                StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][7],

                ColorInitial = dataWarehouse.ModelPatternDataDictionary[model][36],
                ColorEnd = dataWarehouse.ModelPatternDataDictionary[model][37],
                MaterialInitial = dataWarehouse.ModelPatternDataDictionary[model][38],
                MaterialEnd = dataWarehouse.ModelPatternDataDictionary[model][39]
            },

            Wheels = new WheelsPattern
            {
                StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][8],
                StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][9],

                MaterialInitial = dataWarehouse.ModelPatternDataDictionary[model][40],
                MaterialEnd = dataWarehouse.ModelPatternDataDictionary[model][41],
                SizeInitial = dataWarehouse.ModelPatternDataDictionary[model][42],
                SizeEnd = dataWarehouse.ModelPatternDataDictionary[model][43],
                TireInitial = dataWarehouse.ModelPatternDataDictionary[model][44],
                TireEnd = dataWarehouse.ModelPatternDataDictionary[model][45]
            },

            Lights = new LightsPattern
            {
                StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][10],
                StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][11],

                ColorInitial = dataWarehouse.ModelPatternDataDictionary[model][46],
                ColorEnd = dataWarehouse.ModelPatternDataDictionary[model][47],
                PowerInitial = dataWarehouse.ModelPatternDataDictionary[model][48],
                PowerEnd = dataWarehouse.ModelPatternDataDictionary[model][49]
            },

            Signal = new SignalPattern
            {
                StatusInitialIndex = dataWarehouse.ModelPatternDataDictionary[model][12],
                StatusEndIndex = dataWarehouse.ModelPatternDataDictionary[model][13],

                PitchInitial = dataWarehouse.ModelPatternDataDictionary[model][50],
                PitchEnd = dataWarehouse.ModelPatternDataDictionary[model][51]
            }
        };

        return pattern;
    }

    public Dictionary<string, ModelComponentsPattern> ChoosePatternForModel(Brand[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
    {
        Dictionary<string, ModelComponentsPattern> dictionary = new Dictionary<string, ModelComponentsPattern>();
        foreach (Brand record in brandRecords)
        {
            foreach (string model in record.Models)
            {
                dictionary.Add(model, ChoosePatternForModel($"{model.ToUpper()} + {DateTime.Now}", record.BrandName, model, dataWarehouse));
            }
        }

        return dictionary;
    }
}
