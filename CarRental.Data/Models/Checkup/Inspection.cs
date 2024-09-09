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

    // ADD (Y. PARKHOMENKO)
    public string InspectorId { get; init; }
    // END OF ADD

    public String? InspectorName { get; init; }
    public required Guid? CarId { get; init; }
    public InspectionStatusType? Result { get; set; }

    // EDIT (Y. PARKHOMENKO)
    public Inspection()
    {

    }
    // END OF EDIT

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

    // ADD FOR TESTING PURPOSES AND NOT ONLY FOR THAT (Y. PARKHOMENKO)

    // METHODS

    public override string ToString()
    {
        return $"{{ {nameof(InspectionId)} = {InspectionId} | {nameof(InspectionDate)} = {InspectionDate} | {nameof(InspectorId)} = {InspectorId} | {nameof(InspectorName)} = {InspectorName} | {nameof(CarId)} = {CarId} | {nameof(Result)} = {Result} | }}";
    }

    // END OF ADD
}
