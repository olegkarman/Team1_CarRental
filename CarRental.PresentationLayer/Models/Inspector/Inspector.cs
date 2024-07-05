using System.Diagnostics.CodeAnalysis;

namespace CarRental.Models;

public class Inspector : User
{
    private static readonly List<Inspection> s_inspections = new List<Inspection>();
    public DateTime EmploymentDate { get; init; } //Додати readonly поле (string Year)

    [SetsRequiredMembers]
    public Inspector() : this(null, null, default(DateTime), default(DateTime), "", "") { }
    public Inspector(string? firstName, string? lastName, DateTime dateOfBirth, DateTime employmentDate, string password, string userName) : base(firstName!, lastName!, dateOfBirth, password, userName)
    {
        EmploymentDate = employmentDate;
    }

}
