using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Enumerables;
using CarRental.Interfaces;
//using System.Reflection;
//using System.Diagnostics;
//using System.Reflection;

namespace CarRental.Models.Car;

public class Depot
{
    // CLASS RESPONSIBILITY:
    // TO CREATE A CAR-CLASS INSTANCE BASED ON PRE-DEFINED PATTERN
    //
    // OBJECT INITIALIZER USED INSTEAD OF CONSTRUCTORS DUE TO LARGE AMMOUNT OF init-setter PROPERTIES AND AN ADVICE OF THE TEACHER ABOUT DO NOT USE LARGE CONSTRUCTORS.

    // FIELDS

    private StringBuilder _snStringBuilder;
    private Random _random;

    public Depot()
    {
        this._random = new Random();
        this._snStringBuilder = new StringBuilder();
    }

    // MEHODS

    // TO SELECT A PATTERN ON WHICH CAR-INSTANCE GENERATES.
    public CarSelectPattern SelectCarComplectationPattern(Dictionary<string, CarSelectPattern> patterns)
    {
        string[] models = patterns.Keys.ToArray();

        // SELECTS AT PSEUDO-RANDOM A MODEL.
        string model = models[_random.Next(0, models.Length)];

        CarSelectPattern pattern = patterns[model];
        
        return pattern;
    }

    // SELECT PATTERN FROM A SPECIFIC MODEL.
    public CarSelectPattern SelectCarComplectationPattern(Dictionary<string, CarSelectPattern> patterns, string model)
    {
        CarSelectPattern pattern = patterns[model];

        return pattern;
    }

    internal Car GetNewCar(CarSelectPattern pattern)
    {
        string carCode = GetSerialNumber(pattern);
        int yearToSet = _random.Next(1960, 2025);
        int price = _random.Next(pattern.PriceCarInitial, pattern.PriceCarEnd);
        bool isFitForUse;
        //IS FIT FOR USE. NOT ALL CARS ARE READY TO USE.
        if (_random.Next(1, 11) > 4)
        {
            isFitForUse = true;
        }
        else
        {
            isFitForUse = false;
        }

        Car car = new Car
        {
            //ICarSelectivePattern pattern = this.defaultPattern;

            // CAR INSTANCE ARGUMENTS

            Year = yearToSet,

            VinCode = carCode,

            Mileage = 100,   // AVTOPROBIG FOR NEW CARS.
            CurrentFuel = _random.Next(pattern.CurrentFuelInitial, pattern.CurrentFuelEnd),
            MaxFuelCapacity = _random.Next(pattern.MaxFuelCapacityInitial, pattern.MaxFuelCapacityEnd),
            SpeedCoeficient = _random.Next(pattern.SpeedCoeficientInitial, pattern.SpeedCoeficientEnd),
            Color = (KnownColor)_random.Next(pattern.ColorCarInitial, pattern.ColorCarEnd),
            Price = price,
            Model = pattern.Model,
            Brand = pattern.Brand,
            Status = (TransportStatus)_random.Next(pattern.StatusInitialIndex, pattern.StatusEndIndex),
            IsFitForUse = isFitForUse,

            // ENGINE
            Engine = new CarEngine
            {
                SerialNumber = GetSerialNumber(pattern),
                AverageFuelConsumption = _random.Next(pattern.AverageFuelConsumptionInitial, pattern.AverageFuelConsumptionEnd),
                Fuel = (FuelEngine)_random.Next(pattern.FuelInitial, pattern.FuelEnd),
                Type = (TypeEngine)_random.Next(pattern.TypeEngineInitial, pattern.TypeEngineEnd),
                Power = _random.Next(pattern.PowerEngineInitial, pattern.PowerEngineEnd),
                Status = (ComponentStatus)_random.Next(pattern.EngineStatusInitialIndex, pattern.EngineStatusEndIndex)
            },

            // TRANSMISSION
            Transmission = new CarTransmission
            {
                SerialNumber = GetSerialNumber(pattern),
                Type = (TypeTransmission)_random.Next(pattern.TypeTransmissionInitial, pattern.TypeTransmissionEnd),
                SpeedCount = _random.Next(pattern.SpeedCountInitial, pattern.SpeedCountEnd),
                Status = (ComponentStatus)_random.Next(pattern.TransmissionStatusInitialIndex, pattern.TransmissionStatusEndIndex)
            },

            // INTERIOR
            Interior = new CarInterior
            {
                Color = (KnownColor)_random.Next(pattern.ColorInteriorInitial, pattern.ColorInteriorEnd),
                Material = (MaterialInterior)_random.Next(pattern.MaterialInteriorInitial, pattern.MaterialInteriorEnd),
                Status = (ComponentStatus)_random.Next(pattern.InteriorStatusInitialIndex, pattern.InteriorStatusEndIndex)
            },

            // WHEELS
            Wheels = new CarWheels
            {
                Material = (MaterialWheel)_random.Next(pattern.MaterialWheelsInitial, pattern.MaterialWheelsEnd),
                Size = _random.Next(pattern.SizeWheelsInitial, pattern.SizeWheelsEnd),
                Tire = (TypeTire)_random.Next(pattern.TireInitial, pattern.TireEnd),
                Status = (ComponentStatus)_random.Next(pattern.WheelsStatusInitialIndex, pattern.WheelsStatusEndIndex)
            },

            // LIGHTS
            Lights = new CarLights
            {
                Color = (KnownColor)_random.Next(pattern.ColorLightsInitial, pattern.ColorLightsEnd),
                Power = (PowerComponent)_random.Next(pattern.PowerLightsInitial, pattern.PowerLightsEnd),
                Status = (ComponentStatus)_random.Next(pattern.LightsStatusInitialIndex, pattern.LightsStatusEndIndex)
            },

            // SIGNAL
            Signal = new CarSignal
            {
                Pitch = (PitchComponent)_random.Next(pattern.PitchInitial, pattern.PitchEnd),
                Status = (ComponentStatus)_random.Next(pattern.SignalStatusInitialIndex, pattern.SignalStatusEndIndex)
            },

            Record = new CarRecord
            {
                RecordId = GetSerialNumber(pattern),
                VinCode = carCode,
                BrandName = pattern.Brand,
                ModelName = pattern.Name,
                Year = yearToSet,
                NumberPlate = GetSerialNumber(pattern).Substring(0, 9).Insert(2, "-").Insert(8, "-"),
                RecordCreationDate = DateTime.Now.ToString(),
                Price = price
            }

        };

        car.Record.TechnicalInfo = car.ToString();

        return car;
    }

    // TO GENERATE RANDOM NUMBER FROM CHAR-MAP OF A PATTERN.
    private string GetSerialNumber(ICarSelectivePattern pattern)
    {
        _snStringBuilder.Clear();    // TO CLEAR PREVIOUS SN.

        for (int index = 0; index < 33; index = index + 1)
        {
            _snStringBuilder.Append(pattern.charMap[_random.Next(0, pattern.charMap.Length)]);
        }

        return _snStringBuilder.ToString();
    }
}
