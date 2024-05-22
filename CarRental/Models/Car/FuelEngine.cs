using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal enum FuelEngine
{
    unknown = 0,
    diselBio = 10,
    diselSynthetic = 20,
    diselPetroleum = 30,
    typicalTwoStroke = 70,
    eGasoline = 85,
    regular = 90,
    shellSuper = 92,
    euroSuper = 95,
    iesPlus = 98,
    nitroPlus = 99,
    superPlus = 100,
    marcoPetroli = 101,
    ultimate = 102,
    electricity = 200
}
