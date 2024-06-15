using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;
using CarRental.Data.Interfaces;
using CarRental.Data.Enums;

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

        public void CheckNull(List<Car> cars)
        {
            if (cars == null)
            {
                throw new ArgumentNullException(nameof(cars));
            }
        }

        public void CheckNull(Engine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }
        }

        public void CheckNull(Transmission transmission)
        {
            if (transmission == null)
            {
                throw new ArgumentNullException(nameof(Transmission));
            }
        }

        public void CheckNull(Interior interior)
        {
            if (interior == null)
            {
                throw new ArgumentNullException(nameof(interior));
            }
        }

        public void CheckNull(Wheels wheels)
        {
            if (wheels == null)
            {
                throw new ArgumentNullException(nameof(wheels));
            }
        }

        public void CheckNull(Lights lights)
        {
            if (lights == null)
            {
                throw new ArgumentNullException(nameof(lights));
            }
        }

        public void CheckNull(Signal signal)
        {
            if (signal == null)
            {
                throw new ArgumentNullException(nameof(signal));
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
