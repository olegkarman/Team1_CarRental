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
    // public Car GetNewCar();
    // public void DeleteCar();
    // public bool TryChangeCarStatus(TransportStatus status);

    public void MakeNewListOf15Cars();      // CREATE
    public string DisplayCurrentCar();      // RETRIVE
    public void RefillSelectedCar();        // UPDATE
    public void DeleteAllCarsFromList();    // DELETE
    
}
