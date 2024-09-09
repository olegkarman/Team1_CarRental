using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IIndexValidation
    {
        public void ValidateIndexOfList<T>(List<T> models, int index);
        public void ValidateList<T>(List<T> models);
        public void ValidateDictionary<T>(Dictionary<T, string> dictionary);
    }
}
