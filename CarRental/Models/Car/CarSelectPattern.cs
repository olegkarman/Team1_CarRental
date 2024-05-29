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
    // THE PURPOSE OF THE CLASS:
    // // A DATA-HOLDER OF A PATTERN NECCESSARY TO GENERATE A CAR INSTANCE.
    
    // FIELDS

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
    public int AverageFuelConsumptionInitial { get; init; }
    public int AverageFuelConsumptionEnd { get; init; }
    public int FuelInitial { get; init; }
    public int FuelEnd { get; init; }
    public int TypeEngineInitial { get; init; }
    public int TypeEngineEnd { get; init; }
    public int PowerEngineInitial { get; init; }
    public int PowerEngineEnd { get; init; }

    // TRANSMISSION SECTION
    public int TypeTransmissionInitial { get; init; }
    public int TypeTransmissionEnd { get; init; }
    public int SpeedCountInitial { get; init; }
    public int SpeedCountEnd { get; init; }

    // INTERIOR SECTION
    public int ColorInteriorInitial { get; init; }
    public int ColorInteriorEnd { get; init; }
    public int MaterialInteriorInitial { get; init; }
    public int MaterialInteriorEnd { get; init; }

    // WHEELS SECTION
    public int MaterialWheelsInitial { get; init; }
    public int MaterialWheelsEnd { get; init; }
    public int SizeWheelsInitial { get; init; }
    public int SizeWheelsEnd { get; init; }
    public int TireInitial { get; init; }
    public int TireEnd { get; init; }

    // LIGHTS SECTION
    public int ColorLightsInitial { get; init; }
    public int ColorLightsEnd { get; init; }
    public int PowerLightsInitial { get; init; }
    public int PowerLightsEnd { get; init; }

    // SIGNAL SECTION
    public int PitchInitial { get; init; }
    public int PitchEnd { get; init; }

    // CAR-RECORD SECTION


    // PROPERTIES

    public string Name { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }

    // CONSTRUCTORS

    public CarSelectPattern()
    {
        this.charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    }
}
