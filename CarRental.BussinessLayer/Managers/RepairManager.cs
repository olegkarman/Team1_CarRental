using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.BussinessLayer.Validators;

namespace CarRental.BussinessLayer.Managers
{
    public class RepairManager
    {
        // FIELDS

        private RepairValidation _repairValidator;
        private VehicleValidation _carValidator;
        private MechanicValidation _mechanicValidator;
        private IndexOfListValidation _indexValidator;

        // PROPERTIES

        public List<Repair> Repairs { get; set; }

        // METHODS

        // CREATE

        public Repair GetNewRepair(Car car, Mechanic mechanic, bool isSuccessfull)
        {
            _carValidator.CheckNull(car);
            _mechanicValidator.CheckNull(mechanic);

            Repair repair = new Repair
            {
                 Id = car.Brand.ToUpper() + car.Model.ToUpper() + DateTime.Now.ToString().ToUpper() + mechanic.Id.ToString().Substring(33).ToUpper(),
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

            _repairValidator.CheckNull(repair);

            return repair;
        }

        public void AddRepairInToList(List<Repair> repairs, Repair repair)
        {
            _repairValidator.CheckNull(repairs);
            _repairValidator.CheckNull(repair);

            repairs.Add(repair);
        }

        // RETRIVE

        public Repair ChooseRepairFromList(List<Repair> repairs, int index)
        {
            _repairValidator.CheckNull(repairs);
            _indexValidator.ValidateIndexOfList(repairs, index);
            
            Repair repair = repairs[index];

            return repair;
        }

        public Repair ChooseRepairFromList(List<Repair> repairs, string id)
        {
            _repairValidator.CheckNull(repairs);

            Repair repair = repairs.Find(x => x.Id.Contains(id));

            _repairValidator.CheckNull(repair);

            return repair;
        }

        public string ShowRepairInfo(Repair repair)
        {
            _repairValidator.CheckNull(repair);

            return repair.ToString();
        }

        // DELETE

        public void DeleteRepairFromList(List<Repair> repairs, int index)
        {
            _repairValidator.CheckNull(repairs);
            _indexValidator.ValidateIndexOfList(repairs, index);

            repairs.RemoveAt(index);
        }

        public void DeleteRepairFromList(List<Repair> repairs, string id)
        {
            _repairValidator.CheckNull(repairs);

            repairs.RemoveAt(repairs.IndexOf(repairs.Find(x => x.Id.Contains(id))));
        }
    }
}
