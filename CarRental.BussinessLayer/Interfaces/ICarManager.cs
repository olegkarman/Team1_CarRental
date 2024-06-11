using CarRental.Data.Models.Car;

namespace CarRental.BussinessLayer.Interfaces;

public interface ICarManager
{
    public List<Car> MakeNewListOfCars();                 // CREATE
    public string DisplaySelectedCar();                   // RETRIVE
    public void RefillSelectedCar();                      // UPDATE
    public void DeleteAllCarsFromList(List<Car> list);    // DELETE
    
}
