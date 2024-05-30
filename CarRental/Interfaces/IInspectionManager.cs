using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHubTest
{
    internal interface IInspectionManager
    {
        void AddInspection(Inspection inspection);
        void RemoveInspection(Guid inspectionId);
        Inspection? GetInspection(Guid inspectionId);
        IEnumerable<Inspection> GetAllInspections();
        void PrintAllInspections();
    }
}
