﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;
using CarRental.Models.Car.RecordTypes;
//using static System.Runtime.InteropServices.JavaScript.JSType;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Models.Car;

internal class SupplementDataInitializator
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS METHOD OF DATA-CLASSES INITIALIZATION.

    // METHODS

    public Mechanic InitializeMechanic()
    {
        try
        {
            Random random = new Random();

            return new Mechanic($"{random.Next(19, 1000001)}{random.Next('A', 'Z')}", (NamesSurenames)random.Next(10, 18), (NamesSurenames)random.Next(10, 18));
        }
        catch(InvalidCastException exception)
        {
            throw exception;
        }
        catch
        {
            throw new Exception();
        }
    }

    public Dictionary<string, SelectPattern> InitializeModelsPatternsDictionary(PatternInitializator patternInit, BrandRecord[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
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