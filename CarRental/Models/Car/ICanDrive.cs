using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public interface ICanDrive
{
    internal bool LetsDrive(Car car);
}
