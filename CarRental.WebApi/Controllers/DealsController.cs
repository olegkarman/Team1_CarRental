using CarRental.BussinessLayer.DTOs;
using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Models.RecordTypes;
using CarRental.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebApi.Controllers
{
    [ApiController]
    [Route("deals")]
    public class DealsController : ControllerBase
    {

        // FIELDS

        private IDealManager _dealManager;
        private IConfiguration _configuration;

        // CONSTRUCTORS

        public DealsController(IDealManager dealManager, IConfiguration configuration)
        {
            _dealManager = dealManager;
            _configuration = configuration;
        }

        // METHODS

        [HttpGet]
        [Route("{dealId}")]
        public async Task<GetDealDto> RetriveDealByIdAsync([FromRoute]string dealId)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            DealDto dealDto = await _dealManager.GetDealByIdAsync(connectionString, dealId);

            var getDealDto = new GetDealDto
            {
                Id = dealDto.Id,
                Name = dealDto.Name,
                CustomerId = dealDto.CustomerId,
                VinCode = dealDto.VinCode,
                CarId = dealDto.CarId,
                DealType = dealDto.DealType,
                Price = dealDto.Price
            };

            return getDealDto;
        }

        [HttpPost]
        public async Task<GetDealDto> CreateNewDealAsync([FromBody]DealCredentials dealCredentials)
        {
            string? connectionString = _configuration.GetConnectionString("Local");

            DealDto dealDto = await _dealManager.GetNewDealAsync
            (
                connectionString,
                dealCredentials.Name,
                dealCredentials.CustomerId,
                dealCredentials.VinCode,
                dealCredentials.CarId,
                dealCredentials.DealType,
                dealCredentials.Price
            );

            var getDealDto = new GetDealDto
            {
                Id = dealDto.Id,
                Name = dealDto.Name,
                CustomerId = dealDto.CustomerId,
                VinCode = dealDto.VinCode,
                CarId = dealDto.CarId,
                DealType = dealDto.DealType,
                Price = dealDto.Price
            };

            return getDealDto;
        }
    }
}

