using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarMechanic : ICarMechanics, IDriveable
{
    // METHODS

    public void Drive(int maxSpeed, out int averageSpeed, out int drivingTime)
    {
        Random random = new Random();   // RANDOMNESS.

        averageSpeed = maxSpeed / 2;
        drivingTime = random.Next(0, 100);
    }
}
