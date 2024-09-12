using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface INameValidation
    {
        public bool ValidateNameDefault(string name);
        public bool CheckNullEmpty(string name);
        public void CheckNullEmpty(string name, string customerId);
        public bool ValidateNameLengthDefault(string name);
    }
}
