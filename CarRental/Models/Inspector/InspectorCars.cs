﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarHubTest;
using CarRental.Enumerables;
using CarRental.Interfaces;
using CarRental.Models.Car;

namespace CarRental.Models.Car;
public record CarRecord(int Id, string Year, string Mark); /* додати  Record тип.*/
internal class InspectorCars
{
    public int Mileage { get; set; }
    public int ReleaseDate { get; set; }
    public int ExteriorCondition { get; set; }

    public const int MaxCarsAllowed = 10; //Додати константу (const string InvalidCar ="Car has no mark")
    private int CurrentCarsInspected { get; set; }
    public InspectorCars Status { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal InspectorCars()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Random rand = new Random();
        Mileage = rand.Next(0, 300000);       // Пробіг від 0 до 300 000 км
        ReleaseDate = rand.Next(2000, 2023);  // Рік випуску від 2000 до 2024
        ExteriorCondition = rand.Next(1, 11);
        CurrentCarsInspected = 0;// Стан кузова від 1 до 10
    }
    public void DisplayInfoInspectCar()
    {
        Console.WriteLine($"Mileage: {Mileage}, Release Date: {ReleaseDate}, Exterior Condition: {ExteriorCondition}");
    }
    public string GetCarInfo(CarRecord car) /* додати  Record тип.*/
    {
        return $"Car Id:{car.Id}, Year{car.Year}, Mark:{car.Mark}";
    }
    internal void InspectedCars(Car car)
    {

        if (CurrentCarsInspected >= MaxCarsAllowed)
        {
            Console.WriteLine($"Inspector cannot check more than {MaxCarsAllowed} cars.");
            return;
        }
        else
        {
            Console.WriteLine("Inspector can check more cars.");
        }
    }
    internal void InspectCar(Car car, Inspector inspector) //Інспектувати по пробігу, даті,стану кузова
    {
        if (car.Mileage < 200000 && car.Year >= 2015 && ExteriorCondition >= 1)
        {
            var inspection = new Inspection(inspector.FirstName, car.VinCode, InspectionStatusType.Successfully);
            RecordInspectionResult(car, InspectionStatusType.Successfully);
            InspectionManager.AddInspection(inspection);
        }
        else if (car.Mileage >= 200000 || car.Year < 2015 || ExteriorCondition < 1)
        {
            var inspection = new Inspection(inspector.FirstName, car.VinCode, InspectionStatusType.Repair);
            Console.WriteLine($"Car {car.Brand} {car.Model} needs repair.");
            RecordInspectionResult(car, InspectionStatusType.Repair);
            InspectionManager.AddInspection(inspection);
        }
        else
        {
            var inspection = new Inspection(inspector.FirstName, car.VinCode, InspectionStatusType.Unusable);
            Console.WriteLine($"Car {car.Brand} {car.Model} is unfit for use.");
            RecordInspectionResult(car, InspectionStatusType.Unusable);
            InspectionManager.AddInspection(inspection);
        }
    }

    public void RecordInspectionResult(Car car, InspectionStatusType inspectionResult)
    {
        if (car != null)
        {
            switch (inspectionResult)
            {
                case InspectionStatusType.Successfully:
                    car.Status = TransportStatus.available;
                    break;
                case InspectionStatusType.Repair:
                    car.Status = TransportStatus.inRepair;
                    RemoveCarIfUnfit(car);
                    break;
                case InspectionStatusType.Unusable:
                    car.Status = TransportStatus.unavailable;
                    RemoveCarIfUnfit(car);
                    break;
                default:
                    break;
            }
            Console.WriteLine($"Inspection result for Car {car.Brand} {car.Model}: {inspectionResult}. Car is {car.Status}.");
        }
        else
        {
            Console.WriteLine("Car not found.");
        }
    }
    public void RemoveCarIfUnfit(Car car) // Видалити машину
    {
        if (car.Status == TransportStatus.inRepair || car.Status == TransportStatus.unavailable)
        {
            Console.WriteLine($"Car {car.Brand} {car.Model} with Serial Number {car.VinCode} removed because it is unfit for use.");
        }
        else
        {
            Console.WriteLine($"Car {car.Brand} {car.Model} with Serial Number {car.VinCode} is fit for use. No action taken.");
        }
    }
}
