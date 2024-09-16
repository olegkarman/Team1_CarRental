using CarRental.BussinessLayer.Services;
using CarRental.BussinessLayer.Validators;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Managers;

public class ServiceManagerSupplements
{
    // FIELDS

    // PROPERTIES

    public RandomCarGeneration RandomCarGenerator { get; init; }
    public VehicleValidation Validator { get; init; }
    public IndexOfListValidation IndexValidator { get; init; }
    public PatternCharMapsDto CharMaps { get; init; }
    public MechanicManager MechanicalManager { get; init; }
    public RepairManager JunkRepairManager { get; init; }
    public NullValidation NullValidator { get; init; }
    public DatabaseContextDapper DataContext { get; init; }
    public DapperConfigurationManager DapperConfigs { get; init; }
    public FileDataManager FileContext { get; init; }
    public TextProcessingService TextProcessor { get; init; }
}
