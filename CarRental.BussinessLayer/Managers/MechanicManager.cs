using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Services;
using System.Reflection;

namespace CarRental.BussinessLayer.Managers
{
    public class MechanicManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";
        private UpdatedNameValidator _validator;
        private TextProcessingService _textProcessor;
        private AgeValidator _ageValidator;

        // PROPERTIES

        public List<RepairServiceManager> Mechanists { get; set; }

        // CONSTRUCTORS

        // METHODS

        public Mechanic GetNewMechanic(int year, string name, string surename)
        {
            if (!_ageValidator.ValidateEmployeeYear(year))
            {
                throw new FormatException(nameof(year));
            }
            else if (!_validator.ValidateNameDefault(name))
            {
                throw new FormatException(nameof(name));
            }
            else if(!_validator.ValidateNameDefault(surename))
            {
                throw new FormatException(nameof(surename));
            }

            // FORMAT NAMES
            name = _textProcessor.ReplaceSpacesByEmpty(name);
            surename = _textProcessor.ReplaceSpacesByEmpty(surename);


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

        public Mechanic ChooseMechanicFromList(List<Mechanic> mechanics, int index)
        {
            ValidateIndexOfMechanicsList(mechanics, index);

            Mechanic mechanic = mechanics[index];

            // VALIDATE NULL PLS.

            return mechanic;
        }

        public void AddRepairToMechanicList(Mechanic mechanic, Repair repair)
        {
            // VALIDATE NULL PLS.

            mechanic.Repairs.Add(repair);
        }

        public void DeleteMechanicFromList(List<Mechanic> mechanics, int index)
        {
            // VALIDATE NULL PLS.

            ValidateIndexOfMechanicsList(mechanics, index);

            mechanics.RemoveAt(index);
        }

        // MOVE IT INTO A VALIDATOR PLS.
        public void ValidateIndexOfMechanicsList(List<Mechanic> mechanics, int index)
        {
            if ((index < 0) || (index >= mechanics.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
