﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;

internal class InspectorCars
{
    public int Mileage { get; set; }
    public int ReleaseDate { get; set; }
    public int ExteriorCondition { get; set; }

    public const int MaxCarsAllowed = 10; //Додати константу (const string InvalidCar ="Car has no mark")
    private int CurrentCarsInspected { get; set; }
    public InspectorCars Status { get; set; }
    internal InspectorCars()
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
    internal void InspectCar(Car car) //Інспектувати по пробігу, даті,стану кузова
    {

        if (Mileage < 200000 && ReleaseDate >= 2015 && ExteriorCondition >= 1)
        {
            Console.WriteLine($"Car {car.Brand} {car.Model} is fit for use.");
        }
        else
        {
            Console.WriteLine($"Car {car.Brand} {car.Model} is unfit for use.");
        }
    }

    public void RecordInspectionResult(Car car, TransportStatus inspectionResult)
    {
        if (car != null)
        {
            switch (inspectionResult)
            {
                case TransportStatus.available:
                    car.Status = "Ready";
                    break;
                case TransportStatus.inRepair:
                    car.Status = "Repair";
                    RemoveCarIfUnfit(car);
                    break;
                case TransportStatus.unavailable:
                    car.Status = "Broken";
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
        if (car.Status == "Repair" || car.Status == "Broken")
        {
            Console.WriteLine($"Car {car.Brand} {car.Model} with Serial Number {car.SerialNumber} removed because it is unfit for use.");
        }
        else
        {
            Console.WriteLine($"Car {car.Brand} {car.Model} with Serial Number {car.SerialNumber} is fit for use. No action taken.");
        }
    }
}

