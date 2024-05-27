using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Enumerables;
using CarRental.Interfaces;
//using System.Diagnostics;
//using System.Reflection;

namespace CarRental.Models.Car;

public class WYCDepot
{
    // CLASS RESPONSIBILITY:
    // TO CREATE A CAR BASED ON PRE-DEFINED PATTERN

    // FIELDS

    // DATA SOURCE
    private BrandModelsNamesDataSheet _brandModelData;
    private PatternInitializator _patternInit;

    // FIELDS

    private StringBuilder snStringBuilder = new StringBuilder();
    private Random _random = new Random();
    private readonly IBrandRecordable[] _records;

    // PATTERN SOURCE
    private readonly ICarSelectivePattern[] _patterns;
    private readonly ICarSelectivePattern defaultPattern;

    // CONSTRUCTORS

    public WYCDepot()
    {
        // DATA INITIALIZATION
        
        this._brandModelData = new BrandModelsNamesDataSheet();
        this._patternInit = new PatternInitializator(_brandModelData);

        this._records =
        [
            // ZAPOROZHETS
            new BrandRecord
            (
                // ID
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[0].ToUpper()),

                // ZAPOROZHETS
                _brandModelData.BrandNamesData[0],

                // SELECTS PROPER NAMES FOR THE ARRAY AND COPY IT INTO AN ARRAY AND THEN INTO RECORD-CLASS.

                _brandModelData.ModelNamesData[0..2]
            ),

            // PEUGEOT
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[1].ToUpper()),

                _brandModelData.BrandNamesData[1],

