using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.RecordTypes;
using CarRental.Data.Models.Automobile;
using CarRental.BussinessLayer.Validators;

namespace CarRental.BussinessLayer.Managers
{
    public class RepairManager
    {
        // FIELDS

        // PROPERTIES

        internal NullValidation NullValidator { get; init; }
        internal IndexOfListValidation IndexValidator { get; init; }

        // PROPERTIES

        public List<Repair> Repairs { get; set; }

        // METHODS

        // CREATE

        public Repair GetNewRepair(Car car, Mechanic mechanic, bool isSuccessfull)
        {
            NullValidator.CheckNull(car);
            NullValidator.CheckNull(mechanic);

            Repair repair = new Repair
            {
                 Id = Guid.NewGuid(),
                 Date = DateTime.Now,
                 CarId = car.CarId,
                 CarBrand = car.Brand,
                 CarModel = car.Model,
                 MechanicName = mechanic.Name,
                 MechanicId = mechanic.Id,
                 TechnicalInfo = car.ToString(),
                 IsSuccessfull = isSuccessfull,
                 TotalCost = (car.Price / 3)
            };

            NullValidator.CheckNull(repair);

            return repair;
        }

        public void AddRepairInToList(List<Repair> repairs, Repair repair)
        {
            NullValidator.CheckNull(repairs);
            NullValidator.CheckNull(repair);

            repairs.Add(repair);
        }

        // RETRIVE

        public Repair ChooseRepairFromList(List<Repair> repairs, int index)
        {
            NullValidator.CheckNull(repairs);
            IndexValidator.ValidateIndexOfList(repairs, index);
            
            Repair repair = repairs[index];

            return repair;
        }

        public Repair ChooseRepairFromList(List<Repair> repairs, string id)
        {
            NullValidator.CheckNull(repairs);

            Repair repair = repairs.Find(x => (x.Id.CompareTo(id) == 0));

            NullValidator.CheckNull(repair);

            return repair;
        }

        public string ShowRepairInfo(Repair repair)
        {
            NullValidator.CheckNull(repair);

            return repair.ToString();
        }

        // DELETE

        public void DeleteRepairFromList(List<Repair> repairs, int index)
        {
            NullValidator.CheckNull(repairs);
            IndexValidator.ValidateIndexOfList(repairs, index);

            repairs.RemoveAt(index);
        }

        public void DeleteRepairFromList(List<Repair> repairs, string id)
        {
            NullValidator.CheckNull(repairs);

            repairs.RemoveAt(repairs.IndexOf(repairs.Find(x => x.Id.CompareTo(id) == 0)));
        }
    }
}
