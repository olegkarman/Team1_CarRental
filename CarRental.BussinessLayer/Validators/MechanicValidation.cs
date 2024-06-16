using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;
using CarRental.Data.Models;

namespace CarRental.BussinessLayer.Validators
{
    internal class MechanicValidation
    {
        public void CheckNull(Mechanic mechanic)
        {
            if (mechanic == null)
            {
                throw new ArgumentNullException(nameof(mechanic));
            }
        }

        public void CheckNull(List<Mechanic> mechanics)
        {
            if (mechanics == null)
            {
                throw new ArgumentNullException(nameof(mechanics));
            }
        }
    }
}
