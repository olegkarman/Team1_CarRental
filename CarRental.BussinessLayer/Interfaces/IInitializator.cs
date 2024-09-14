using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IInitializator
    {
        public IRandomCarGeneration ConfigureRandomGeneration(IRandomCarGeneration generator);
    }
}
