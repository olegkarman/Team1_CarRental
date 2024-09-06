using CarRental.BussinessLayer.Interfaces;
using CarRental.BussinessLayer.DTOs;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;
using CarRental.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        // FIELDS 

        private ICarManager _carManager;
        private IConfiguration _configuration;

        // CONSTRUCTORS

        public CustomersController(ICarManager carManager, IConfiguration configuration)
        {
            _carManager = carManager;
            _configuration = configuration;
        }

        // METHODS

        [HttpGet]
        [Route("{id}")]
        public async Task<CustomerDto> GetCustomerAsync([FromRoute]string id)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            CustomerDto customersTemp = await _carManager.GetCustomerByIdAsync(connectionString, id, "Customer");

            //var getCustomerDto = new GetCustomerDto
            //{
            //    FirstName = customerDto.FirstName,
            //    LastName = customerDto.LastName,
            //    DateOfBirth = customerDto.DateOfBirth,
            //    Password = customerDto.Password,
            //    UserName = customerDto.UserName,
            //    IdNumber = customerDto.IdNumber,
            //    PassportNumber = customerDto.PassportNumber,
            //    DrivingLicenseNumber = customerDto.DrivingLicenseNumber,
            //    Deals = customerDto.Deals,
            //    Cars = customerDto.Cars
            //};

            return customersTemp;
        }
    }
}
