using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

public class CarSelectPattern : ICarSelectivePattern
{
    // FIELDS

    // FOR DEFAULT CHARACTER MAP.
    private readonly char[] _charMapDefault = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    private const string _noInfo = "NO INFO"; 

    // PROPERTIES

    public char[] charMap { get; init; }

    // STATUS SECTION
    public int StatusInitialIndex { get; init; }
    public int StatusEndIndex { get; init; }

    public int EngineStatusInitialIndex { get; init; }
    public int EngineStatusEndIndex { get; init; }

    public int TransmissionStatusInitialIndex { get; init; }
    public int TransmissionStatusEndIndex { get; init; }

    public int InteriorStatusInitialIndex { get; init; }
    public int InteriorStatusEndIndex { get; init; }

    public int WheelsStatusInitialIndex { get; init; }
    public int WheelsStatusEndIndex { get; init; }

    public int LightsStatusInitialIndex { get; init; }
    public int LightsStatusEndIndex { get; init; }

    public int SignalStatusInitialIndex { get; init; }
    public int SignalStatusEndIndex { get; init; }

    // CAR SECTION INDEXES
    public int ColorCarInitial { get; init; }
    public int ColorCarEnd { get; init; }
    public int PriceCarInitial { get; init; }
    public int PriceCarEnd { get; init; }
    public int MaxFuelCapacityInitial { get; init; }
    public int MaxFuelCapacityEnd { get; init; }
    public int CurrentFuelInitial { get; init; }
    public int CurrentFuelEnd { get; init; }
    public int SpeedCoeficientInitial { get; init; }
    public int SpeedCoeficientEnd { get; init; }

    // ENGINE SECTION INDEXES
    int AverageFuelConsumptionInitial { get; init; }
    int AverageFuelConsumptionEnd { get; init; }
    int FuelInitial { get; init; }
    int FuelEnd { get; init; }
    int TypeEngineInitial { get; init; }
    int TypeEngineEnd { get; init; }
    int powerEngineInitial { get; init; }
    int powerEngineEnd { get; init; }

    // TRANSMISSION SECTION
    int TypeTransmissionInitial { get; init; }
    int TypeTransmissionEnd { get; init; }
    int SpeedCountInitial { get; init; }
    int SpeedCountEnd { get; init; }

    // INTERIOR SECTION
    int ColorInteriorInitial { get; init; }
    int ColorInteriorEnd { get; init; }
    int MaterialInteriorInitial { get; init; }
    int MaterialInteriorEnd { get; init; }

    // WHEELS SECTION
    int MaterialWheelsInitial { get; init; }
    int MaterialWheelsEnd { get; init; }
    int SizeWheelsInitial { get; init; }
    int SizeWheelsEnd { get; init; }
    int TireInitial { get; init; }
    int TireEnd { get; init; }

    // LIGHTS SECTION
    int ColorLightsInitial { get; init; }
    int ColorLightsEnd { get; init; }
    int PowerLightsInitial { get; init; }
    int PowerLightsEnd { get; init; }

    // SIGNAL SECTION
    int PitchInitial { get; init; }
    int PitchEnd { get; init; }

    // CAR-RECORD SECTION


    // PROPERTIES

    public string Name { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }

    // CONSTRUCTORS

    public CarSelectPattern()
    {
        this.Name = _noInfo;
        this.Brand = _noInfo;
        this.Model = _noInfo;
    }

    public CarSelectPattern(string name, string brand, string model)
    {
        this.Name = name;
        this.Brand = brand;
        this.Model = model;
    }

    //public CarSelectPattern()
    //{
    //    this.charMap = _charMapDefault;
    //    this.Name = "defaultPattern";

    //    this.StatusInitialIndex = 1;
    //    this.StatusEndIndex = 5;

    //    this.EngineStatusInitialIndex = 10;
    //    this.EngineStatusEndIndex = 13;

    //    this.TransmissionStatusInitialIndex = 10;
    //    this.TransmissionStatusEndIndex = 13;

    //    this.InteriorStatusInitialIndex = 10;
    //    this.InteriorStatusEndIndex = 13;

    //    this.WheelsStatusInitialIndex = 10;
    //    this.WheelsStatusEndIndex = 13;

    //    this.LightsStatusInitialIndex = 10;
    //    this.LightsStatusEndIndex = 13;

    //    this.SignalStatusInitialIndex = 10;
    //    this.SignalStatusEndIndex = 13;
    //}

    //public CarSelectPattern
    //(
    //    string name,

    //    //int statusInitial,
    //    //int statusEnd,

    //    //int statusEngineInitial,
    //    //int statusEngineEnd,

    //    //int statusTransmissionInitial,
    //    //int statusTransmissionEnd,

    //    //int statusInteriorInitial,
    //    //int statusInteriorEnd,

