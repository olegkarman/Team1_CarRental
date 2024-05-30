using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Enumerables;
using CarRental.Models.Car;


// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Interfaces;

public interface ICarMechanics
{
    internal bool TryReplaceComponent(CarRental.Models.Car.Car car, CarRental.Models.Car.Engine engine);
    internal bool TryReplaceComponent(CarRental.Models.Car.Car car, CarRental.Models.Car.Transmission transmission);
    internal bool TryReplaceComponent(CarRental.Models.Car.Car car, CarRental.Models.Car.Interior interior);
    internal bool TryReplaceComponent(CarRental.Models.Car.Car car, CarRental.Models.Car.Wheels wheels);
    internal bool TryReplaceComponent(CarRental.Models.Car.Car car, CarRental.Models.Car.TypeTire tire);
    internal void Paint(CarRental.Models.Car.Car car, KnownColor color);

    public ComponentStatus CheckComponent(CarRental.Interfaces.IComponent component);
    public bool TryFixComponent(CarRental.Interfaces.IComponent component);

    internal float CheckFuel(CarRental.Models.Car.Car car);
    internal void Refill(CarRental.Models.Car.Car car);
}
