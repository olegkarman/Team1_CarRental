using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public interface ICarMechanics
{
    internal bool TryChangeEngine(CarEngine engine);
    internal bool TryChangeTransmission(CarTransmission transmission);
    internal bool TryChangeInterior(CarInterior interior);
    internal bool TryChangeWheels(CarWheels wheels);
    internal bool TryChangeTire(TypeTire tire);
    public bool TryFixComponent(IComponent component);
}
