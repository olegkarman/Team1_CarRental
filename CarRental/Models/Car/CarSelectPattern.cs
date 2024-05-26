using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarSelectPattern : ICarSelectivePattern
{
    // FIELDS

    // FOR DEFAULT CHARACTER MAP.
    private readonly char[] _charMapDefault = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

    public char[] charMap { get; init; }

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

    // PROPERTIES

    public string PatternName { get; init; }

    // CONSTRUCTORS

    public CarSelectPattern()
    {
        this.charMap = _charMapDefault;
        this.PatternName = "defaultPattern";

        this.StatusInitialIndex = 1;
        this.StatusEndIndex = 5;

        this.EngineStatusInitialIndex = 10;
        this.EngineStatusEndIndex = 13;

        this.TransmissionStatusInitialIndex = 10;
        this.TransmissionStatusEndIndex = 13;

        this.InteriorStatusInitialIndex = 10;
        this.InteriorStatusEndIndex = 13;

        this.WheelsStatusInitialIndex = 10;
        this.WheelsStatusEndIndex = 13;

        this.LightsStatusInitialIndex = 10;
        this.LightsStatusEndIndex = 13;

        this.SignalStatusInitialIndex = 10;
        this.SignalStatusEndIndex = 13;
    }

    public CarSelectPattern
    (
        string name,

        //int statusInitial,
        //int statusEnd,

        //int statusEngineInitial,
        //int statusEngineEnd,

        //int statusTransmissionInitial,
        //int statusTransmissionEnd,

        //int statusInteriorInitial,
        //int statusInteriorEnd,

        //int statusWheelsInitial,
        //int statusWheelsEnd,

        //int statusLightsInitial,
        //int statusLightsEnd,

        //int statusSignalInitial,
        //int statusSignalEnd

        params int[] indexes
    )
    {
        this.charMap = _charMapDefault;
        this.PatternName = name;

        //this.StatusInitialIndex = statusInitial;
        //this.StatusEndIndex = statusEnd;

        //this.EngineStatusInitialIndex = statusEngineInitial;
        //this.EngineStatusEndIndex = statusEngineEnd;

        //this.TransmissionStatusInitialIndex = statusTransmissionInitial;
        //this.TransmissionStatusEndIndex = statusTransmissionEnd;

        //this.InteriorStatusInitialIndex = statusInteriorInitial;
        //this.InteriorStatusEndIndex = statusInteriorEnd;

        //this.WheelsStatusInitialIndex = statusWheelsInitial;
        //this.WheelsStatusEndIndex = statusWheelsEnd;

        //this.LightsStatusInitialIndex = statusLightsInitial;
        //this.LightsStatusEndIndex = statusLightsEnd;

        //this.SignalStatusInitialIndex = statusSignalInitial;
        //this.SignalStatusEndIndex = statusSignalEnd;

        this.StatusInitialIndex = indexes[0];
        this.StatusEndIndex = indexes[1];

        this.EngineStatusInitialIndex = indexes[2];
        this.EngineStatusEndIndex = indexes[3];

        this.TransmissionStatusInitialIndex = indexes[4];
        this.TransmissionStatusEndIndex = indexes[5];

        this.InteriorStatusInitialIndex = indexes[6];
        this.InteriorStatusEndIndex = indexes[7];

        this.WheelsStatusInitialIndex = indexes[8];
        this.WheelsStatusEndIndex = indexes[9];

        this.LightsStatusInitialIndex = indexes[10];
        this.LightsStatusEndIndex = indexes[11];

        this.SignalStatusInitialIndex = indexes[12];
        this.SignalStatusEndIndex = indexes[13];
    }

    public CarSelectPattern
    (
        char[] chMap,

        string name,

        //int statusInitial,
        //int statusEnd,

        //int statusEngineInitial,
        //int statusEngineEnd,

        //int statusTransmissionInitial,
        //int statusTransmissionEnd,

        //int statusInteriorInitial,
        //int statusInteriorEnd,

        //int statusWheelsInitial,
        //int statusWheelsEnd,

        //int statusLightsInitial,
        //int statusLightsEnd,

        //int statusSignalInitial,
        //int statusSignalEnd

        params int[] indexes
    )
    {
        this.charMap = chMap;
        this.PatternName = name;

        //this.StatusInitialIndex = statusInitial;
        //this.StatusEndIndex = statusEnd;

        //this.EngineStatusInitialIndex = statusEngineInitial;
        //this.EngineStatusEndIndex = statusEngineEnd;

        //this.TransmissionStatusInitialIndex = statusTransmissionInitial;
        //this.TransmissionStatusEndIndex = statusTransmissionEnd;

        //this.InteriorStatusInitialIndex = statusInteriorInitial;
        //this.InteriorStatusEndIndex = statusInteriorEnd;

        //this.WheelsStatusInitialIndex = statusWheelsInitial;
        //this.WheelsStatusEndIndex = statusWheelsEnd;

        //this.LightsStatusInitialIndex = statusLightsInitial;
        //this.LightsStatusEndIndex = statusLightsEnd;

        //this.SignalStatusInitialIndex = statusSignalInitial;
        //this.SignalStatusEndIndex = statusSignalEnd;

        this.StatusInitialIndex = indexes[0];
        this.StatusEndIndex = indexes[1];

        this.EngineStatusInitialIndex = indexes[2];
        this.EngineStatusEndIndex = indexes[3];

        this.TransmissionStatusInitialIndex = indexes[4];
        this.TransmissionStatusEndIndex = indexes[5];

        this.InteriorStatusInitialIndex = indexes[6];
        this.InteriorStatusEndIndex = indexes[7];

        this.WheelsStatusInitialIndex = indexes[8];
        this.WheelsStatusEndIndex = indexes[9];

        this.LightsStatusInitialIndex = indexes[10];
        this.LightsStatusEndIndex = indexes[11];

        this.SignalStatusInitialIndex = indexes[12];
        this.SignalStatusEndIndex = indexes[13];
    }
}
