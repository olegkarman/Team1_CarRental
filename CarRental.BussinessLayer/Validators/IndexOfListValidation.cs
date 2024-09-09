using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.Data.Models.RecordTypes;
using CarRental.BussinessLayer.Interfaces;

namespace CarRental.BussinessLayer.Validators
{
    public class IndexOfListValidation : IIndexValidation
    {
        // METHODS

        public void ValidateIndexOfList<T>(List<T> models, int index)
        {
            if ((index < 0) || (index >= models.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void ValidateList<T>(List<T> models)
        {
            // LOGIC OF VALDIATION (IN FUTURE UPDATES).
        }

        public void ValidateDictionary<T>(Dictionary<T, string> dictionary)
        {
            // LOGIC OF VALIDATION.
        }
    }
}
