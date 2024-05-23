using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

    // IF ENGINE IS DIFFERENT TYPE, CHANGE IS IMPOSSIBLE.
    public bool TryReplaceComponent (Car car, CarEngine engine)
    {
        if (car.Engine.Type.Equals(engine.Type))
        {
            car.Engine = engine;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool TryReplaceComponent(Car car, CarTransmission transmission)
    {
        if (car.Transmission.Type.Equals(transmission.Type))
        {
            car.Transmission = transmission;
            return true;
        }
        else
        {
            return false;
        }
    }

    // TO CHANGE INTERIOR IS ALWAYS AVAILABLE.
    public bool TryReplaceComponent(Car car, CarInterior interior)
    {
            car.Interior = interior;
            return true;
    }

    // CHECK SIZE, IF EQUAL, REPLACE.
    public bool TryReplaceComponent(Car car, CarWheels wheels)
    {
        if (car.Wheels.Size.Equals(wheels.Size))
        {
            car.Wheels = wheels;
            return true;
        }
        else
        {
            return false;
        }
    }

    // CHANGE TIRE OF A CAR.
    public bool TryReplaceComponent(Car car, TypeTire tire)
    {
        car.Wheels.Tire = tire;
        return true;
    }
}
