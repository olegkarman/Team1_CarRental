using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Managers;
internal class InspectorManager
{
    public string GetInspectorInfo(Inspector inspector) //Додати метод (string GetCarInfo() який виводить Id, Year та Mark)
    {
        return $"Inspector: {inspector.FirstName} {inspector.LastName}, ID: {inspector.IdNumber}, Employment Date: {inspector.EmploymentDate.ToShortDateString()}";
    }
    public void GetInspectorsList()
    {
        DateTime employmentDate = new DateTime(2020, 1, 1);
        Inspector[] inspectors = new Inspector[]      // Створення трьох інспекторів і додавання їх до масиву
      {
            new Inspector("Adam", "Smith", new DateTime(1990, 1, 1), employmentDate, "password1", "username1"),
            new Inspector("Eva", "Smith", new DateTime(1991, 1, 2), employmentDate.AddYears(1), "password2", "username2"),
            new Inspector("Mike", "Smith", new DateTime(1992, 1, 3), employmentDate.AddYears(2), "password3", "username3")
        };

        Random random = new Random();
        int index = random.Next(0, inspectors.Length); // Випадковий вибір інспектора

        Inspector selectedInspector = inspectors[index];

        Console.WriteLine($"Selected Inspector: {selectedInspector.FirstName} {selectedInspector.LastName}, ID: {selectedInspector.IdNumber}");
    }
    public string GetInspectorName(Inspector inspector) /*Додати до попереднього проекту 1 extension method, будь-який. (наприклад виводити FullName який складається з Firstname+Lastname)*/
    {
        string fullName = $"{inspector.FirstName} {inspector.LastName}";
        return fullName.InspectorName();
    }
}
