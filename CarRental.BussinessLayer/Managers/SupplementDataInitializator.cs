using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;
using CarRental.Data.Models.Car.RecordTypes;
using CarRental.Data.Models.Car.Seeds;
using CarRental.BussinessLayer.Validators;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.BussinessLayer.Managers;

public class SupplementDataInitializator
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS METHOD OF DATA-CLASSES INITIALIZATION.

    // METHODS

    public Mechanic InitializeMechanic()
    {
        try
        {
            Random random = new Random();

            return new Mechanic(/*$"{random.Next(19, 1000001)}{random.Next('A', 'Z')}", (NamesSurenames)random.Next(10, 18), (NamesSurenames)random.Next(10, 18)*/);
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

    public Dictionary<string, ModelComponentsPattern> InitializeModelsPatternsDictionary(PatternInitializator patternInit, BrandRecord[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
    {
        return patternInit.ChoosePatternForModel(brandRecords, dataWarehouse);
    }

    public BrandRecord[] InitializeBrandRecordsArray(PatternInitializator patternInitializator, BrandModelsNamesDataSheet data)
    {
        return patternInitializator.InitializeBrandRecords(data);
    }

    public PatternInitializator InitializePatternInitializator()
    {
        return new PatternInitializator();
    }

    public BrandModelsNamesDataSheet InitializeDataSheet()
    {
        DataSeedManager dataSeedManager = new DataSeedManager();

        return dataSeedManager.SeedModelComponentsData();
    }

    public Depot InitializeDepot()
    {
        return new Depot();
    }

    public VehicleValidation InitializeValidator()
    {
        return new VehicleValidation();
    }
}
