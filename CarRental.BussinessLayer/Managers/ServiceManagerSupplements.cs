using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.BussinessLayer.Managers;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Services;

namespace CarRental.BussinessLayer.Managers;

public class ServiceManagerSupplements
{
    // FIELDS

    // PROPERTIES

    public RandomCarGeneration RandomCarGenerator { get; init; }
    public VehicleValidation Validator { get; init; }
    public IndexOfListValidation IndexValidator { get; init; }
    public PatternCharMaps CharMaps { get; init; }
    public MechanicManager MechanicalManager { get; init; }
    public RepairManager JunkRepairManager { get; init; }
    public NullValidation NullValidator { get; init; }
}
