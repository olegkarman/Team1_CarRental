using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.DTOs
{
    public class DealDto
    {
        // PROPERTIES

        public Guid Id { get; init; }
        public string Name { get; init; }
        public string CustomerId { get; init; }
        public string VinCode { get; init; }
        public Guid CarId { get; init; }
        public float Price { get; init; }

        public string DealType { get; init; }

        // CONSTRUCTORS

        public DealDto()
        {

        }

        public DealDto(string customerId, Guid carId, string type, float price)
        {
            DealType = type;
            this.Price = price;
            this.CarId = carId;
            this.CustomerId = CustomerId;
        }

        public override string ToString()
        {
            return $"DEAL NUMBER: {Id}. CUSTOMER: {CustomerId} DEAL TYPE: {DealType} VIN CODE: {VinCode} PRICE: {Price}";
        }
    }
}
