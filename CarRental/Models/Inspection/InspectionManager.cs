using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHubTest
{
    internal class InspectionManager
    {
        private static readonly List<Inspection> s_inspections = new List<Inspection>();

        public static void AddInspection(Inspection inspection)
        {
            if (inspection == null)
            {
                throw new ArgumentNullException(nameof(inspection), "Inspection cannot be null.");
            }
            s_inspections.Add(inspection);
        }

        public static void RemoveInspection(Guid inspectionId)
        {
            var inspection = GetInspection(inspectionId);
            if (inspection != null)
            {
                s_inspections.Remove(inspection);
            }
        }

        public static Inspection? GetInspection(Guid inspectionId)
        {
            return s_inspections.Find(i => i.InspectionId == inspectionId);
        }

        public static void PrintAllInspections()
        {
            foreach (var inspection in s_inspections)
            {
                Console.WriteLine(inspection);
            }
        }
    }
}
