using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IRepairManager
    {
        public Task<Repair?> GetNewRepairAsync(Car car, Mechanic mechanic, bool isSuccessfull, string connectionString);
        public Repair ChooseRepairFromList(List<Repair> repairs, int index);
        public void DeleteRepairFromList(List<Repair> repairs, Guid id);

    }
}
