using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Enumerables;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

internal class CarMechanic : ICarMechanics, ICanDrive
{
    // THE PURPOSE OF THE CLASS:
    // // TO PERFORM SPECIAL MANIPULATIONS ON A CAR.

    // FIELDS

    private const string _noInfo = "NO INFO";
    public NamesSurenames FirstName { get; init; }
    public string Id { get; init; }
    public NamesSurenames LastName { get; init; }
    private Random _random;

    // CONSTRUCTORS

    internal CarMechanic(string id, NamesSurenames firstN, NamesSurenames lastN)
    {
        this.FirstName = firstN;
        this.LastName = lastN;
        this.Id = id;
        _random = new Random();
    }

    // METHODS

    public float CheckFuel(Car car)
    {
        return car.CurrentFuel;
    }

    public void Refill(Car car, int amountFuel)
    {
        car.CurrentFuel = amountFuel;
    }

    public bool LetsDrive(Car car)
    {
        float averageSpeed = (float)(car.MaxSpeed / 2);
        int drivingTime = _random.Next(0, 101);

        // THROW ITSELF AS ARGUMENT.
        return car.Drive(this, averageSpeed, drivingTime);
    }

    // TO CHECK IF A COMPONENT OF A CAR IS NEED TO BE FIXED.
    public ComponentStatus CheckComponent(IComponent component)
    {
        return component.Status;
    }

    // CHECK A WHOLE CAR. COMPONENT BY COMPONENT.
    public TransportStatus CheckCar(Car car)
    {
        bool isNeedToBeFixed = ((car.Engine.Status == ComponentStatus.fixIsNeed) || (car.Engine.Status == ComponentStatus.broken)) || ((car.Transmission.Status == ComponentStatus.fixIsNeed) || (car.Transmission.Status == ComponentStatus.broken)) || ((car.Wheels.Status == ComponentStatus.fixIsNeed) || (car.Wheels.Status == ComponentStatus.broken));

        // IF A CAR IS NEED A REPAIR, CHANGE ITS STATUS AND RETURN ONE.
        if (isNeedToBeFixed)
        {
            car.Status = TransportStatus.inRepair;
            return car.Status;
        }
        else
        {
            return car.Status;
        }
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

    // PAINT A CAR.
    public void Paint(Car car, KnownColor color)
    {
        car.Color = color;
    }

    // CHANGE TIRE OF A CAR.
    public bool TryReplaceComponent(Car car, TypeTire tire)
    {
        car.Wheels.Tire = tire;
        return true;
    }
}
