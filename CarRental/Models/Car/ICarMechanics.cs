using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public interface ICarMechanics
{
    internal bool TryReplaceComponent(Car car, CarEngine engine);
    internal bool TryReplaceComponent(Car car, CarTransmission transmission);
    internal bool TryReplaceComponent(Car car, CarInterior interior);
    internal bool TryReplaceComponent(Car car, CarWheels wheels);
    internal bool TryReplaceComponent(Car car, TypeTire tire);
    public ComponentStatus CheckComponent(IComponent component);
    public bool TryFixComponent(IComponent component);
}
