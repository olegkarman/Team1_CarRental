using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;
internal class Inspector
{
    public readonly DateTime EmploymentDate; //Додати readonly поле (string Year)
    private string firstName;
    public static readonly int MaxCarsAllowed = 10;//Додати константу (const string InvalidCar ="Car has no mark")

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
    public string IdNumber { get; set; }
    public List<Car> cars;
    public Inspector(string firstName, string lastName, string idNumber, DateTime employmentDate)
    {
        FirstName = firstName;
        LastName = lastName;
        IdNumber = idNumber;
        EmploymentDate = employmentDate;
        cars = new List<Car>();
    }
    public string GetInspectorInfo() //Додати метод (string GetCarInfo() який виводить Id, Year та Mark)
    {
        return $"Name: {FirstName} {LastName}, ID: {IdNumber}, Employment Date: {EmploymentDate}";
    }

    public void SomeMethod()
    {
        Inspector inspector = new Inspector("Adam", "Smith", "12345", DateTime.Now);
        string inspectorInfo = inspector.GetInspectorInfo();
        Console.WriteLine(inspectorInfo);
    }
    public Inspector(string firstName, string lastName, string idNumber)
    : this(firstName, lastName, idNumber, DateTime.Now)
    {
        // Додати на нього оверлоадінг overloading. 
        Console.WriteLine("Inspector object created with default employment date.");
    }

   
    public void InspectCar(List<Car> cars, int carId, Inspector inspector)
    {
        if (inspector.cars.Count <= Inspector.MaxCarsAllowed)
        {
            foreach (Car car in cars)
            {
                if (car.SerialNumber == carId)
                {
                    if (car.IsFitForUse)
                    {
                        Console.WriteLine($"Vehicle {carId} is fit for use.");
                    }
                    else
                    {
                        Console.WriteLine($"Vehicle {carId} is unfit for use.");
                    }
                    return;
                }
                else
                {
                    Console.WriteLine($"Vehicle {carId} not found.");
                }
            }
            Console.WriteLine("Inspector can check more cars.");
        }
        else
        {
            Console.WriteLine($"Inspector cannot check more than {Inspector.MaxCarsAllowed} cars.");
        }

    }
  
    public void RecordInspectionResult(int carId, bool isFitForUse)
    {
        var car = cars.Find(c => c.SerialNumber == carId);
        if (car != null)
        {
            car.IsFitForUse = isFitForUse;
            Console.WriteLine($"Inspection result for Vehicle {carId}: {(isFitForUse ? "Fit" : "Unfit")}");
            if (!isFitForUse)
            {
                RemoveCarIfUnfit(cars, carId);
            }
        }
        else
        {
            Console.WriteLine($"Vehicle {carId} not found.");
        }
    }

    public void RemoveCarIfUnfit(List<Car> cars, int carId)
    {
        var car = cars.Find(c => c.SerialNumber == carId);
        if (car != null && !car.IsFitForUse)
        {
            cars.Remove(car);
            Console.WriteLine($"\nCar with Id {carId} removed because it is unfit for use.");
        }
        else
        {
            Console.WriteLine($"\nCar with Id {carId} is either not found or is not unfit for use.");
        }
    }
}
