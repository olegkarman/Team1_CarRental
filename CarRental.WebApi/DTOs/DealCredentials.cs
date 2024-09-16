namespace CarRental.WebApi.DTOs
{
    public class DealCredentials
    {
        public string Name { get; init; }
        public string CustomerId { get; init; }
        public string VinCode { get; init; }
        public Guid CarId { get; init; }
        public float Price { get; init; }
        public string DealType { get; init; }
    }
}
