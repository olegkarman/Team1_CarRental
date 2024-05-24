using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;

namespace CarRental.Models.Car;

public class WYCDepot
{
    // FIELDS

    private StringBuilder snStringBuilder = new StringBuilder();
    private Random _random = new Random();
    // AN ARRAY OF CHARACTERS TO GENERATE PSEUDO-RANDOM STRINGS AND AN ARRAY OF RECORDS.
    private readonly ICarRecordable[] _records = [ new ZaporoghetsRecord(), new VolkswagenRecord(), new PegoutRecord(), new NissanRecord(), new JeepRecord() ];
    private readonly char[] _charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    // MEHODS

    internal Car GetNewCar()
    {
        int tempRandom;

        // CAR INSTANCE ARGUMENTS

        int year = _random.Next(1960, 2025);

        // GENERATE 32TH SIGN SERIAL NUMBER.
        for (int index = 0; index < 33; index = index + 1)
        {
            snStringBuilder.Append(_charMap[_random.Next(0, _charMap.Length)]);
        }

        string serialNumber = snStringBuilder.ToString();

        tempRandom = _random.Next(0, _records.Length);
        string brand = _records[tempRandom].BrandName;
        string model = _records[tempRandom].Models[_random.Next(0, _records[tempRandom].Models.Length)]; // CHANGE AFTER FILL RECORDS.

        KnownColor color = (KnownColor)_random.Next(85, 118);

        int price = _random.Next(5000, 150001);

        int maxFuelCapacity = _random.Next(20, 50);

        int currentFuel = _random.Next(0, (maxFuelCapacity + 1));

        int speedCoeficient = _random.Next(2, 11);

        TransportStatus status = (TransportStatus)_random.Next(1, 5);

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

        snStringBuilder.Clear();    // TO CLEAR PREVIOUS SN.

        for (int index = 0; index < 33; index = index + 1)
        {
            snStringBuilder.Append(_charMap[_random.Next(0, _charMap.Length)]);
        }

        string serialNumberEngine = snStringBuilder.ToString();

        int averageFuelConsumption = _random.Next(1, 10);

        FuelEngine fuel = (FuelEngine)_random.Next(11, 25);

        TypeEngine typeEngine = (TypeEngine)_random.Next(11, 22);

        int powerEngine = _random.Next(10, 21);

        ComponentStatus statusEngine = (ComponentStatus)_random.Next(10, 13);

        // TRANSMISSION COMPONENT ARGUMENTS

        snStringBuilder.Clear();

        for (int index = 0; index < 33; index = index + 1)
        {
            snStringBuilder.Append(_charMap[_random.Next(0, _charMap.Length)]);
        }

        string serialNumberTransmission = snStringBuilder.ToString();

        TypeTransmission typeTransmission = (TypeTransmission)_random.Next(10, 14);

        int speedCount = _random.Next(2, 7);

        ComponentStatus statusTransmission = (ComponentStatus)_random.Next(10, 13);

        // INTERIOR COMPONENT ARGUMENTS

        KnownColor colorInterior = (KnownColor)_random.Next(118, 145);

        MaterialInterior materialInterior = (MaterialInterior)_random.Next(10, 16);

        ComponentStatus statusInterior = (ComponentStatus)_random.Next(10, 13);

        // WHEELS COMPONENT ARGUMENTS

        MaterialWheel materialWheels = (MaterialWheel)_random.Next(10, 19);

        int sizeWheels = _random.Next(8, 33);

        TypeTire tire = (TypeTire)_random.Next(10, 18);

        ComponentStatus statusWheels = (ComponentStatus)_random.Next(10, 13);

        // LIGHTS COMPONENT ARGUMENTS

        KnownColor colorLights = (KnownColor)_random.Next(30, 41);

        PowerComponent powerLights = (PowerComponent)_random.Next(10, 14);

        ComponentStatus statusLights = (ComponentStatus)_random.Next(10, 13);

        // SIGNAL COMPONENT ARGUMENTS

        PitchComponent pitch = (PitchComponent)_random.Next(11, 15);

        ComponentStatus statusSignal = (ComponentStatus)_random.Next(10, 13);

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
            statusSignal
        );

        return car;
    }
}
