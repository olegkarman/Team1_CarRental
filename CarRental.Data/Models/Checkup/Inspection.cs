using System.Diagnostics.CodeAnalysis;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;
using CarRental.Data.Models.Automobile;

namespace CarRental.Data.Models.Checkup;

public class Inspection : IInspection
{
    //private readonly DateTime _inspectionDate = DateTime.Now;

    // properties
    public Guid InspectionId { get; init; }
    public DateTime? InspectionDate { get; init; } // => _inspectionDate;

    public string InspectorId { get; init; }

    public String? InspectorName { get; init; }
    public required Guid? CarId { get; init; }
    public InspectionStatusType? Result { get; set; }

    public Inspection()
    {

    }

    [SetsRequiredMembers]
    public Inspection(Inspector inspector, Car car, InspectionStatusType result) : this()
    {
        InspectionDate = DateTime.Now;
        InspectionId = Guid.NewGuid();
        InspectorId = inspector.IdNumber;
        InspectorName = inspector.FirstName + " " + inspector.LastName;
        CarId = car.CarId;
        Result = result;
    }

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(InspectionId)} = {InspectionId} | {nameof(InspectionDate)} = {InspectionDate} | {nameof(InspectorId)} = {InspectorId} | {nameof(InspectorName)} = {InspectorName} | {nameof(CarId)} = {CarId} | {nameof(Result)} = {Result} | }}";
    }
}
