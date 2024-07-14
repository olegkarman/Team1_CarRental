using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Enums;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Services;
using System.Xml.Linq;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Managers
{
    public class MechanicManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";
        internal UpdatedNameValidator Validator { get; init; }
        internal TextProcessingService TextProcessor { get; init; }
        internal AgeValidator AgeValidator { get; init; }
        internal NullValidation NullValidator { get; init; }
        internal IndexOfListValidation IndexValidator { get; init; }
        internal Random PseudoRandom;

        // PROPERTIES

        public List<Mechanic> Mechanists { get; set; }

        // CONSTRUCTORS

        public MechanicManager()
        {
            this.PseudoRandom = new Random();
        }

        // METHODS

        // CREATE

        public Mechanic GetNewMechanic(int year, string name, string surename)
        {
            if (!AgeValidator.ValidateEmployeeYear(year))
            {
                throw new FormatException(nameof(year));
            }
            else if (!Validator.ValidateNameDefault(name))
            {
                throw new FormatException(nameof(name));
            }
            else if(!Validator.ValidateNameDefault(surename))
            {
                throw new FormatException(nameof(surename));
            }

            // FORMAT NAMES
            name = TextProcessor.ReplaceSpacesByEmpty(name);
            surename = TextProcessor.ReplaceSpacesByEmpty(surename);

            Mechanic mechanic = new Mechanic
            {
                Id = Guid.NewGuid(),
                Year = year,
                Name = name,
                Surename = surename,
                Repairs = new List<Repair>()
            };

            NullValidator.CheckNull(mechanic);

            return mechanic;
        }

        public Mechanic GetNewRandomMechanic()
        {
            int year = PseudoRandom.Next(1947, 2021);

            string name = $"{(NamesSurenames)PseudoRandom.Next(10, 18)}";

            string surename = $"{(NamesSurenames)PseudoRandom.Next(10, 18)}{(NamesSurenames)PseudoRandom.Next(10, 18)}";

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

        public void AddMechanicInToList(List<Mechanic> mechanics, Mechanic mechanic)
        {
            NullValidator.CheckNull(mechanics);
            NullValidator.CheckNull(mechanic);

            mechanics.Add(mechanic);
        }

        // RETRIVE

        public Mechanic ChooseMechanicFromList(List<Mechanic> mechanics, int index)
        {
            NullValidator.CheckNull(mechanics);
            IndexValidator.ValidateIndexOfList(mechanics, index);

            Mechanic mechanic = mechanics[index];

            NullValidator.CheckNull(mechanic);

            return mechanic;
        }

        public Mechanic ChooseMechanicFromList(List<Mechanic> mechanics, Guid guid)
        {
            NullValidator.CheckNull(mechanics);
            
            Mechanic mechanic = mechanics.Find(x => x.Id.CompareTo(guid) == 0);

            NullValidator.CheckNull(mechanic);

            return mechanic;
        }

        // UPDATE

        public void AddRepairInToMechanicList(Mechanic mechanic, Repair repair)
        {
            NullValidator.CheckNull(mechanic);
            NullValidator.CheckNull(repair);

            NullValidator.CheckNull(mechanic.Repairs);

            mechanic.Repairs.Add(repair);
        }

        // DELETE

        public void DeleteMechanicFromList(List<Mechanic> mechanics, int index)
        {
            NullValidator.CheckNull(mechanics);

            IndexValidator.ValidateIndexOfList(mechanics, index);

            mechanics.RemoveAt(index);
        }

        public void DeleteMechanicFromList(List<Mechanic> mechanics, Guid guid)
        {
            NullValidator.CheckNull(mechanics);

            mechanics.RemoveAt(mechanics.IndexOf(mechanics.Find(x => x.Id.CompareTo(guid) == 0)));
        }
    }
}
