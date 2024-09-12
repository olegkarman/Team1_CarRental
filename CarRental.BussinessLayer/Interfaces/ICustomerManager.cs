using CarRental.BussinessLayer.DTOs;
using CarRental.Data.Models;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface ICustomerManager
    {
        public Task AddCustomerIntoDatabaseAsync(Customer customer, string connectionString);

        public Task<SimpleCustomerDto> CreateCustomer
        (
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string userName,
            string idNumber,
            string password,
            string passportNumber,
            string drivingLicenseNumber,
            string connectionString,
            string category = "Customer"
        );
    }
}
