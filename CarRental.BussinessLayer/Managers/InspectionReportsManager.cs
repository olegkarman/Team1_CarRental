using CarRental.Data.Models.Report;

namespace CarRental.BussinessLayer.Managers
{
    public class InspectionReportsManager
    {
        private readonly List<InspectionReport> _reports;

        public InspectionReportsManager()
        {
            _reports = new List<InspectionReport>();
        }

        public void AddReport(InspectionReport report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report), "Report cannot be null");
            }

            _reports.Add(report);
        }

        public bool RemoveReport(Guid reportId)
        {
            var report = _reports.FirstOrDefault(r => r.Id == reportId);
            if (report != null)
            {
                _reports.Remove(report);
                return true;
            }

            return false;
        }

        public Report GetReport(Guid reportId)
        {
            return _reports.FirstOrDefault(r => r.Id == reportId);
        }

        public List<InspectionReport> GetAllReports()
        {
            return _reports;
        }
    }
}
