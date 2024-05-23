using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal interface IDriveable
{
    public void Drive(int maxSpeed, out int averageSpeed, out int drivingTime);
}