                _brandModelData.ModelNamesData[3..13]
            ),

            // VOLKSWAGEN
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[2].ToUpper()),

                _brandModelData.BrandNamesData[2],

                _brandModelData.ModelNamesData[14..24]
            ),

            // NISSAN
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[3].ToUpper()),

                _brandModelData.BrandNamesData[3],

                _brandModelData.ModelNamesData[25..35]
            ),

            // GYGULI
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[4].ToUpper()),

                _brandModelData.BrandNamesData[4],

                _brandModelData.ModelNamesData[36..42]
            ),

            // JEEP
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[5].ToUpper()),

                _brandModelData.BrandNamesData[5],

                _brandModelData.ModelNamesData[43..52]
            )
        ];

        // TO CREATE PATTERNS AND ASSIGN

        this._patterns =
        [
            //new CarSelectPattern
            //(
            //    "currentModelPatpern",

            //)
            new CarSelectPattern
            (
                "simpleReadyComponents",
                1, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10
            ),

            new CarSelectPattern
            (
                "simpleAllReadyStatus",
                1, 1, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10

            ),

            new CarSelectPattern
            (
                "allRandomDefault",
                1, 5, 10, 13, 10, 13, 10, 13, 10, 13, 10, 13, 10, 13
            )
        ];

        // TO ASSIGN DEFAULT PATTERN FOR NO-OVERLOAD METHOD.

        this.defaultPattern = _patterns[0];
    }

    // MEHODS

    internal Car GetNewCar()
    {
        ICarSelectivePattern pattern = this.defaultPattern;

        int tempRandom;

        // CAR INSTANCE ARGUMENTS

        int year = _random.Next(1960, 2025);

        string serialNumber = GetSerialNumber(pattern);

        tempRandom = _random.Next(0, _records.Length);
        string brand = _records[tempRandom].BrandName;
        string model = _records[tempRandom].Models[_random.Next(0, _records[tempRandom].Models.Length)];

        KnownColor color = (KnownColor)_random.Next(85, 118);

        int price = _random.Next(5000, 150001);

        int maxFuelCapacity = _random.Next(20, 50);

        int currentFuel = _random.Next(0, (maxFuelCapacity + 1));

        int speedCoeficient = _random.Next(2, 11);

        TransportStatus status = (TransportStatus)_random.Next(pattern.StatusInitialIndex, pattern.StatusEndIndex);

        // ADD SOME RANDOMNESS FOR BIT-USE.
        bool isFitForUse;
        if (_random.Next(0, 2) == 1)
        {
            isFitForUse = true;
        }
        else
        {
            isFitForUse = false;
        }

        // ENGINE COMPONENT ARGUMENTS

        string serialNumberEngine = GetSerialNumber(pattern);

        int averageFuelConsumption = _random.Next(1, 10);

        FuelEngine fuel = (FuelEngine)_random.Next(11, 25);

        TypeEngine typeEngine = (TypeEngine)_random.Next(11, 22);

        int powerEngine = _random.Next(10, 21);

        ComponentStatus statusEngine = (ComponentStatus)_random.Next(pattern.EngineStatusInitialIndex, pattern.EngineStatusEndIndex);

        // TRANSMISSION COMPONENT ARGUMENTS

        string serialNumberTransmission = GetSerialNumber(pattern);

        TypeTransmission typeTransmission = (TypeTransmission)_random.Next(10, 14);

        int speedCount = _random.Next(2, 7);

        ComponentStatus statusTransmission = (ComponentStatus)_random.Next(pattern.TransmissionStatusInitialIndex, pattern.TransmissionStatusEndIndex);

        // INTERIOR COMPONENT ARGUMENTS

        KnownColor colorInterior = (KnownColor)_random.Next(118, 145);

        MaterialInterior materialInterior = (MaterialInterior)_random.Next(10, 16);

        ComponentStatus statusInterior = (ComponentStatus)_random.Next(pattern.InteriorStatusInitialIndex, pattern.InteriorStatusEndIndex);

        // WHEELS COMPONENT ARGUMENTS

        MaterialWheel materialWheels = (MaterialWheel)_random.Next(10, 19);

        int sizeWheels = _random.Next(8, 33);

        TypeTire tire = (TypeTire)_random.Next(10, 18);

        ComponentStatus statusWheels = (ComponentStatus)_random.Next(pattern.WheelsStatusInitialIndex, pattern.WheelsStatusEndIndex);

        // LIGHTS COMPONENT ARGUMENTS

        KnownColor colorLights = (KnownColor)_random.Next(30, 41);

        PowerComponent powerLights = (PowerComponent)_random.Next(10, 14);

        ComponentStatus statusLights = (ComponentStatus)_random.Next(pattern.LightsStatusInitialIndex, pattern.LightsStatusEndIndex);

        // SIGNAL COMPONENT ARGUMENTS

        PitchComponent pitch = (PitchComponent)_random.Next(11, 15);

        ComponentStatus statusSignal = (ComponentStatus)_random.Next(pattern.SignalStatusInitialIndex, pattern.SignalStatusEndIndex);

        // RECORD ARGUMENTS

        string recordId = DateTime.Now.ToString() + brand.ToUpper() + model.ToUpper();

        string numberPlate = serialNumber.Substring(10, 8).Insert(2, "-").Insert(7, "-");

        string recordCreationDate = DateTime.Now.Date.ToString();

        string technicalInfo = $"Brand = {brand} |\nModel = {model} |\nEngine = {typeEngine} HP {powerEngine} fuel {fuel}({averageFuelConsumption}/hour) |\nTransmmission = {typeTransmission} {speedCount} speeds |\nWheels = {sizeWheels} inch {materialWheels} tire {tire} |\nInterior = {materialInterior} {colorInterior} | Color = {color} | VinCode = {serialNumber} | Preice = {price} | Is fit for use? = {isFitForUse} | Status = {status} }}";

        Car car = new Car
        (
            year,
            serialNumber,
            brand,
            model,
            color,
            price,
            maxFuelCapacity,
            currentFuel,
            speedCoeficient,
            status,
            isFitForUse,
            serialNumberEngine,
            averageFuelConsumption,
            fuel,
            typeEngine,
            powerEngine,
            statusEngine,
            serialNumberTransmission,
            typeTransmission,
            speedCount,
            statusTransmission,
            colorInterior,
            materialInterior,
            statusInterior,
            materialWheels,
            sizeWheels,
            tire,
            statusWheels,
            colorLights,
            powerLights,
            statusLights,
            pitch,
            statusSignal,
            recordId,
            numberPlate,
            recordCreationDate,
            technicalInfo
        );

        return car;
    }

    //internal Car GetNewCar(int brandIndex, int modelIndex)
    //{
    //    string brand = _records[brandIndex].BrandName;
    //    string model = _records[brandIndex].Models[modelIndex];

    //    ICarSelectivePattern pattern = 

    //    return car;
    //}

    // TO GENERATE RANDOM NUMBER FROM CHAR-MAP OF A PATTERN.
    private string GetSerialNumber(ICarSelectivePattern pattern)
    {
        snStringBuilder.Clear();    // TO CLEAR PREVIOUS SN.

        for (int index = 0; index < 33; index = index + 1)
        {
            snStringBuilder.Append(pattern.charMap[_random.Next(0, pattern.charMap.Length)]);
        }

        return snStringBuilder.ToString();
    }
}
