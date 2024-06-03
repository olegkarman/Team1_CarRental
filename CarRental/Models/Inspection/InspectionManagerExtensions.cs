using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Models.Inspection
{
    internal static class InspectionManagerExtensions
    {
        public static List<Inspection> GetSuccessfulInspections(this InspectionManager manager)
        {
            return InspectionManager.GetAllInspection()
                                    .Where(i => i.Result == InspectionStatusType.Successfully)
                                    .ToList();
        }
    }
}
