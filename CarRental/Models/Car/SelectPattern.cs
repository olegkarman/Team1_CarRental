using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

public class SelectPattern : ICarSelectivePattern
{
    // THE PURPOSE OF THE CLASS:
    // // A DATA-HOLDER OF A PATTERN NECCESSARY TO GENERATE A CAR INSTANCE.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    #region PROPERTIES

    public Dictionary<string, int> Values
    {
        { "StatusInitialIndex              ", 0 },
        { "StatusEndIndex                  ", 0 },
        { "EngineStatusInitialIndex        ", 0 },
        { "EngineStatusEndIndex            ", 0 },
        { "TransmissionStatusInitialIndex  ", 0 },
        { "TransmissionStatusEndIndex      ", 0 },
        { "InteriorStatusInitialIndex      ", 0 },
        { "InteriorStatusEndIndex          ", 0 },
        { "WheelsStatusInitialIndex        ", 0 },
        { "WheelsStatusEndIndex            ", 0 },
        { "LightsStatusInitialIndex        ", 0 },
        { "LightsStatusEndIndex            ", 0 },
        { "SignalStatusInitialIndex        ", 0 },
        { "SignalStatusEndIndex            ", 0 },
        { "ColorCarInitial                 ", 0 },
        { "ColorCarEnd                     ", 0 },
        { "PriceCarInitial                 ", 0 },
        { "PriceCarEnd                     ", 0 },
        { "MaxFuelCapacityInitial          ", 0 },
        { "MaxFuelCapacityEnd              ", 0 },
        { "CurrentFuelInitial              ", 0 },
        { "CurrentFuelEnd                  ", 0 },
        { "SpeedCoeficientInitial          ", 0 },
        { "SpeedCoeficientEnd              ", 0 },
        { "AverageFuelConsumptionInitial   ", 0 },
        { "AverageFuelConsumptionEnd       ", 0 },
        { "FuelInitial                     ", 0 },
        { "FuelEnd                         ", 0 },
        { "TypeEngineInitial               ", 0 },
        { "TypeEngineEnd                   ", 0 },
        { "PowerEngineInitial              ", 0 },
        { "PowerEngineEnd                  ", 0 },
        { "TypeTransmissionInitial         ", 0 },
        { "TypeTransmissionEnd             ", 0 },
        { "SpeedCountInitial               ", 0 },
        { "SpeedCountEnd                   ", 0 },
        { "ColorInteriorInitial            ", 0 },
        { "ColorInteriorEnd                ", 0 },
        { "MaterialInteriorInitial         ", 0 },
        { "MaterialInteriorEnd             ", 0 },
        { "MaterialWheelsInitial           ", 0 },
        { "MaterialWheelsEnd               ", 0 },
        { "SizeWheelsInitial               ", 0 },
        { "SizeWheelsEnd                   ", 0 },
        { "TireInitial                     ", 0 },
        { "TireEnd                         ", 0 },
        { "ColorLightsInitial              ", 0 },
        { "ColorLightsEnd                  ", 0 },
        { "PowerLightsInitial              ", 0 },
        { "PowerLightsEnd                  ", 0 },
        { "PitchInitial                    ", 0 },
        { "PitchEnd                        ", 0 }
    }

    public char[] charMap { get; init; }

