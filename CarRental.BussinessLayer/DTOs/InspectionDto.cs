using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;

namespace CarRental.BussinessLayer.DTOs
{
    public class InspectionDto
    {
        // PROPERTIES

        public Guid InspectionId { get; init; }
        public DateTime InspectionDate { get; init; }

        public string InspectorId { get; init; }

        public string? InspectorName { get; init; }
        public required Guid CarId { get; init; }
        public InspectionStatusType Result { get; set; }

        // CONSTRUCTORS

        public InspectionDto()
        {

        }

        // METHODS

        public override string ToString()
        {
            return $"{{ {nameof(InspectionId)} = {InspectionId} | {nameof(InspectionDate)} = {InspectionDate} | {nameof(InspectorId)} = {InspectorId} | {nameof(InspectorName)} = {InspectorName} | {nameof(CarId)} = {CarId} | {nameof(Result)} = {Result} | }}";
        }
    }
}
