using System.Diagnostics.CodeAnalysis;
using CarRental.Data.EnumTypes;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Models.Inspection;
public class Inspection : IInspection
{
    private const string InspectionNumber = "Inspection ID ";
    private readonly DateTime _inspectionDate = DateTime.Now;

    // properties
    public Guid InspectionId { get; }
    public DateTime InspectionDate => _inspectionDate;
    public string? InspectorName { get; init; }
    public required string CarId { get; init; }
    public InspectionStatusType Result { get; set; }

    public Inspection()
    {
        InspectionId = Guid.NewGuid();
    }
    [SetsRequiredMembers]
    public Inspection(string inspectorName, string carId, InspectionStatusType result) : this()
    {
        InspectorName = inspectorName;
        CarId = carId;
        Result = result;
    }

    public bool IsInspectionSuccessfully(Guid inspectionId)
    {
        return (InspectionId == inspectionId) && (Result == InspectionStatusType.Successfully);
    }

    public bool IsInspectionSuccessfully(string inspectorName)
    {
        if (String.IsNullOrWhiteSpace(inspectorName))
        {
            throw new ArgumentException("InspectorName cannot be empty, or whitespace.", nameof(inspectorName));
        }
        else
        {
            return string.Equals(InspectorName, inspectorName, StringComparison.OrdinalIgnoreCase) && (Result == InspectionStatusType.Successfully); ;
        }
    }

    public override string ToString()
    {
        return $"{InspectionNumber}: {InspectionId}\n" +
               $"Inspector Name: {InspectorName}\n" +
               $"Car ID: {CarId}\n" +
               $"Inspection Date: {InspectionDate.ToShortDateString()}\n" +
               $"Result: {Result}\n";
    }
}
