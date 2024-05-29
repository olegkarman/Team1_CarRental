using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarHubTest
{
    internal interface IInspection
    {
        // Properties
        Guid InspectionId { get; }
        DateTime InspectionDate { get; }
        string? InspectorName { get; }
        int CarId { get; }
        InspectionStatusType Result { get; }

        // Methods
        bool IsInspectionSuccessfully(Guid inspectionId);
        bool IsInspectionSuccessfully(string inspectorName);
    }
}