    //    //int statusWheelsInitial,
    //    //int statusWheelsEnd,

    //    //int statusLightsInitial,
    //    //int statusLightsEnd,

    //    //int statusSignalInitial,
    //    //int statusSignalEnd

    //    params int[] indexes
    //)
    //{
    //    this.charMap = _charMapDefault;
    //    this.Name = name;

    //    //this.StatusInitialIndex = statusInitial;
    //    //this.StatusEndIndex = statusEnd;

    //    //this.EngineStatusInitialIndex = statusEngineInitial;
    //    //this.EngineStatusEndIndex = statusEngineEnd;

    //    //this.TransmissionStatusInitialIndex = statusTransmissionInitial;
    //    //this.TransmissionStatusEndIndex = statusTransmissionEnd;

    //    //this.InteriorStatusInitialIndex = statusInteriorInitial;
    //    //this.InteriorStatusEndIndex = statusInteriorEnd;

    //    //this.WheelsStatusInitialIndex = statusWheelsInitial;
    //    //this.WheelsStatusEndIndex = statusWheelsEnd;

    //    //this.LightsStatusInitialIndex = statusLightsInitial;
    //    //this.LightsStatusEndIndex = statusLightsEnd;

    //    //this.SignalStatusInitialIndex = statusSignalInitial;
    //    //this.SignalStatusEndIndex = statusSignalEnd;

    //    this.StatusInitialIndex = indexes[0];
    //    this.StatusEndIndex = indexes[1];

    //    this.EngineStatusInitialIndex = indexes[2];
    //    this.EngineStatusEndIndex = indexes[3];

    //    this.TransmissionStatusInitialIndex = indexes[4];
    //    this.TransmissionStatusEndIndex = indexes[5];

    //    this.InteriorStatusInitialIndex = indexes[6];
    //    this.InteriorStatusEndIndex = indexes[7];

    //    this.WheelsStatusInitialIndex = indexes[8];
    //    this.WheelsStatusEndIndex = indexes[9];

    //    this.LightsStatusInitialIndex = indexes[10];
    //    this.LightsStatusEndIndex = indexes[11];

    //    this.SignalStatusInitialIndex = indexes[12];
    //    this.SignalStatusEndIndex = indexes[13];
    //}

    //public CarSelectPattern
    //(
    //    char[] chMap,

    //    string name,

    //    //int statusInitial,
    //    //int statusEnd,

    //    //int statusEngineInitial,
    //    //int statusEngineEnd,

    //    //int statusTransmissionInitial,
    //    //int statusTransmissionEnd,

    //    //int statusInteriorInitial,
    //    //int statusInteriorEnd,

    //    //int statusWheelsInitial,
    //    //int statusWheelsEnd,

    //    //int statusLightsInitial,
    //    //int statusLightsEnd,

    //    //int statusSignalInitial,
    //    //int statusSignalEnd

    //    params int[] indexes
    //)
    //{
    //    this.charMap = chMap;
    //    this.Name = name;

    //    //this.StatusInitialIndex = statusInitial;
    //    //this.StatusEndIndex = statusEnd;

    //    //this.EngineStatusInitialIndex = statusEngineInitial;
    //    //this.EngineStatusEndIndex = statusEngineEnd;

    //    //this.TransmissionStatusInitialIndex = statusTransmissionInitial;
    //    //this.TransmissionStatusEndIndex = statusTransmissionEnd;

    //    //this.InteriorStatusInitialIndex = statusInteriorInitial;
    //    //this.InteriorStatusEndIndex = statusInteriorEnd;

    //    //this.WheelsStatusInitialIndex = statusWheelsInitial;
    //    //this.WheelsStatusEndIndex = statusWheelsEnd;

    //    //this.LightsStatusInitialIndex = statusLightsInitial;
    //    //this.LightsStatusEndIndex = statusLightsEnd;

    //    //this.SignalStatusInitialIndex = statusSignalInitial;
    //    //this.SignalStatusEndIndex = statusSignalEnd;

    //    this.StatusInitialIndex = indexes[0];
    //    this.StatusEndIndex = indexes[1];

    //    this.EngineStatusInitialIndex = indexes[2];
    //    this.EngineStatusEndIndex = indexes[3];

    //    this.TransmissionStatusInitialIndex = indexes[4];
    //    this.TransmissionStatusEndIndex = indexes[5];

    //    this.InteriorStatusInitialIndex = indexes[6];
    //    this.InteriorStatusEndIndex = indexes[7];

    //    this.WheelsStatusInitialIndex = indexes[8];
    //    this.WheelsStatusEndIndex = indexes[9];

    //    this.LightsStatusInitialIndex = indexes[10];
    //    this.LightsStatusEndIndex = indexes[11];

    //    this.SignalStatusInitialIndex = indexes[12];
    //    this.SignalStatusEndIndex = indexes[13];
    //}

