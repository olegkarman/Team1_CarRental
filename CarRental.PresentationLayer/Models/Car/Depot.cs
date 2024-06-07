using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Data.Models.Car;

public class Depot
{
    // CLASS RESPONSIBILITY:
    // TO CREATE A CAR-CLASS INSTANCE BASED ON PRE-DEFINED PATTERN
    //
    // OBJECT INITIALIZER USED INSTEAD OF CONSTRUCTORS DUE TO LARGE AMMOUNT OF init-setter PROPERTIES AND AN ADVICE OF THE TEACHER ABOUT DO NOT USE LARGE CONSTRUCTORS.

    // FIELDS

    private StringBuilder _snStringBuilder;
    private Random _random;

    // CONSTRUCTORS

    public Depot()
    {
        this._random = new Random();
        this._snStringBuilder = new StringBuilder();
    }

    // MEHODS

    // TO SELECT A PATTERN ON WHICH CAR-INSTANCE GENERATES.
    public ModelComponentsPattern SelectCarComplectationPattern(Dictionary<string, ModelComponentsPattern> patterns)
    {
        string[] models = patterns.Keys.ToArray();

        // SELECTS AT PSEUDO-RANDOM A MODEL.
        string model = models[_random.Next(0, models.Length)];

        ModelComponentsPattern pattern = patterns[model];
        
        return pattern;
    }

    // SELECT PATTERN FROM A SPECIFIC MODEL.
    public ModelComponentsPattern SelectCarComplectationPattern(Dictionary<string, ModelComponentsPattern> patterns, string model)
    {
        ModelComponentsPattern pattern = patterns[model];

        return pattern;
    }

    public Car ObtainNewCar(ModelComponentsPattern pattern)
    {
        string carCode = GetSerialNumber(pattern);
        int yearToSet = _random.Next(1960, 2025);
        Guid carGuid = Guid.NewGuid();
        int price = _random.Next(pattern.General.PriceCarInitial, pattern.General.PriceCarEnd);
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
            // CAR INSTANCE ARGUMENTS

            Year = yearToSet,
            
            VinCode = carCode,

            Mileage = 100,
            CurrentFuel = _random.Next(pattern.General.CurrentFuelInitial/2, pattern.General.CurrentFuelEnd),
            MaxFuelCapacity = _random.Next(pattern.General.MaxFuelCapacityInitial, pattern.General.MaxFuelCapacityEnd),
            SpeedCoeficient = _random.Next(pattern.General.SpeedCoeficientInitial, pattern.General.SpeedCoeficientEnd),
            Color = (KnownColor)_random.Next(pattern.General.ColorCarInitial, pattern.General.ColorCarEnd),
            Price = price,
            Model = pattern.Model,
            Brand = pattern.Brand,
            Status = (TransportStatus)_random.Next(pattern.General.StatusInitialIndex, pattern.General.StatusEndIndex),
            CarId = carGuid,
            IsFitForUse = isFitForUse,

            Engine = new Engine
            {
                SerialNumber = GetSerialNumber(pattern),
                AverageFuelConsumption = _random.Next(pattern.Engine.AverageFuelConsumptionInitial, pattern.Engine.AverageFuelConsumptionEnd),
                Fuel = (FuelEngine)_random.Next(pattern.Engine.FuelInitial, pattern.Engine.FuelEnd),
                Type = (TypeEngine)_random.Next(pattern.Engine.TypeEngineInitial, pattern.Engine.TypeEngineEnd),
                Power = _random.Next(pattern.Engine.PowerEngineInitial, pattern.Engine.PowerEngineEnd),
                Status = (ComponentStatus)_random.Next(pattern.Engine.EngineStatusInitialIndex, pattern.Engine.EngineStatusEndIndex)
            },

            Transmission = new Transmission
            {
                SerialNumber = GetSerialNumber(pattern),
                Type = (TypeTransmission)_random.Next(pattern.Transmission.TypeTransmissionInitial, pattern.Transmission.TypeTransmissionEnd),
                SpeedCount = _random.Next(pattern.Transmission.SpeedCountInitial, pattern.Transmission.SpeedCountEnd),
                Status = (ComponentStatus)_random.Next(pattern.Transmission.TransmissionStatusInitialIndex, pattern.Transmission.TransmissionStatusEndIndex)
            },

            Interior = new Interior
            {
                SerialNumber = GetSerialNumber(pattern),
                Color = (KnownColor)_random.Next(pattern.Interior.ColorInteriorInitial, pattern.Interior.ColorInteriorEnd),
                Material = (MaterialInterior)_random.Next(pattern.Interior.MaterialInteriorInitial, pattern.Interior.MaterialInteriorEnd),
                Status = (ComponentStatus)_random.Next(pattern.Interior.InteriorStatusInitialIndex, pattern.Interior.InteriorStatusEndIndex)
            },

            Wheels = new Wheels
            {
                SerialNumber = GetSerialNumber(pattern),
                Material = (MaterialWheel)_random.Next(pattern.Wheels.MaterialWheelsInitial, pattern.Wheels.MaterialWheelsEnd),
                Size = _random.Next(pattern.Wheels.SizeWheelsInitial, pattern.Wheels.SizeWheelsEnd),
                Tire = (TypeTire)_random.Next(pattern.Wheels.TireInitial, pattern.Wheels.TireEnd),
                Status = (ComponentStatus)_random.Next(pattern.Wheels.WheelsStatusInitialIndex, pattern.Wheels.WheelsStatusEndIndex)
            },

            Lights = new Lights
            {
                SerialNumber = GetSerialNumber(pattern),
                Color = (KnownColor)_random.Next(pattern.Lights.ColorLightsInitial, pattern.Lights.ColorLightsEnd),
                Power = (PowerComponent)_random.Next(pattern.Lights.PowerLightsInitial, pattern.Lights.PowerLightsEnd),
                Status = (ComponentStatus)_random.Next(pattern.Lights.LightsStatusInitialIndex, pattern.Lights.LightsStatusEndIndex)
            },

            Signal = new Signal
            {
                SerialNumber = GetSerialNumber(pattern),
                Pitch = (PitchComponent)_random.Next(pattern.Signal.PitchInitial, pattern.Signal.PitchEnd),
                Status = (ComponentStatus)_random.Next(pattern.Signal.SignalStatusInitialIndex, pattern.Signal.SignalStatusEndIndex)
            },

            Dossier = new Dossier
            {
                DossierId = GetSerialNumber(pattern),
                VinCode = carCode,
                BrandName = pattern.Brand,
                ModelName = pattern.Name,
                Year = yearToSet,
                NumberPlate = GetSerialNumber(pattern).Substring(0, 9).Insert(2, "-").Insert(8, "-"),
                DossierCreationDate = DateTime.Now.ToString(),
                Price = price,
                uiD = carGuid
            }

        };

        car.Dossier.TechnicalInfo = car.ToString();

        return car;
    }

    // TO GENERATE RANDOM NUMBER FROM CHAR-MAP OF A PATTERN.
    private string GetSerialNumber(ICarSelectivePattern pattern)
    {
        _snStringBuilder.Clear();

        for (int index = 0; index < 33; index = index + 1)
        {
            _snStringBuilder.Append(pattern.charMap[_random.Next(0, pattern.charMap.Length)]);
        }

        return _snStringBuilder.ToString();
    }
}
