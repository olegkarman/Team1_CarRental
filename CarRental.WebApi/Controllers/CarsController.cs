﻿using Microsoft.AspNetCore.Mvc;
using CarRental.BussinessLayer.Managers;
using CarRental.BussinessLayer.DTOs;
using CarRental.BussinessLayer.Interfaces;
using CarRental.WebApi.DTOs;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
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

        [HttpGet]
        [Route("cars/simple/{carId}")]
        public async Task<GetSimpleCarDto> GetSimpleCar([FromRoute]string carId)
        {
            //_carManager.InitializeManagment();

            string? connectionString = _configuration.GetConnectionString("Local");

            SimpleCarDto? simpleCarDto = await _carManager.GetSimpleCarById(carId, connectionString);

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
    }
}