    //    public CarSelectPattern
    //    (
    //       string name,

    //       string brandName,

    //       string modelName,

    //       //int statusInitial,
    //       //int statusEnd,

    //       //int statusEngineInitial,
    //       //int statusEngineEnd,

    //       //int statusTransmissionInitial,
    //       //int statusTransmissionEnd,

    //       //int statusInteriorInitial,
    //       //int statusInteriorEnd,

    //       //int statusWheelsInitial,
    //       //int statusWheelsEnd,

    //       //int statusLightsInitial,
    //       //int statusLightsEnd,

    //       //int statusSignalInitial,
    //       //int statusSignalEnd

    //       params int[] indexes
    //    )
    //    {
    //        this.charMap = _charMapDefault;
    //        this.Name = name;

    //        //this.StatusInitialIndex = statusInitial;
    //        //this.StatusEndIndex = statusEnd;

    //        //this.EngineStatusInitialIndex = statusEngineInitial;
    //        //this.EngineStatusEndIndex = statusEngineEnd;

    //        //this.TransmissionStatusInitialIndex = statusTransmissionInitial;
    //        //this.TransmissionStatusEndIndex = statusTransmissionEnd;

    //        //this.InteriorStatusInitialIndex = statusInteriorInitial;
    //        //this.InteriorStatusEndIndex = statusInteriorEnd;

    //        //this.WheelsStatusInitialIndex = statusWheelsInitial;
    //        //this.WheelsStatusEndIndex = statusWheelsEnd;

    //        //this.LightsStatusInitialIndex = statusLightsInitial;
    //        //this.LightsStatusEndIndex = statusLightsEnd;

    //        //this.SignalStatusInitialIndex = statusSignalInitial;
    //        //this.SignalStatusEndIndex = statusSignalEnd;

    //        this.StatusInitialIndex = indexes[0];
    //        this.StatusEndIndex = indexes[1];

    //        this.EngineStatusInitialIndex = indexes[2];
    //        this.EngineStatusEndIndex = indexes[3];

    //        this.TransmissionStatusInitialIndex = indexes[4];
    //        this.TransmissionStatusEndIndex = indexes[5];

    //        this.InteriorStatusInitialIndex = indexes[6];
    //        this.InteriorStatusEndIndex = indexes[7];

    //        this.WheelsStatusInitialIndex = indexes[8];
    //        this.WheelsStatusEndIndex = indexes[9];

    //        this.LightsStatusInitialIndex = indexes[10];
    //        this.LightsStatusEndIndex = indexes[11];

    //        this.SignalStatusInitialIndex = indexes[12];
    //        this.SignalStatusEndIndex = indexes[13];

    //        this.ColorCarInitial = indexes[14];
    //        this.ColorCarEnd = indexes[15];
    //        this.PriceCarInitial = indexes[16];
    //        this.PriceCarEnd = indexes[17];
    //        this.MaxFuelCapacityInitial = indexes[18];
    //        this.MaxFuelCapacityEnd = indexes[19];
    //        this.CurrentFuelInitial = indexes[20];
    //        this.CurrentFuelEnd = indexes[21];
    //        this.SpeedCoeficientInitial = indexes[22];
    //        this.SpeedCoeficientEnd = indexes[23];

    //        this.AverageFuelConsumptionInitial = indexes[24];
    //        this.AverageFuelConsumptionEnd = indexes[25];
    //        this.FuelInitial = indexes[26];
    //        this.FuelEnd = indexes[27];
    //        this.TypeEngineInitial = indexes[28];
    //        this.TypeEngineEnd = indexes[29];
    //        this.powerEngineInitial = indexes[30];
    //        this.powerEngineEnd = indexes[31];

    //        this.TypeTransmissionInitial = indexes[32];
    //        this.TypeTransmissionEnd = indexes[33];
    //        this.SpeedCountInitial = indexes[34];
    //        this.SpeedCountEnd = indexes[35];

    //        this.ColorInteriorInitial = indexes[36];
    //        this.ColorInteriorEnd = indexes[37];
    //        this.MaterialInteriorInitial = indexes[38];
    //        this.MaterialInteriorEnd = indexes[39];

    //        this.MaterialWheelsInitial = indexes[40];
    //        this.MaterialWheelsEnd = indexes[41];
    //        this.SizeWheelsInitial = indexes[42];
    //        this.SizeWheelsEnd = indexes[43];
    //        this.TireInitial = indexes[44];
    //        this.TireEnd = indexes[45];

    //        this.ColorLightsInitial = indexes[46];
    //        this.ColorLightsEnd = indexes[47];
    //        this.PowerLightsInitial = indexes[48];
    //        this.PowerLightsEnd = indexes[49];

    //        this.PitchInitial = indexes[50];
    //        this.PitchEnd = indexes[51];
    //    }
}
