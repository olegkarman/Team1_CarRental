using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.Car;
using CarRental.BussinessLayer.Validators;

namespace CarRental.BussinessLayer.Managers
{
    public class RepairManagers
    {
        // FIELDS

        private RepairValidation _repairValidator;
        private VehicleValidation _carValidator;
        private MechanicValidation _mechanicValidator;

        // PROPERTIES

        public List<Repair> Repairs { get; set; }

        // METHODS

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
                 TechnicalInfo = car.Dossier.TechnicalInfo,
                 IsSuccessfull = isSuccessfull
            };

            _repairValidator.CheckNull(repair);

            return repair;
        }

        public Repair ChooseRepairFromList(List<Repair> repairs, int index)
        {
            _repairValidator.CheckNull(repairs);
            
            Repair repair = repairs[index];

            return repair;
        }

        public void DeleteRepairFromList(List<Repair> repairs, int index)
        {
            _repairValidator.CheckNull(repairs);

            repairs.RemoveAt(index);
        }
    }
}
