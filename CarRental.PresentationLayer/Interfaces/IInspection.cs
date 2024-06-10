using CarRental.Data.EnumTypes;

namespace CarRental.Data.Interfaces
{
    internal interface IInspection
    {
        // Properties
        Guid InspectionId { get; }
        DateTime InspectionDate { get; }
        string? InspectorName { get; }
        string CarId { get; }
        InspectionStatusType Result { get; }

        // Methods
        bool IsInspectionSuccessfully(Guid inspectionId);
        bool IsInspectionSuccessfully(string inspectorName);
    }
}
