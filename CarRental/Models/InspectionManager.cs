using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHubTest
{
internal class InspectionManager : IInspectionManager
{
    private readonly List<Inspection> _inspections;

    public InspectionManager()
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

    public void RemoveInspection(Guid inspectionId)
    {
        var inspection = GetInspection(inspectionId);
        if (inspection != null)
        {
            _inspections.Remove(inspection);
        }
    }

    public Inspection? GetInspection(Guid inspectionId)
    {
        return _inspections.Find(i => i.InspectionId == inspectionId);
    }

    public IEnumerable<Inspection> GetAllInspections()
    {
        return _inspections;
    }

    public void PrintAllInspections()
    {
        foreach (var inspection in _inspections)
        {
            Console.WriteLine(inspection.ToString());
        }
    }
}
}
