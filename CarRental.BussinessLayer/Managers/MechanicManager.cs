using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Enums;
using CarRental.Data.Managers;
using CarRental.BussinessLayer.Validators;
using CarRental.BussinessLayer.Services;
using System.Xml.Linq;
using CarRental.Data.Models.Automobile.RecordTypes;
using Microsoft.Data.SqlClient;
using CarRental.Data.Models.Automobile;
using Dapper;

namespace CarRental.BussinessLayer.Managers
{
    public class MechanicManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        internal UpdatedNameValidator Validator { get; init; }
        internal TextProcessingService TextProcessor { get; init; }
        internal AgeValidator AgeValidator { get; init; }
        internal NullValidation NullValidator { get; init; }
        internal IndexOfListValidation IndexValidator { get; init; }
        internal Random PseudoRandom;
        internal DatabaseContextDapper DataContext { get; init; }

        // PROPERTIES

        public List<Mechanic> Mechanists { get; set; }

        // CONSTRUCTORS

        public MechanicManager()
        {
            this.PseudoRandom = new Random();
        }

        // METHODS

        // CREATE

        public Mechanic? GetMechanicFromDatabase(Guid guid, string connectionString)
        {
            try
            {
                SqlConnection connection = DataContext.OpenConnection(connectionString);

                string sqlStoredProcedureName = "GetMechanic";

                string id = guid.ToString().ToUpper();

                var parameter = new
                {
                    Id = id
                };

                List<Mechanic> mechanics = new List<Mechanic>
                (
                    connection.Query<Mechanic, Repair?, Mechanic>
                    (
                        sqlStoredProcedureName,
                        (mechanic, repair) =>
                        {
                            mechanic.Repairs.Add(repair);
                            
                            return mechanic;
                        },
                        parameter,
                        splitOn: "repairId"
                    )
                );

                Mechanic? mechanic = mechanics.FirstOrDefault();

                mechanic.Repairs = mechanics.Select(m => m.Repairs.SingleOrDefault()).DistinctBy(r => r?.Id).ToList();

                DataContext.CloseConnection(connection);

                return mechanic;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

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
