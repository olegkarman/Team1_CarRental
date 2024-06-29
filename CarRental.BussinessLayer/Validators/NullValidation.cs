using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Validators
{
    public class NullValidation
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
    }
}
