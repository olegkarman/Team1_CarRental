using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.BussinessLayer.Validators
{
    public class IndexOfListValidation
    {
        // METHODS

        public void ValidateIndexOfList<T>(List<T> models, int index)
        {
            if ((index < 0) || (index >= models.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
