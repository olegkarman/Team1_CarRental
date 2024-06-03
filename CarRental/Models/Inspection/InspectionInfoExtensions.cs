using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHubTest
{
    internal static class InspectionInfoExtensions
    {
        public static string GetInspectionSummary(this Inspection inspection)
        {
            return $"Inspection Summary:\n" +
                   $"Inspection ID: {inspection.InspectionId}\n" +
                   $"Inspector Name: {inspection.InspectorName}\n" +
                   $"Car ID: {inspection.CarId}\n" +
                   $"Inspection Date: {inspection.InspectionDate.ToShortDateString()}\n" +
                   $"Result: {inspection.Result}\n";
        }
    }
}
