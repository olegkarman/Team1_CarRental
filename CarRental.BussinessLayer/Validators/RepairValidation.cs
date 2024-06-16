using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;

namespace CarRental.BussinessLayer.Validators
{
    internal class RepairValidation
    {
        // METHODS

        public void CheckNull(Repair repair)
        {
            if (repair == null)
            {
                throw new ArgumentNullException(nameof(repair));
            }
        }

        public void CheckNull(List<Repair> repairs)
        {
            if (repairs == null)
            {
                throw new ArgumentNullException(nameof(repairs));
            }
        }
    }
}
