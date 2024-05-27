using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Car;

namespace CarRental.Interfaces;

public interface ICanDrive
{
    internal bool LetsDrive(Car car);
}
