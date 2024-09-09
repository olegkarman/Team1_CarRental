using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface INullValidation
    {
        public void CheckNull<T>(T model);
    }
}
