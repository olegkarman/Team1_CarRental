using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Services;

namespace CarRental.BussinessLayer.Managers
{
    public class MechanicManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";
        private UpdatedNameValidator _validator;
        private TextProcessingService _textProcessor;

        // PROPERTIES

        public List<RepairServiceManager> Mechanists { get; set; }

        // CONSTRUCTORS

        // METHODS

        public Mechanic CreateNewMechanic(int year, string name, string surename)
        {
            // VALIDATIONS

            if (!_validator.ValidateNameDefault(name))
            {
                throw new FormatException(nameof(name));
            }
            else if(!_validator.ValidateNameDefault(surename))
            {
                throw new FormatException(nameof(surename));
            }

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
