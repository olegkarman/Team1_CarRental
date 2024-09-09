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
