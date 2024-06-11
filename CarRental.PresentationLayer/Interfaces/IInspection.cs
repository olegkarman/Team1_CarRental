using CarRental.Data.Enums;
using CarRental.Data.Models;
using CarRental.Data.Models.Car;

namespace CarRental.Data.Interfaces;
public interface IInspection
{
    Guid InspectionId { get; }
    DateTime? InspectionDate { get; }
    Inspector? Inspector { get; }
    Guid? CarId { get; }
    InspectionStatusType? Result { get; }
}
