﻿using System;
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
        private AgeValidator _ageValidator;
        private MechanicValidation _mechanicValidator;
        private RepairValidation _repairValidator;
        private IndexOfListValidation _indexValidator;

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

            _mechanicValidator.CheckNull(mechanic);

            return mechanic;
        }

        public Mechanic ChooseMechanicFromList(List<Mechanic> mechanics, int index)
        {
            _mechanicValidator.CheckNull(mechanics);
            _indexValidator.ValidateIndexOfList(mechanics, index);

            Mechanic mechanic = mechanics[index];

            _mechanicValidator.CheckNull(mechanic);

            return mechanic;
        }

        public Mechanic ChooseMechanicFromList(List<Mechanic> mechanics, Guid guid)
        {
            _mechanicValidator.CheckNull(mechanics);
            
            Mechanic mechanic = mechanics.Find(x => x.Id.CompareTo(guid) == 0);

            _mechanicValidator.CheckNull(mechanic);

            return mechanic;
        }

        public void AddRepairToMechanicList(Mechanic mechanic, Repair repair)
        {
            _mechanicValidator.CheckNull(mechanic);
            _repairValidator.CheckNull(repair);

            _repairValidator.CheckNull(mechanic.Repairs);

            mechanic.Repairs.Add(repair);
        }

        public void DeleteMechanicFromList(List<Mechanic> mechanics, int index)
        {
            _mechanicValidator.CheckNull(mechanics);

            _indexValidator.ValidateIndexOfList(mechanics, index);

            mechanics.RemoveAt(index);
        }

        public void DeleteMechanicFromList(List<Mechanic> mechanics, Guid guid)
        {
            _mechanicValidator.CheckNull(mechanics);

            mechanics.RemoveAt(mechanics.IndexOf(mechanics.Find(x => x.Id.CompareTo(guid) == 0)));
        }
    }
}
