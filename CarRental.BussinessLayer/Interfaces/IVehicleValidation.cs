using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IVehicleValidation
    {
        public void CheckNull(string vinCode, string model, string brand, string numberPlate);
        public void CheckType(TransportStatus status);
        public void CheckNull<T>(T model);
    }
}
