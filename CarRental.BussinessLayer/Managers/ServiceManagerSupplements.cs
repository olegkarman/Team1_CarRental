using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;
using CarRental.Data.Models.Car.RecordTypes;
using CarRental.BussinessLayer.Managers;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Services;

namespace CarRental.BussinessLayer.Managers;

public class ServiceManagerSupplements
{
    // FIELDS

    // PROPERTIES
    internal RandomCarGeneration RandomCarGenerator { get; init; }
    internal VehicleValidation Validator { get; init; }
    //public RepairServiceManager Mechanic { get; init; }
    internal PatternCharMaps CharMaps { get; init; }
    internal MechanicManager MechanicalManager { get; init; }
    internal RepairManager JunkRepairManager { get; init; }
}
