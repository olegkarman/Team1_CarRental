using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;
using CarRental.Models.Car;

namespace CarRental.Data.Interfaces;

public interface ICarManager
{
    // public Car GetNewCar();
    // public void DeleteCar();
    // public bool TryChangeCarStatus(TransportStatus status);

    public void MakeNewListOf15Cars();  // CREATE
    internal string DisplayCurrentCar();    // READ
    public void RefillSelectedCar();    // UPDATE
    internal void DeleteAllCarsFromList();  // DELETE
    
}
