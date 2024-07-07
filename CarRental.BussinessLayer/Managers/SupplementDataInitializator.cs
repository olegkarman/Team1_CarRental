using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Services;

namespace CarRental.BussinessLayer.Managers;

public class SupplementDataInitializator
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS METHOD OF DATA-CLASSES INITIALIZATION.

    // METHODS

    public DatabaseContextDapper InitializeDataContext()
    {
        return new DatabaseContextDapper();
    }

    public NullValidation InitializeNullValidator()
    {
        return new NullValidation();
    }

    public VehicleValidation InitializeValidator()
    {
        return new VehicleValidation();
    }

    public IndexOfListValidation InitializeIndexValidator()
    {
        return new IndexOfListValidation();
    }

    public PatternCharMaps InitializeCharacterMaps()
    {
        return new PatternCharMaps();
    }

    public RandomCarGeneration InitializeRandomCarGenerator()
    {
        RandomCarGeneration randomGenerator = new RandomCarGeneration
        {
            Models =
            [
                "ZAZ-966V", "ZAZ-965", "ZAZ-968",

                "Peugeot-204", "Peugeot-J7", "Peugeot-305", "Peugeot-J9", "Peugeot-P4", "Peugeot-406", "Peugeot-6007", "Peugeot-107", "Peugeot-908", "Bipper", "Peugeot-108",

                "Golf", "Passat", "Polo", "Jetta", "Multivan", "Bora", "Touareg", "Touran", "Caddy Life", "Lamando", "ID.3",

                "Patrol", "Skyline", "GT-R", "Serena", "Altima", "V-Drive", "Elgrand", "Sylphy", "X-Trail", "Murano", "Qashqai",

                "VAZ-2101", "VAZ-2102", "VAZ-2103", "VAZ-2106", "VAZ-2105", "VAZ-2107", "VAZ-2104",

                "Dakar", "Rubicon", "Malibu", "Wide-Trac", "Cherokee", "Creep", "Cowboy", "Freedom", "Wrangler", "Ecco"
            ],

            Brands = ["Zaporozhets", "Peugeot", "Volkswagen", "Nissan", "Gyguli", "Jeep"],

            Engines = ["Unknown", "Inline", "TwoCylinderSimple", "ThreeCircleCylinders", "FourStandardCylinders", "FiveCylinders", "SixCylinders", "EightCylinders", "WingForm", "Electric", "Flat", "Rotary"],

            Transmissions = ["Unknown", "Manual", "SemiAutomatic", "Automatic", "ContinuouslyVariable"],

            Interiors = ["Unknown", "Metal", "Plastic", "Leather", "Carbon", "Wood", "Combined"],

            Wheels = ["Unknown", "Steel", "Alloy", "SplitRims", "Chrome", "Forged", "CompositeAlloy", "Elastomer", "Magnessium", "PressedMetal"],

            Lights = ["Unknown", "Weak", "Moderate", "Powerful", "Extreme"],

            Signals = ["Unknown", "Low", "Moderate", "Hight", "ExtremelyHight"]

        };
        
        return randomGenerator;
    }

    public MechanicManager InitializeMechanization()
    {
        MechanicManager mechanicManager = new MechanicManager
        {
            Validator = new UpdatedNameValidator(),
            TextProcessor = new TextProcessingService(),
            AgeValidator = new AgeValidator(),
            NullValidator = new NullValidation(),
            IndexValidator = new IndexOfListValidation(),
            PseudoRandom = new Random()
        };

        return mechanicManager;
    }

    public RepairManager InitializeRepair()
    {
        RepairManager repManager = new RepairManager
        {
            NullValidator = new NullValidation(),
            IndexValidator = new IndexOfListValidation(),

            Repairs = new List<Repair>()
        };

        return repManager;
    }
}