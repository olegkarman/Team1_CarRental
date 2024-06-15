using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;

namespace CarRental.Data.Interfaces;

public interface ICar
{
    public Engine Engine { get; set; }
    public Interior Interior { get; set; }
    public Wheels Wheels { get; set; }
    public Transmission Transmission { get; set; }
}
