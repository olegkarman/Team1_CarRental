using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;
using CarRental.BussinessLayer.DTOs;

namespace CarRental.BussinessLayer.Interfaces;

public interface ICarManager
{                     
    public void InitializeManagment();
    public void ConfigureOrm();

    public Task<SimpleCarDto> GetSimpleCarByIdAsync(string carId, string connectionString);

    public Task<SimpleCarDto> CreateSimpleCar
    (
        string connectionString,
        string vinCode,
        string numberPlate,
        string brand,
        string model,
        int price
    );

    public Task<SimpleCarDto> UpdateNumberPlatePriceSimpleCar
    (
        string connectionString,
        string carId,
        string numberPlate,
        int price
    );

    public ValueTask<bool> DeleteSimpleCar(string connectionString, string carId);

    public Task<CustomerDto> GetCustomerByIdAsync(string connectionString, string id, string category);
}
