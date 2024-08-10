using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.BussinessLayer.Validators;
using CarRental.Data.Models.Automobile.RecordTypes;
using Microsoft.Data.SqlClient;
using Dapper;

namespace CarRental.BussinessLayer.Managers
{
    public class RepairManager
    {
        // FIELDS

        // PROPERTIES

        internal NullValidation NullValidator { get; init; }
        internal IndexOfListValidation IndexValidator { get; init; }
        internal DatabaseContextDapper DataContext { get; init; }

        // PROPERTIES

        public List<Repair> Repairs { get; set; }

        // METHODS

        // CREATE

        public async Task<Repair?> GetNewRepairAsync(Car car, Mechanic mechanic, bool isSuccessfull, string connectionString)
        {
            NullValidator.CheckNull(car);
            NullValidator.CheckNull(mechanic);

            char[] infoArray = car.ToString().ToCharArray();

            Random random = new Random();

            random.Shuffle<char>(infoArray);

            string technicalInfo = new String(infoArray);

            Repair repair = new Repair
            {
                 Id = Guid.NewGuid(),
                 Date = DateTime.Now,
                 CarId = car.CarId,
                 CarBrand = car.Brand,
                 CarModel = car.Model,
                 MechanicName = mechanic.Name,
                 MechanicId = mechanic.Id,
                 TechnicalInfo = technicalInfo,
                 IsSuccessfull = isSuccessfull,
                 TotalCost = (car.Price / 3)
            };

            NullValidator.CheckNull(repair);

            try
            {
                SqlConnection connection = DataContext.OpenConnection(connectionString);

                string storedProcedureName = "CreateRepair";

                var objectArguments = new
                {
                    id = repair.Id,
                    date = repair.Date,
                    carId = repair.CarId,
                    vinCode = car.VinCode,
                    mechanicId = repair.MechanicId,
                    isSuccessfull = repair.IsSuccessfull,
                    totalCost = repair.TotalCost,
                    technicalInfo = repair.TechnicalInfo
                };

                List<Repair> repairs = new List<Repair>(await connection.QueryAsync<Repair>(storedProcedureName, objectArguments));

                repair = repairs.SingleOrDefault();

                DataContext.CloseConnection(connection);

                return repair;
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

        public Repair ChooseRepairFromList(List<Repair> repairs, Guid id)
        {
            NullValidator.CheckNull(repairs);

            Repair repair = repairs.Find(x => (x.Id == id));

            NullValidator.CheckNull(repair);

            return repair;
        }

        public string ShowRepairInfo(Repair repair)
        {
            return repair.ToString();
        }

        // DELETE

        public void DeleteRepairFromList(List<Repair> repairs, int index)
        {
            NullValidator.CheckNull(repairs);
            IndexValidator.ValidateIndexOfList(repairs, index);

            repairs.RemoveAt(index);
        }

        public void DeleteRepairFromList(List<Repair> repairs, Guid id)
        {
            NullValidator.CheckNull(repairs);

            repairs.RemoveAt(repairs.IndexOf(repairs.Find(x => x.Id == id)));
        }
    }
}
