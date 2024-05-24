using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal record class JeepRecord : ICarRecordable
{
    public string brandName = "Jeep";
    public string[] models = ["Dakar", "Rubicon", "Malibu", "Wide-Trac", "Cherokee", "Creep", "Cowboy", "Freedom", "Wrangler", "Ecco"];
}
