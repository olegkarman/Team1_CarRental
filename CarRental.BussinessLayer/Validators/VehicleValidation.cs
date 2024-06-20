using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;
using CarRental.Data.Interfaces;
using CarRental.Data.Enums;
using System.Runtime.ConstrainedExecution;

namespace CarRental.BussinessLayer.Validators
{
    public class VehicleValidation
    {
        // METHODS

        public void CheckNull(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
        }

        public void CheckNull(string vinCode, string model, string brand, string numberPlate)
        {
            if (vinCode == null)
            {
                throw new ArgumentNullException(nameof(vinCode));
            }
            else if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            else if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
            else if (numberPlate == null)
            {
                throw new ArgumentNullException(nameof(numberPlate));
            }

        }

        public void CheckNull(List<Car> cars)
        {
            if (cars == null)
            {
                throw new ArgumentNullException(nameof(cars));
            }
        }

        public void CheckType(TransportStatus status)
        {
            if (!Enum.IsDefined(typeof(TransportStatus), status))
            {
                throw new InvalidCastException(nameof(status));
            }
        }
    }
}
