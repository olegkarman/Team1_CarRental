using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Enumerables;
using CarRental.Models.Car;
using CarRental.Interfaces;


// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Interfaces;

public interface ICarMechanics
{
    internal bool TryReplaceComponent(Car car, Engine engine);
    internal bool TryReplaceComponent(Car car, Transmission transmission);
    internal bool TryReplaceComponent(Car car, Interior interior);
    internal bool TryReplaceComponent(Car car, Wheels wheels);
    internal bool TryReplaceComponent(Car car, TypeTire tire);
    internal void Paint(Car car, KnownColor color);

    public ComponentStatus CheckComponent(IComponent component);
    public bool TryFixComponent(IComponent component);

    internal float CheckFuel(Car car);
    internal void Refill(Car car);
}
