using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.DTOs
{
    public class RepairDto
    {
        public Guid Id { get; init; }
        public DateTime Date { get; init; }
        public Guid CarId { get; init; }
        public string VinCode { get; init; }
        public Guid MechanicId { get; init; }
        public string? TechnicalInfo { get; init; }
        public bool IsSuccessfull { get; init; }
        public int TotalCost { get; init; }
    }
}
