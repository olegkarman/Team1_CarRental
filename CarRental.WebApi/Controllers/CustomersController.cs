using CarRental.BussinessLayer.DTOs;
using CarRental.BussinessLayer.Interfaces;
using CarRental.BussinessLayer.Managers;
using CarRental.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        // FIELDS 

        private ICustomerManager _customerManager;
        private IConfiguration _configuration;

        // CONSTRUCTORS

        public CustomersController(ICustomerManager customerManager, IConfiguration configuration)
        {
            _customerManager = customerManager;
            _configuration = configuration;
        }

        // METHODS

        [HttpGet]
        [Route("{id}")]
        public async Task<GetCustomerDto> GetCustomerAsync([FromRoute] string id)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            CustomerDto customersTemp = await _customerManager.GetCustomerByIdAsync(connectionString, id, "Customer");

            var getCustomerDto = new GetCustomerDto
            {
                FirstName = customersTemp.FirstName,
                LastName = customersTemp.LastName,
                DateOfBirth = customersTemp.DateOfBirth,
                Password = customersTemp.Password,
                UserName = customersTemp.UserName,
                IdNumber = customersTemp.IdNumber,
                PassportNumber = customersTemp.PassportNumber,
                DrivingLicenseNumber = customersTemp.DrivingLicenseNumber,
                Deals = customersTemp.Deals,
                Cars = customersTemp.Cars
            };

            return getCustomerDto;
        }

        [HttpGet]
        [Route("authentification/{id}")]
        public async Task<IActionResult> IsCustomerExists([FromRoute]string id)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            bool isCustomerExist = await _customerManager.IsCustomerInDatabaseAsync(id, connectionString);

            if (isCustomerExist)
            {
                return Ok(new { message = "CUSTOMER IS FOUND!" });
            }
            else
            {
                return NotFound(new { message = "CUSTOMER IS NOT FOUND!"});
            }
        }

        [HttpPatch]
        [Route("authorization/{id}")]
        public async Task<IActionResult> CheckCredentials([FromRoute]string id, [FromBody]GetCredentialCustomerDto credentialCustomer)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            bool isValid = await _customerManager.CheckCredentialsAsync(id, credentialCustomer.UserName, credentialCustomer.Password, connectionString);

            if (isValid)
            {
                return Ok(new { message = "SUCCESS!"});
            }
            else
            {
                return NotFound(new { message = "USERNAME OR PASSWORD ARE INVALID!"});
            }
        }
    }
}
