using CarRental.BussinessLayer.DTOs;
using CarRental.BussinessLayer.Interfaces;
using CarRental.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    [Route("cars")]
    public class CarsController : ControllerBase
    {
        // FIELDS

        private ICarManager _carManager;
        private IConfiguration _configuration;

        // CONSTRUCTORS

        public CarsController(ICarManager carManager, IConfiguration configuration)
        {
            _carManager = carManager;
            _configuration = configuration;
        }

        // METHODS

        [HttpPost]
        [Route("simple")]
        public async Task<GetSimpleCarDto> CreateSimpleCar([FromBody] CreateSimpleCarDto createSimpleCarDto)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            SimpleCarDto simpleCarDto = await _carManager.CreateSimpleCar
            (
                connectionString,
                createSimpleCarDto.VinCode,
                createSimpleCarDto.NumberPlate,
                createSimpleCarDto.Brand,
                createSimpleCarDto.Model,
                createSimpleCarDto.Price
            );

            var getSimpleCarDto = new GetSimpleCarDto
            {
                CarId = simpleCarDto.CarId,
                VinCode = simpleCarDto.VinCode,
                NumberPlate = simpleCarDto.NumberPlate,
                Brand = simpleCarDto.Brand,
                Model = simpleCarDto.Model,
                Price = simpleCarDto.Price
            };

            return getSimpleCarDto;
        }

        [HttpGet]
        [Route("simple/{carId}")]
        public async Task<GetSimpleCarDto> GetSimpleCar([FromRoute] string carId)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            SimpleCarDto? simpleCarDto = await _carManager.GetSimpleCarByIdAsync(carId, connectionString);

            var getSimpleCarDto = new GetSimpleCarDto
            {
                CarId = simpleCarDto.CarId,
                VinCode = simpleCarDto.VinCode,
                NumberPlate = simpleCarDto.NumberPlate,
                Brand = simpleCarDto.Brand,
                Model = simpleCarDto.Model,
                Price = simpleCarDto.Price
            };

            return getSimpleCarDto;
        }

        [HttpPatch]
        [Route("simple/{carId}")]
        public async Task<GetSimpleCarDto> UpdatePlatePriceSimpleCar([FromRoute] string carId, [FromBody] UpdateSimpleCarDto updateSimpleCarDto)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            SimpleCarDto? simpleCarDto = await _carManager.UpdateNumberPlatePriceSimpleCar
            (
                connectionString,
                carId,
                updateSimpleCarDto.NumberPlate,
                updateSimpleCarDto.Price
            );

            var getSimpleCarDto = new GetSimpleCarDto
            {
                CarId = simpleCarDto.CarId,
                VinCode = simpleCarDto.VinCode,
                NumberPlate = simpleCarDto.NumberPlate,
                Brand = simpleCarDto.Brand,
                Model = simpleCarDto.Model,
                Price = simpleCarDto.Price
            };

            return getSimpleCarDto;
        }

        [HttpDelete]
        [Route("{carId}")]
        public async ValueTask<bool> DeleteCar([FromRoute] string carId)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            bool isSuccessful = await _carManager.DeleteSimpleCar(connectionString, carId);

            return isSuccessful;
        }

        [HttpPatch]
        [Route("buy/{id}")]
        public async Task<GetBuyCarDto> BuyCar([FromRoute]string id, [FromBody]BuyCarCredentials buyCarCredentials)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            BuyCarDto carDto = await _carManager.UpdateBuyCar(connectionString, id, buyCarCredentials.CustomerId, buyCarCredentials.DealId, buyCarCredentials.StatusId);

            var getBuyCarDto = new GetBuyCarDto
            {
                CarId = carDto.CarId,
                VinCode = carDto.VinCode,
                Model = carDto.Model,
                Brand = carDto.Brand,
                NumberPlate = carDto.NumberPlate,
                Price = carDto.Price,
                Engine = carDto.Engine,
                Transmission = carDto.Transmission,
                Interior = carDto.Interior,
                Wheels = carDto.Wheels,
                Lights = carDto.Lights,
                Signal = carDto.Signal,
                Color = carDto.Color,
                NumberOfSeats = carDto.NumberOfSeats,
                NumberOfDoors = carDto.NumberOfDoors,
                Mileage = carDto.Mileage,
                MaxFuelCapacity = carDto.MaxFuelCapacity,
                CurrentFuel = carDto.CurrentFuel,
                Year = carDto.Year,
                StatusId = carDto.StatusId,
                IsFitForUse = carDto.IsFitForUse,
                DealId = carDto.DealId,
                CustomerId = carDto.CustomerId
            };

            return getBuyCarDto;
        }
    }
}
