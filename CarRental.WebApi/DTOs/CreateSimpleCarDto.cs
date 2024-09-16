namespace CarRental.WebApi.DTOs
{
    public class CreateSimpleCarDto
    {
        // PROPERTIES

        public string VinCode { get; set; }
        public string NumberPlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}
