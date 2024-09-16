using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.BussinessLayer.DTOs;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IRepairManager
    {
        public List<Repair?> Repairs { get; set; }
        public Task<RepairDto?> GetNewRepairAsync(Car car, Mechanic mechanic, bool isSuccessfull, string connectionString);
        public Repair ChooseRepairFromList(List<Repair> repairs, int index);
        public void DeleteRepairFromList(List<Repair> repairs, Guid id);
        public string ShowRepairInfo(Repair repair);
        public void AddRepairInToList(List<Repair> repairs, Repair repair);
    }
}
