using CarRental.BussinessLayer.Services;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Managers;

public class SupplementDataInitializator : IInitializator, IDisposable
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS METHOD OF DATA-CLASSES INITIALIZATION.

    // METHODS

    public TextProcessingService InitializeTextProcessing()
    {
        return new TextProcessingService();
    }

    public FileDataManager InitializeFileManagement()
    {
        return new FileDataManager();
    }

    public DapperConfigurationManager InitializeDapperConfigs()
    {
        return new DapperConfigurationManager();
    }

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

    public PatternCharMapsDto InitializeCharacterMaps()
    {
        return new PatternCharMapsDto();
    }

    public IRandomCarGeneration ConfigureRandomGeneration(IRandomCarGeneration generator)
    {
        generator.Models = 
        [
            "ZAZ-966V", "ZAZ-965", "ZAZ-968",

            "Peugeot-204", "Peugeot-J7", "Peugeot-305", "Peugeot-J9", "Peugeot-P4", "Peugeot-406", "Peugeot-6007", "Peugeot-107", "Peugeot-908", "Bipper", "Peugeot-108",

            "Golf", "Passat", "Polo", "Jetta", "Multivan", "Bora", "Touareg", "Touran", "Caddy Life", "Lamando", "ID.3",

            "Patrol", "Skyline", "GT-R", "Serena", "Altima", "V-Drive", "Elgrand", "Sylphy", "X-Trail", "Murano", "Qashqai",

            "VAZ-2101", "VAZ-2102", "VAZ-2103", "VAZ-2106", "VAZ-2105", "VAZ-2107", "VAZ-2104",

            "Dakar", "Rubicon", "Malibu", "Wide-Trac", "Cherokee", "Creep", "Cowboy", "Freedom", "Wrangler", "Ecco"
        ];

        generator.Brands = ["Zaporozhets", "Peugeot", "Volkswagen", "Nissan", "Gyguli", "Jeep"];

        generator.Engines = ["Unknown", "Inline", "TwoCylinderSimple", "ThreeCircleCylinders", "FourStandardCylinders", "FiveCylinders", "SixCylinders", "EightCylinders", "WingForm", "Electric", "Flat", "Rotary"];

        generator.Transmissions = ["Unknown", "Manual", "SemiAutomatic", "Automatic", "ContinuouslyVariable"];

        generator.Interiors = ["Unknown", "Metal", "Plastic", "Leather", "Carbon", "Wood", "Combined"];

        generator.Wheels = ["Unknown", "Steel", "Alloy", "SplitRims", "Chrome", "Forged", "CompositeAlloy", "Elastomer", "Magnessium", "PressedMetal"];

        generator.Lights = ["Unknown", "Weak", "Moderate", "Powerful", "Extreme"];

        generator.Signals = ["Unknown", "Low", "Moderate", "Hight", "ExtremelyHight"];

        return generator;
    }

    public RandomCarGeneration InitializeRandomCarGenerator()
    {
        var randomGenerator = new RandomCarGeneration
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
            PseudoRandom = new Random(),
            DataContext = new DatabaseContextDapper()
        };

        return mechanicManager;
    }

    public RepairManager InitializeRepair()
    {
        RepairManager repManager = new RepairManager
        {
            NullValidator = new NullValidation(),
            IndexValidator = new IndexOfListValidation(),
            DataContext = new DatabaseContextDapper(),

            Repairs = new List<Repair>()
        };

        return repManager;
    }

    public void Dispose()
    {
        // SOME LOGIC

        Console.WriteLine($"{this.GetType().Name} HAS BEEN DISPOSED!");
    }
}