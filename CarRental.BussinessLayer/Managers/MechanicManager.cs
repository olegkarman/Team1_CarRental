using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;

namespace CarRental.BussinessLayer.Managers
{
    public class MechanicManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        public List<RepairServiceManager> Mechanics { get; set; }

        // CONSTRUCTORS

        public MechanicManager()
        {
            this.Mechanics = new List<RepairServiceManager>();
        }

        // METHODS

        public Mechanic CreateNewMechanic(int year, string name, string surename)
        {
            // VALIDATIONS

            Mechanic mechanic = new Mechanic
            {
                Id = Guid.NewGuid(),
                Year = year,
                Name = name,
                Surename = surename,
                Repairs = new List<Repair>()

            };

            return mechanic;
        }
    }
}
