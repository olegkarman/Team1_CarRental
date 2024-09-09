using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface ITextProcessing
    {
        public string ReplaceSpacesByEmpty(string inputString);
        public string ParseOutputCarsInfo(string carsInfo);
        public string ParseOutputCarInfo(string carInfo);
    }
}
