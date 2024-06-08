using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Data.Enums;
using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Models.Car;
using CarRental.Data.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.BussinessLayer.Managers;

public class Mechanic : ICarMechanics
{
    // THE PURPOSE OF THE CLASS:
    // // TO PERFORM SPECIAL MANIPULATIONS ON A CAR.

    // FIELDS

    private const string _noInfo = "NO INFO";
    private Random _random;

    // PROPERTIES

    //public NamesSurenames FirstName { get; init; }
    //public string Id { get; init; }
    //public NamesSurenames LastName { get; init; }


    // CONSTRUCTORS

    public Mechanic()
    {
        this._random = new Random();
    }

    public float CheckFuel(Car car)
    {
        return car.CurrentFuel;
    }

    // TO REFILL

    public void Refill(Car car)
    {
        car.CurrentFuel = car.MaxFuelCapacity;
    }

    public bool LetsDrive(Car car)
    {
        return true;
    }

    // TO CHECK IF A COMPONENT OF A CAR IS NEED TO BE FIXED.
    public ComponentStatus CheckComponent(IComponent component)
    {
        return component.Status;
    }

    // CHECK A WHOLE CAR. COMPONENT BY COMPONENT.
    public TransportStatus CheckCar(Car car)
    {
        bool isNeedToBeFixed = ((car.Engine.Status == ComponentStatus.FixIsNeed) || (car.Engine.Status == ComponentStatus.Broken)) || ((car.Transmission.Status == ComponentStatus.FixIsNeed) || (car.Transmission.Status == ComponentStatus.Broken)) || ((car.Wheels.Status == ComponentStatus.FixIsNeed) || (car.Wheels.Status == ComponentStatus.Broken));

        // IF A CAR IS NEED A REPAIR, CHANGE ITS STATUS AND RETURN ONE.
        if (isNeedToBeFixed)
        {
            car.Status = TransportStatus.InRepair;
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

    // TO CHANGE COMPONENTS

    // IF ENGINE IS DIFFERENT TYPE, CHANGE IS IMPOSSIBLE.
    public bool TryReplaceComponent(Car car, Engine engine)
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

    public bool TryReplaceComponent(Car car, Transmission transmission)
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
    public bool TryReplaceComponent(Car car, Interior interior)
    {
        car.Interior = interior;
        return true;
    }

    // CHECK SIZE, IF EQUAL, REPLACE.
    public bool TryReplaceComponent(Car car, Wheels wheels)
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

    //CHANGE TIRE OF A CAR.
    public bool TryReplaceComponent(Car car, TypeTire tire)
    {
        car.Wheels.Tire = tire;
        return true;
    }
}
