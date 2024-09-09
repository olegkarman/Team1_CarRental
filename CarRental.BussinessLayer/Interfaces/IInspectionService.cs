using CarRental.Data.Enums;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Checkup;

namespace CarRental.BussinessLayer.Interfaces;
public interface IInspectionService
{
    Inspection CreateInspection(Inspector inspector, Car car, InspectionStatusType result);
    bool IsInspectionSuccessfully(Inspection inspection);
    string GetInfo(Inspection inspection);
}
