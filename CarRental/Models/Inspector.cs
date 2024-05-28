using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CarRental.Models;
internal class Inspector
{
    private readonly DateTime EmploymentDate; //Додати readonly поле (string Year)
    private string firstName;

    public string FirstName //Додати required проперті (string Id)
    {
        get { return firstName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("First name must be set", nameof(FirstName));
            }
            firstName = value;
        }
    }
    public string LastName { get; set; } //Додати звичайне проперті (string Mark)
    public int IdNumber { get; set; }
    public Inspector()
    {
        EmploymentDate = DateTime.MinValue;
        firstName = "";
        LastName = "";
        IdNumber = 0;
    }
    public Inspector(string firstName, string lastName, int idNumber, DateTime employmentDate)
    {

        FirstName = firstName;
        LastName = lastName;
        IdNumber = idNumber;
        EmploymentDate = employmentDate;
    }
    public Inspector(string firstName, string lastName) : this(firstName, lastName, 0, DateTime.Now)
    {
        Console.WriteLine("Inspector object created with default employment date."); // Додати на нього оверлоадінг overloading. 
    }
    public string GetInspectorInfo() //Додати метод (string GetCarInfo() який виводить Id, Year та Mark)
    {
        return $"Inspector: {FirstName} {LastName}, ID: {IdNumber}, Employment Date: {EmploymentDate.ToShortDateString()}";
    }
    public void ChangeToInspector()
    {
        DateTime employmentDate = new DateTime(2020, 1, 1);
        Inspector[] inspectors = new Inspector[]      // Створення трьох інспекторів і додавання їх до масиву
        {
            new Inspector("Adam", "Smith", 1001, employmentDate),
            new Inspector("Eva", "Smith", 1002, employmentDate.AddYears(1)), // Інша дата працевлаштування
            new Inspector("Mike", "Smith", 1003, employmentDate.AddYears(2))
        };

        Random random = new Random();
        int index = random.Next(0, inspectors.Length); // Випадковий вибір інспектора

        Inspector selectedInspector = inspectors[index];

        Console.WriteLine($"Selected Inspector: {selectedInspector.FirstName} {selectedInspector.LastName}, ID: {selectedInspector.IdNumber}");
    }
}





internal class InspectCars
{
    public int Mileage { get; set; }
    public int ReleaseDate { get; set; }
    public int ExteriorCondition { get; set; }

    public const int MaxCarsAllowed = 10; //Додати константу (const string InvalidCar ="Car has no mark")
    private int CurrentCarsInspected { get; set; }
    public InspectCars Status { get; set; }
    internal InspectCars()
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
    internal void InspectedCars (Car car)
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
    internal void InspectCar (Car car) //Інспектувати по пробігу, даті,стану кузова
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

