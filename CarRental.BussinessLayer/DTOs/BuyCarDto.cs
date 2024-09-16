using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.Data.Models.Checkup;
using CarRental.Data.Models.RecordTypes;
using CarRental.Data.Models;

namespace CarRental.BussinessLayer.DTOs
{
    public class BuyCarDto
    {
        public required Guid CarId { get; init; }
        public required string VinCode { get; init; }
        public required string Model { get; init; }
        public required string Brand { get; init; }
        public required string NumberPlate { get; set; }
        public required int Price { get; set; }

        public string? Engine { get; set; }
        public string? Transmission { get; set; }
        public string? Interior { get; set; }
        public string? Wheels { get; set; }
        public string? Lights { get; set; }
        public string? Signal { get; set; }
        public string? Color { get; set; }
        public int? NumberOfSeats { get; set; }
        public int? NumberOfDoors { get; set; }

        public float? Mileage { get; set; }

        public int? MaxFuelCapacity { get; set; }

        public float? CurrentFuel { get; set; }

        public int? Year { get; init; }

        public int? StatusId { get; set; }
        public bool? IsFitForUse { get; set; }

        public string? DealId { get; set; }
        public string? CustomerId { get; set; }
    }
}
