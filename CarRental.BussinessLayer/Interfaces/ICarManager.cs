using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

namespace CarRental.Data.Interfaces;

public interface ICarManager
{
    public List<Car> MakeNewListOfCars();                 // CREATE
    public string DisplaySelectedCar();                   // RETRIVE
    public void RefillSelectedCar();                      // UPDATE
    public void DeleteAllCarsFromList(List<Car> list);    // DELETE
    
}
