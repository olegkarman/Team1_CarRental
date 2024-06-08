using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;
using CarRental.Data.Interfaces;

namespace CarRental.BussinessLayer.Validators
{
    public class VehicleValidation
    {
        // METHODS

        public Car ChooseCarFromList(List<Car> list, int index)
        {

            CheckNull(list);

            if ((index < 0) || (index > list.Count))
            {
                throw new IndexOutOfRangeException();
            }

            Car car = list[index];

            CheckNull(car);

            return car;
        }

        public Car ChooseCarFromList(List<Car> list, string model)
        {
            CheckNull(list);

            try
            {
                // THE EMPTY LINE CAN APPEAR.
                return list.Find(x => x.Model.Contains(model));
            }
            catch (IndexOutOfRangeException exception)
            {
                throw exception;
            }
            catch (NullReferenceException exception)
            {
                throw exception;
            }
            catch (FormatException exception)
            {
                throw exception;
            }
        }

        // NULL CHECK

        public void CheckNull(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
        }

        public void CheckNull(List<Car> cars)
        {
            if (cars == null)
            {
                throw new ArgumentNullException(nameof(cars));
            }
        }

        public void CheckNull(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }
        }
    }
}
