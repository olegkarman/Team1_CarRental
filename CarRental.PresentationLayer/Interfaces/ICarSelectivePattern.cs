using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;


// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Data.Interfaces;

public interface ICarSelectivePattern
{
    // PROPERTIES

    public char[] charMap { get; init; }

    public GeneralModelPattern General { get; init; }
    public EnginePattern Engine { get; init; }
    public TransmissionPattern Transmission { get; init; }
    public InteriorPattern Interior { get; init; }
    public WheelsPattern Wheels { get; init; }
    public LightsPattern Lights { get; init; }
    public SignalPattern Signal { get; init; }
}
