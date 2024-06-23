using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;

namespace CarRental.Data.Inspection;
public class Inspection : IInspection
{
    private readonly DateTime _inspectionDate = DateTime.Now;
    
    // properties
    public Guid InspectionId { get; }
    public DateTime? InspectionDate => _inspectionDate;
    public String? InspectorName { get; init; }
    public required Guid? CarId { get; init; }
    public InspectionStatusType? Result { get; set; }

    public Inspection()
    {
        InspectionId = Guid.NewGuid();
    }
    [SetsRequiredMembers]
    public Inspection(Inspector inspector, Car car, InspectionStatusType result) : this()
    {
        InspectorName = inspector.FirstName + " " + inspector.LastName;
        CarId = car.CarId;
        Result = result;
    }
}
