using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.BussinessLayer.DTOs
{
    public class CustomerDto
    {
        // PROPERTIES

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; init; }
        public string UserName { get; init; }
        public string IdNumber { get; init; }
        public string PassportNumber { get; init; }
        public required string DrivingLicenseNumber { get; set; }

        public List<Deal> Deals { get; set; }
        public List<Car>? Cars { get; set; }
    }
}
