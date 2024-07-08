using CarRental.Data.Enums;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;

namespace CarRental.Data.Interfaces;
public interface IInspection
{
    Guid InspectionId { get; }
    DateTime? InspectionDate { get; }
    string? InspectorName { get; }
    Guid? CarId { get; }
    InspectionStatusType? Result { get; }
}
