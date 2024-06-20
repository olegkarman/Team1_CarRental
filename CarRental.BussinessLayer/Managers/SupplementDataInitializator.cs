using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;
using CarRental.Data.Models.Car.RecordTypes;
using CarRental.BussinessLayer.Validators;

namespace CarRental.BussinessLayer.Managers;

public class SupplementDataInitializator
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS METHOD OF DATA-CLASSES INITIALIZATION.

    // METHODS

    public RepairServiceManager InitializeMechanic()
    {
        try
        {
            //Random random = new Random();

            return new RepairServiceManager(/*$"{random.Next(19, 1000001)}{random.Next('A', 'Z')}", (NamesSurenames)random.Next(10, 18), (NamesSurenames)random.Next(10, 18)*/);
        }
        catch(InvalidCastException exception)
        {
            throw exception;
        }
        catch
        {
            throw new Exception();
        }
    }

    public VehicleValidation InitializeValidator()
    {
        return new VehicleValidation();
    }

    public PatternCharMaps InitializeCharacterMaps()
    {
        return new PatternCharMaps();
    }
}