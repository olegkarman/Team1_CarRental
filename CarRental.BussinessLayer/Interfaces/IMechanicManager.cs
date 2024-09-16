using CarRental.Data.Models;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IMechanicManager
    {
        public Task<Mechanic?> GetMechanicFromDatabaseAsync(Guid guid, string connectionString);
        public Mechanic ChooseMechanicFromList(List<Mechanic> mechanics, Guid guid);
        public void AddRepairInToMechanicList(Mechanic mechanic, Repair repair);
        public void DeleteMechanicFromList(List<Mechanic> mechanics, int index);
    }
}
