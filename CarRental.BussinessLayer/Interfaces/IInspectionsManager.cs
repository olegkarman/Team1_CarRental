using CarRental.Data.Models.Checkup;

namespace CarRental.BussinessLayer.Interfaces;
public interface IInspectionsManager
{
    void AddInspection(Inspection inspection);
    void RemoveInspection(Inspection inspection);
    Inspection? GetInspection(Inspection inspection);
    List<Inspection> GetSuccessfulInspections();
    List<string> InspectionInfoList();
}
