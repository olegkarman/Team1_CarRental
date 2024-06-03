using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Inspection
{
    public record InspectionReport(Guid InspectionId, DateTime ReportDate, string Report);
}
