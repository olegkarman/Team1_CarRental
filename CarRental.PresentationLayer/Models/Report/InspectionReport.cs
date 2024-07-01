using CarRental.Data.Enums;

namespace CarRental.Data.Models.Report
{
    public class InspectionReport : Report
    {
        public Guid Id { get; set; }
        public Guid InspectionId { get; private set; }
        public DateTime? InspectionDate { get; private set; }
        public string? InspectorName { get; private set; }
        public Guid? CarId { get; private set; }
        public InspectionStatusType? Result { get; private set; }


        public InspectionReport(InspectionReport inspectionReport)
        {
            Id = Guid.NewGuid();
            InspectionId = inspectionReport.InspectionId;
            InspectionDate = inspectionReport.InspectionDate;
            InspectorName = inspectionReport.InspectorName;
            CarId = inspectionReport.CarId;
            Result = inspectionReport.Result;
        }
    }
}
