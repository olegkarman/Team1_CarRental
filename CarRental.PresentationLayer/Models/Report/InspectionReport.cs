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


        public InspectionReport(Guid inspectionId, DateTime inspectionDate, string inspectorName, Guid carId, InspectionStatusType result)
        {
            Id = Guid.NewGuid();
            InspectionId = inspectionId;
            InspectionDate = inspectionDate;
            InspectorName = inspectorName;
            CarId = carId;
            Result = result;
        }
    }
}
