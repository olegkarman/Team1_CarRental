using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;
using CarRental.Data.Interfaces;


// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.BussinessLayer.Interfaces;

public interface ICarMechanics
{
    public bool TryReplaceComponent(Car car, Engine engine);
    public bool TryReplaceComponent(Car car, Transmission transmission);
    public bool TryReplaceComponent(Car car, Interior interior);
    public bool TryReplaceComponent(Car car, Wheels wheels);
    public bool TryReplaceComponent(Car car, TypeTire tire);
    public void Paint(Car car, KnownColor color);

    public ComponentStatus CheckComponent(IComponent component);
    public bool TryFixComponent(IComponent component);

    public float CheckFuel(Car car);
    public void Refill(Car car);
}
