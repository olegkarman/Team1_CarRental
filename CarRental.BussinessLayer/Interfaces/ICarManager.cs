using CarRental.Data.Models.Automobile;
using CarRental.BussinessLayer.DTOs;

namespace CarRental.BussinessLayer.Interfaces;

public interface ICarManager
{
    public List<Car> MakeNewListOfCars();                 
    public string DisplaySelectedCar();                   
    public void DeleteAllCarsFromList(List<Car> list);

    public void InitializeManagment();
    public void ConfigureOrm();

    public Task<SimpleCarDto> GetSimpleCarById(string carId, string connectionString);

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
}
