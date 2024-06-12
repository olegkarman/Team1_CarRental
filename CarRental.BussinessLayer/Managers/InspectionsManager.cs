using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Enums;
using CarRental.Data.Inspection;

namespace CarRental.BussinessLayer.Managers;
public class InspectionsManager : IInspectionsManager
{
    private List<Inspection> _inspections;

    public InspectionsManager()
    {
        _inspections = new List<Inspection>();
    }

    public void AddInspection(Inspection inspection)
    {
        if (inspection == null)
        {
            throw new ArgumentNullException(nameof(inspection), "Inspection cannot be null.");
        }
        _inspections.Add(inspection);
    }

    public void RemoveInspection(Inspection inspection)
    {
        if (inspection != null)
        {
            _inspections.Remove(inspection);
        }
    }

    public Inspection? GetInspection(Inspection inspection)
    {
        return _inspections.Find(i => i.InspectionId == inspection.InspectionId);
    }

    public List<Inspection> GetSuccessfulInspections()
    {
        return _inspections.Where(i => i.Result == InspectionStatusType.Successfully).ToList();
    }

    public List<string> InspectionInfoList()
    {
        var inspectionService = new InspectionService();
        var inspectionList = new List<string>();

        foreach (var item in _inspections)
        {
            inspectionList.Add(inspectionService.GetInfo(item));
        }
        return inspectionList;
    }
}