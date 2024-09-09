using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IRandomCarGeneration
    {
        // METHODS

        public Guid GetNewCarId();
        public string GetNewVinCode();
        public string GetNewNumberPlate();
    }
}
