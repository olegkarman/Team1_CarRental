﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;
using CarRental.Data.Models.Car.RecordTypes;
using CarRental.BussinessLayer.Managers;
using CarRental.BussinessLayer.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.BussinessLayer.Managers;

public class ServiceManagerSupplements
{
    // THE PURPOSE OF THE CLASS:
    // // HOLDS FIELDS ARE ALL NECCESSARY CLASSES TO CREATE CAR-CLASS INSTANCE.

    // FIELDS

    // PROPERTIES

    public BrandModelsNamesDataSheet BrandModelsDataSheet { get; init; }
    public Depot DepotService { get; init; }
    public Dictionary<string, ModelComponentsPattern> ModelsPatterns { get; init; }
    public BrandRecord[] BrandRecords { get; init; }
    public Mechanic Mechanic { get; init; }
}
