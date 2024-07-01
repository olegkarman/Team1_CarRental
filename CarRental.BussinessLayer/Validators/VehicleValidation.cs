using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Interfaces;
using CarRental.Data.Enums;
using System.Drawing;
using System.Runtime.ConstrainedExecution;

namespace CarRental.BussinessLayer.Validators
{
    public class VehicleValidation
    {
        // METHODS

        public void CheckNull<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }

        //public void CheckNull(Car car)
        //{
        //    if (car == null)
        //    {
        //        throw new ArgumentNullException(nameof(car));
        //    }
        //}

        //public void CheckNull(bool? isFitForUse)
        //{
        //    if (isFitForUse == null)
        //    {
        //        throw new ArgumentNullException(nameof(isFitForUse));
        //    }
        //}

        //public void CheckNull(string tupleEntry)
        //{
        //    if (tupleEntry == null)
        //    {
        //        throw new ArgumentNullException(nameof(tupleEntry));
        //    }
        //}

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

        public void CheckNull<T>(List<T> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }
        }

        //public void CheckNull(List<Car> cars)
        //{
        //    if (cars == null)
        //    {
        //        throw new ArgumentNullException(nameof(cars));
        //    }
        //}

        public void CheckNullEmpty(string model)
        {
            if (string.IsNullOrEmpty(model))
            {
                throw new ArgumentNullException(nameof(model));
            }
        }

        public void CheckType(TransportStatus status)
        {
            if (!Enum.IsDefined(typeof(TransportStatus), status))
            {
                throw new InvalidCastException(nameof(status));
            }
        }

        public void CheckType(KnownColor color)
        {
            if (!Enum.IsDefined(typeof(KnownColor), color))
            {
                throw new InvalidCastException(nameof(color));
            }
        }

        public void CheckPrice(int price)
        {
            if (price < 0)
            {
                throw new FormatException(nameof(price));
            }
        }

        public void CheckZeroNegative(int number)
        {
            if (number <= 0)
            {
                throw new FormatException(nameof(number));
            }
        }

        public void CheckZeroNegative(float number)
        {
            if (number <= 0)
            {
                throw new FormatException(nameof(number));
            }
        }
    }
}
