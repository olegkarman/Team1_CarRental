using System.Diagnostics.CodeAnalysis;

namespace CarRental.Models;

internal class Inspector : User
========
public class Inspector : User
>>>>>>>> master:CarRental.PresentationLayer/Models/Inspector.cs
{
    public DateTime EmploymentDate { get; init; } //Додати readonly поле (string Year)

    [SetsRequiredMembers]
    public Inspector(string? firstName, string? lastName, DateTime dateOfBirth, DateTime employmentDate, string password, string userName) : base(firstName!, lastName!, dateOfBirth, password, userName)
    {
        EmploymentDate = employmentDate;
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
            new Inspector("Adam", "Smith", new DateTime(1990, 1, 1), employmentDate, "password1", "username1"),
            new Inspector("Eva", "Smith", new DateTime(1991, 1, 2), employmentDate.AddYears(1), "password2", "username2"),
            new Inspector("Mike", "Smith", new DateTime(1992, 1, 3), employmentDate.AddYears(2), "password3", "username3")
        };

        Random random = new Random();
        int index = random.Next(0, inspectors.Length); // Випадковий вибір інспектора

        Inspector selectedInspector = inspectors[index];

        Console.WriteLine($"Selected Inspector: {selectedInspector.FirstName} {selectedInspector.LastName}, ID: {selectedInspector.IdNumber}");
    }
    public string GetInspectorName() /*Додати до попереднього проекту 1 extension method, будь-який. (наприклад виводити FullName який складається з Firstname+Lastname)*/
    {
        string fullName = $"{FirstName} {LastName}";
        return fullName.InspectorName();
    }
}
