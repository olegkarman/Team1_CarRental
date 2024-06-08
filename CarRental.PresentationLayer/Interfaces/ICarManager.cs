using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Interfaces;

public interface ICarManager
{
    public void MakeNewListOf15Cars();      // CREATE
    public string DisplayCurrentCar();      // RETRIVE
    public void RefillSelectedCar();        // UPDATE
    public void DeleteAllCarsFromList();    // DELETE
    
}
