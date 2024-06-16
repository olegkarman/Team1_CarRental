using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models
{
    public record class Repair
    {
        // FIELDS

        // PROPERTIES
        
        public string Id { get; init; }
        public DateTime Date { get; init; }
        public Guid CarId { get; init; }
        public string CarBrand { get; init; }
        public string CarModel { get; init; }
        public string MechanicName { get; init; }
        public Guid MechanicId { get; init; }
        public string TechnicalInfo { get; init; }
        public bool IsSuccessfull { get; init; }

        // CONSTRUCTORS

        // METHODS
    }
}
