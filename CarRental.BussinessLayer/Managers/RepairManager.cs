using CarRental.BussinessLayer.Interfaces;
using CarRental.BussinessLayer.DTOs;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CarRental.BussinessLayer.Managers
{
    public class RepairManager : IRepairManager
    {
        // FIELDS

        // PROPERTIES

        internal INullValidation NullValidator { get; init; }
        internal IIndexValidation IndexValidator { get; init; }
        internal IDataContext DataContext { get; init; }

        // PROPERTIES

        public List<Repair?> Repairs { get; set; }

        // CONSTRUCTORS

        public RepairManager()
        {

        }

        public RepairManager(INullValidation nullValidator, IIndexValidation indexValidator, IDataContext dapperContext)
        {
            NullValidator = nullValidator;
            IndexValidator = indexValidator;
            DataContext = dapperContext;

            Repairs = new List<Repair?>();
        }

        // METHODS

        // CREATE

        public async Task<RepairDto?> GetNewRepairAsync(Car car, Mechanic mechanic, bool isSuccessfull, string connectionString)
        {
            try
            {
                NullValidator.CheckNull(car);
                NullValidator.CheckNull(mechanic);

                char[] infoArray = car.ToString().ToCharArray();

                Random random = new Random();

                random.Shuffle<char>(infoArray);

                string technicalInfo = new String(infoArray);

                var repair = new Repair
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

                SqlConnection connection = DataContext.OpenConnection(connectionString);

                IEnumerable<Repair> repairs = await connection.QueryAsync<Repair>(storedProcedureName, objectArguments);

                repair = repairs.SingleOrDefault();

                DataContext.CloseConnection(connection);

                var repairDto = new RepairDto
                {
                    Id = repair.Id,
                    Date = repair.Date,
                    CarId = repair.CarId,
                    MechanicId = repair.MechanicId,
                    TechnicalInfo = repair.TechnicalInfo,
                    IsSuccessfull = repair.IsSuccessfull,
                    TotalCost = repair.TotalCost
                };

                return repairDto;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (AggregateException)
            {
                throw;
            }
            catch (Exception)
            {
                // SOME LOGGING LOGIC

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