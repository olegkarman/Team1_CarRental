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
    // CLASS RESPONSIBILITY:
    // TO CREATE A CAR BASED ON PRE-DEFINED PATTERN

    // FIELDS

    // LET ASSUME IT IS OUR DATA FROM ~DATA BASE~, AND WE NEED TO INSTANTINIZE CLASS-DATA-HOLDER FROM IT.

    private string[] _brandNames = ["Zaporozhets", "Peugeot", "Volkswagen", "Nissan", "Gyguli", "Jeep"];
    private string[] _modelNames =
    [
        // 0 — ZAP [0, 2]
        "ZAZ-966V", "ZAZ-965", "ZAZ-968",

        // 1 — PEG [3, 13]
        "Peugeot-204", "Peugeot-J7", "Peugeot-305", "Peugeot-J9", "Peugeot-P4", "Peugeot-406", "Peugeot-6007", "Peugeot-107", "Peugeot-908", "Bipper", "Peugeot-108",

        // 2 — VOL [14, 24]
        "Golf", "Passat", "Polo", "Jetta", "Multivan", "Bora", "Touareg", "Touran", "Caddy Life", "Lamando", "ID.3",

        // 3 — NIS [25, 35]
        "Patrol", "Skyline", "GT-R", "Serena", "Altima", "V-Drive", "Elgrand", "Sylphy", "X-Trail", "Murano", "Qashqai",

        // 4 — GYG [26, 42]
        "VAZ-2101", "VAZ-2102", "VAZ-2103", "VAZ-2106", "VAZ-2105", "VAZ-2107", "VAZ-2104",

        // 5 — JEP [43, 52]
        "Dakar", "Rubicon", "Malibu", "Wide-Trac", "Cherokee", "Creep", "Cowboy", "Freedom", "Wrangler", "Ecco"
    ];

    // FIELDS

    //private DateTime _dateTime;
    private StringBuilder snStringBuilder = new StringBuilder();
    private Random _random = new Random();
    // AN ARRAY OF CHARACTERS TO GENERATE PSEUDO-RANDOM STRINGS AND AN ARRAY OF RECORDS.
    private readonly IBrandRecordable[] _records;
    private readonly ICarSelectivePattern[] _patterns;
    private readonly ICarSelectivePattern defaultPattern;
    //private readonly char[] _charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    // CONSTRUCTORS

    public WYCDepot()
    {
        this._records =
        [
            // ZAPOROZHETS
            new BrandRecord
            (
                // ID
                (DateTime.Now.ToString() + _brandNames[0].ToUpper()),

                // ZAPOROZHETS
                _brandNames[0],

                // SELECTS PROPER NAMES FOR THE ARRAY AND COPY IT INTO AN ARRAY AND THEN INTO RECORD-CLASS.
                _modelNames[0..2]
            ),

            // PEUGEOT
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandNames[1].ToUpper()),

                _brandNames[1],

                _modelNames[3..13]
            ),

            // VOLKSWAGEN
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandNames[2].ToUpper()),

                _brandNames[2],

                _modelNames[14..24]
            ),

            // NISSAN
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandNames[3].ToUpper()),

                _brandNames[3],

                _modelNames[25..35]
            ),

            // GYGULI
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandNames[4].ToUpper()),

                _brandNames[4],

                _modelNames[26..42]
            ),

            // JEEP
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandNames[5].ToUpper()),

                _brandNames[5],

                _modelNames[43..52]
            )
        ];

        this._patterns =
        [
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

        this.defaultPattern = _patterns[1];
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

        ComponentStatus statusEngine = (ComponentStatus)_random.Next(10, 13);

        // TRANSMISSION COMPONENT ARGUMENTS

        string serialNumberTransmission = GetSerialNumber(pattern);

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
