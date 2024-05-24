using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class PegoutRecord : ICarRecordable
{
    public string name = "Pegout";
    public string[] models = ["Peg1", "Peg2", "Peg3"];
}
