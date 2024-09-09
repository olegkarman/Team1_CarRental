using CarRental.Data.Enums;

namespace CarRental.Data.Interfaces;
public interface IInspection
{
    Guid InspectionId { get; init; }
    DateTime? InspectionDate { get; }
    string? InspectorName { get; }
    Guid? CarId { get; }
    InspectionStatusType? Result { get; }
}
