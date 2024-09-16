using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.BussinessLayer.DTOs;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IDealManager
    {
        public Task<DealDto> GetNewDealAsync
        (
            string connectionString,
            string name,
            string customerId,
            string vinCode,
            Guid carId,
            string dealType,
            float price
        );

        public Task<Deal> AddDealIntoDatabaseAsync(Deal deal, string connectionString);

        public Deal GetNewDeal(string name, string customerId, string vinCode, Guid carId, string dealType, float price);

        public Task<DealDto> GetDealByIdAsync(string connectionString, string dealId);
    }
}
