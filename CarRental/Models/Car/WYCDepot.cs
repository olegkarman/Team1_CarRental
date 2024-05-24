using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public class WYCDepot
{
    // FIELDS

    private Random _random;
    private readonly ICarRecordable[] _records = [ new ZaporoghetsRecord(), new VolkswagenRecord(), new PegoutRecord(), new NissanRecord(), new JeepRecord() ];

    // MEHODS

    internal Car GetNewCar()
    {
        _random = new Random();
         
    }
}
