using CarRental.BussinessLayer.Interfaces;

namespace CarRental.BussinessLayer.Validators
{
    public class NullValidation : INullValidation
    {
        // METHODS

        public void CheckNull<T>(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
        }

        public void CheckNull<T>(List<T> models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }
        }

        public void CheckNull<T>(T[] models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }
        }
    }
}
