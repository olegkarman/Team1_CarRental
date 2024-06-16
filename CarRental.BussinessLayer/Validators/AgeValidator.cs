using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Validators
{
    public class AgeValidator
    {
        // METHODS

        public bool ValidateEmployeeYear(int year)
        {
            if ((year < 6) || (year > 105))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // // VALIDATE BIRTH MONTH, BIRTH DATE.
    }
}
