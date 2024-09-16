namespace CarRental.WebApi.DTOs
{
    public class GetDealDto
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

        public GetDealDto()
        {

        }

        public GetDealDto(string customerId, Guid carId, string type, float price)
        {
            DealType = type;
            Price = price;
            CarId = carId;
            CustomerId = customerId;
        }

        public override string ToString()
        {
            return $"DEAL NUMBER: {Id}. CUSTOMER: {CustomerId} DEAL TYPE: {DealType} VIN CODE: {VinCode} PRICE: {Price}";
        }
    }
}
