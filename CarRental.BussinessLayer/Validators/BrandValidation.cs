using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Validators
{
    public class BrandValidation
    {
        // METHODS

        public void CheckNull(Brand brand)
        {
            if (brand == null)
            {
                throw new ArgumentNullException(nameof(brand));
            }
        }

        public void CheckNull(List<Brand> brands)
        {
            if (brands == null)
            {
                throw new ArgumentNullException(nameof(brands));
            }
        }

        public void CheckNull(string brandName)
        {
            if (brandName == null)
            {
                throw new ArgumentNullException(nameof(brandName));
            }
        }

        public void CheckNull(Guid guid)
        {
            if (guid == null)
            {
                throw new ArgumentNullException(nameof(guid));
            }
        }

        public void CheckNull(string[] models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }
        }
    }
}
