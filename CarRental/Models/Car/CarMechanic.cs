using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarMechanic : ICarMechanics, IDriveable
{
    // FIELDS

    private Random _random;

    // CONSTRUCTORS

    internal CarMechanic()
    {
        _random = new Random();
    }

    // METHODS

    public void Drive(int maxSpeed, out int averageSpeed, out int drivingTime)
    {
        averageSpeed = maxSpeed / 2;
        drivingTime = _random.Next(0, 101);
    }

    // METHOD TO FIX COMPONENTS.
    public bool TryFixComponent(IComponent component)
    {
        int success = _random.Next(0, 11);

        if (success >= 5)
        {
            component.Status = (ComponentStatus)10;
            return true;
        }
        else
        {
            return false;
        }
    }
}
