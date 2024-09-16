using CarRental.BussinessLayer.DTOs;
using CarRental.Data.Models;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface ICustomerManager
    {
        public ValueTask<bool> AddCustomerIntoDatabaseAsync(Customer customer, string connectionString);

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

        public Task<CustomerDto> GetCustomerByIdAsync(string connectionString, string id, string category);

        public ValueTask<bool> IsCustomerInDatabaseAsync(string id, string connectionString);

        public ValueTask<bool> CheckCredentialsAsync(string id, string userName, string password, string connectionString);
    }
}
