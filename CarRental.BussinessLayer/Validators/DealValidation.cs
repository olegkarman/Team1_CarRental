using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.BussinessLayer.Validators
{
    public class DealValidation
    {
        // METHODS

        public void CheckNull(Deal deal)
        {
            if(deal == null)
            {
                throw new ArgumentNullException(nameof(deal));
            }
        }

        public void CheckNull(List<Deal> deals)
        {
            if (deals == null)
            {
                throw new ArgumentNullException(nameof(deals));
            }
        }
    }
}
