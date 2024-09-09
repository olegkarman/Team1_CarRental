using System.Drawing;
using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Enums;

namespace CarRental.BussinessLayer.Validators
{
    public class VehicleValidation : IVehicleValidation
    {
        // METHODS

        public void CheckNull<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
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

        public void CheckNull<T>(List<T> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }
        }

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
