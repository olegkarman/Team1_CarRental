using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Models.Car.Seeds;

public class ModelComponentsPattern
{
    // THE PURPOSE OF THE CLASS:
    // // A DATA-HOLDER OF A PATTERN NECCESSARY TO GENERATE A CAR INSTANCE.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public string Name { get; init; }
    public string Brand { get; init; }
    public string Model { get; init; }

    public char[] charMap { get; init; }

    public GeneralModelPattern General { get; init; }
    public EnginePattern Engine { get; init; }
    public TransmissionPattern Transmission { get; init; }
    public InteriorPattern Interior { get; init; }
    public WheelsPattern Wheels { get; init; }
    public LightsPattern Lights { get; init; }
    public SignalPattern Signal { get; init; }

    // CONSTRUCTORS

    public ModelComponentsPattern()
    {
        charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
    }
}