    //// STATUS S{ECTION
    //public int {"StatusInitialIndex              "}{ get; init; }
    //public int {"StatusEndIndex                  "}{ get; init; }
    //           {"                                "}
    //public int {"EngineStatusInitialIndex        "}{ get; init; }
    //public int {"EngineStatusEndIndex            "}{ get; init; }
    //           {"                                "}
    //public int {"TransmissionStatusInitialIndex  "}{ get; init; }
    //public int {"TransmissionStatusEndIndex      "}{ get; init; }
    //           {"                                "}
    //public int {"InteriorStatusInitialIndex      "}{ get; init; }
    //public int {"InteriorStatusEndIndex          "}{ get; init; }
    //           {"                                "}
    //public int {"WheelsStatusInitialIndex        "}{ get; init; }
    //public int {"WheelsStatusEndIndex            "}{ get; init; }
    //           {"                                "}
    //public int {"LightsStatusInitialIndex        "}{ get; init; }
    //public int {"LightsStatusEndIndex            "}{ get; init; }
    //           {"                                "}
    //public int {"SignalStatusInitialIndex        "}{ get; init; }
    //public int {"SignalStatusEndIndex            "}{ get; init; }
    //           {"                                "}
    //// CAR SECT{"ION INDEXES                     "}
    //public int {"ColorCarInitial                 "}{ get; init; }
    //public int {"ColorCarEnd                     "}{ get; init; }
    //public int {"PriceCarInitial                 "}{ get; init; }
    //public int {"PriceCarEnd                     "}{ get; init; }
    //public int {"MaxFuelCapacityInitial          "}{ get; init; }
    //public int {"MaxFuelCapacityEnd              "}{ get; init; }
    //public int {"CurrentFuelInitial              "}{ get; init; }
    //public int {"CurrentFuelEnd                  "}{ get; init; }
    //public int {"SpeedCoeficientInitial          "}{ get; init; }
    //public int {"SpeedCoeficientEnd              "}{ get; init; }
    //           {"                                "}
    //// ENGINE S{"ECTION INDEXES                  "}
    //public int {"AverageFuelConsumptionInitial   "}{ get; init; }
    //public int {"AverageFuelConsumptionEnd       "}{ get; init; }
    //public int {"FuelInitial                     "}{ get; init; }
    //public int {"FuelEnd                         "}{ get; init; }
    //public int {"TypeEngineInitial               "}{ get; init; }
    //public int {"TypeEngineEnd                   "}{ get; init; }
    //public int {"PowerEngineInitial              "}{ get; init; }
    //public int {"PowerEngineEnd                  "}{ get; init; }
    //           {"                                "}
    //// TRANSMIS{"SION SECTION                    "}
    //public int {"TypeTransmissionInitial         "}{ get; init; }
    //public int {"TypeTransmissionEnd             "}{ get; init; }
    //public int {"SpeedCountInitial               "}{ get; init; }
    //public int {"SpeedCountEnd                   "}{ get; init; }
    //           {"                                "}
    //// INTERIOR{" SECTION                        "}
    //public int {"ColorInteriorInitial            "}{ get; init; }
    //public int {"ColorInteriorEnd                "}{ get; init; }
    //public int {"MaterialInteriorInitial         "}{ get; init; }
    //public int {"MaterialInteriorEnd             "}{ get; init; }
    //           {"                                "}
    //// WHEELS S{"ECTION                          "}
    //public int {"MaterialWheelsInitial           "}{ get; init; }
    //public int {"MaterialWheelsEnd               "}{ get; init; }
    //public int {"SizeWheelsInitial               "}{ get; init; }
    //public int {"SizeWheelsEnd                   "}{ get; init; }
    //public int {"TireInitial                     "}{ get; init; }
    //public int {"TireEnd                         "}{ get; init; }
    //           {"                                "}
    //// LIGHTS S{"ECTION                          "}
    //public int {"ColorLightsInitial              "}{ get; init; }
    //public int {"ColorLightsEnd                  "}{ get; init; }
    //public int {"PowerLightsInitial              "}{ get; init; }
    //public int {"PowerLightsEnd                  "}{ get; init; }
    //           {"                                "}
    //// SIGNAL S{"ECTION                          "}
    //public int {"PitchInitial                    "}{ get; init; }
    //public int {"PitchEnd                        "}{ get; init; }
                                                
    //// CAR-RECORD SECTION                       
                                                
                                                
    // PROPERTIES                               
                                                
    public string Name                          { get; init; }
    public string Brand                         { get; init; }
    public string Model                         { get; init; }

    #endregion

    // CONSTRUCTORS

    public SelectPattern()
    {
        this.charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    }
}
