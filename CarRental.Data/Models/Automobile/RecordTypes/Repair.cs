using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Automobile;

namespace CarRental.Data.Models.Automobile.RecordTypes
{
    public record class Repair
    {
        // FIELDS

        // PROPERTIES

        public Guid Id { get; init; }
        public DateTime Date { get; init; }
        public Guid CarId { get; init; }
        //public string VinCode { get; init; }
        public string? CarBrand { get; init; }
        public string? CarModel { get; init; }
        public string? MechanicName { get; init; }
        public Guid MechanicId { get; init; }
        public string? TechnicalInfo { get; init; }
        public bool IsSuccessfull { get; init; }
        public int TotalCost { get; init; }

        // CONSTRUCTORS

        // METHODS

    }
}
