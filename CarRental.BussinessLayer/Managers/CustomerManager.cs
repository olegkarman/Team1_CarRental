using System.Text;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.RecordTypes;
using CarRental.BussinessLayer.DTOs;
using CarRental.BussinessLayer.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.Data.Models.Checkup;

namespace CarRental.BussinessLayer.Managers
{
    public class CustomerManager : ICustomerManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        public IDataContext DapperContext { get; init; }

        // CONSTRUCTORS

        public CustomerManager()
        {
            
        }

        public CustomerManager(IDataContext dapperContext)
        {
            DapperContext = dapperContext;
        }

        // METHODS

        public async Task<SimpleCustomerDto> CreateCustomer
        (
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            string userName,
            string idNumber,
            string password,
            string passportNumber,
            string drivingLicenseNumber,
            string connectionString,
            string category = "Customer"
        )
        {
            try
            {
                var sqlProcedureCreate = "CreateCustomer";
                var sqlProcedureSelect = "GetSimpleCustomer";

                string id = idNumber.ToUpper();

                string encryptedPassword = password + "f328373f";

                encryptedPassword = encryptedPassword.GetHashCode().ToString();

                object argumentsCreate = new
                {
                    IdNumber = id,
                    FirstName = firstName,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    UserName = userName,
                    Password = encryptedPassword,
                    PassportNumber = passportNumber,
                    DrivingLicenseNumber = drivingLicenseNumber,
                    BasicDiscount = Customer.BasicDiscount,
                    Category = category
                };

                object argumentsSelect = new
                {
                    idNumber = id,
                    category = category
                };

                SqlConnection connection = DapperContext.OpenConnection(connectionString);

                await connection.ExecuteAsync(sqlProcedureCreate, argumentsCreate);

                IEnumerable<CustomerTemp> customers = await connection.QueryAsync<CustomerTemp>(sqlProcedureSelect, argumentsSelect);

                DapperContext.CloseConnection(connection);

                CustomerTemp customerTemp = customers.FirstOrDefault();

                var customer = new SimpleCustomerDto
                {
                    IdNumber = customerTemp.IdNumber,
                    FirstName = customerTemp.FirstName,
                    LastName = customerTemp.LastName,
                    DateOfBirth = customerTemp.DateOfBirth,
                    UserName = customerTemp.UserName,
                    PassportNumber = customerTemp.PassportNumber,
                    DrivingLicenseNumber = customerTemp.DrivingLicenseNumber,
                    BasicDiscount = CustomerTemp.BasicDiscount
                };

                return customer;
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

        public async ValueTask<bool> AddCustomerIntoDatabaseAsync(Customer customer, string connectionString)
        {
            try
            {
                string sqlStoredProcedureName = "CreateCustomer";

                string id = customer.IdNumber.ToUpper();

                string encryptedPassword = customer.Password + "f328373f";

                encryptedPassword = encryptedPassword.GetHashCode().ToString();

                object arguments = new
                {
                    IdNumber = id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    UserName = customer.UserName,
                    Password = encryptedPassword,
                    PassportNumber = customer.PassportNumber,
                    DrivingLicenseNumber = customer.DrivingLicenseNumber,
                    BasicDiscount = Customer.BasicDiscount
                    //Category = CustomerTemp.Category
                };

                string sqlProcedureCount = "CheckIfCustomerEntryExist";

                object parameter = new
                {
                    Id = id
                };

                SqlConnection connection = DapperContext.OpenConnection(connectionString);

                await connection.ExecuteAsync(sqlStoredProcedureName, arguments);

                IEnumerable<int> results = await connection.QueryAsync<int>(sqlProcedureCount, parameter);             
                                
                DapperContext.CloseConnection(connection);

                int result = results.SingleOrDefault();

                bool isCustomerEntryExist = (result == 1) ? true : false;

                return isCustomerEntryExist;
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

        // RETRIVE

        public async Task<CustomerDto> GetCustomerByIdAsync(string connectionString, string id, string category)
        {
            try
            {
                id = id.ToUpper();

                string procedureName = "GetCustomer";

                var arguments = new
                {
                    customerId = id.ToUpper(),
                    customerCategory = category
                };

                SqlConnection connection = DapperContext.OpenConnection(connectionString);

                IEnumerable<CustomerTemp> customers = await connection.QueryAsync<CustomerTemp, Car?, Deal?, Inspection?, Repair?, CustomerTemp>
                (
                    procedureName,
                    (customer, car, deal, inspection, repair) =>
                    {
                        //car.Owner = customer;
                        car.Engagement = deal;
                        car.Inspections.Add(inspection);
                        car.Repairs.Add(repair);

                        customer.Cars.Add(car);
                        customer.Deals.Add(deal);

                        return customer;
                    },
                    arguments,
                    splitOn: "carCarId, dealId, inspectionInspectionId, repairId"
                );

                CustomerTemp customer = customers.FirstOrDefault();

                var customerTemp = new CustomerTemp
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    DateOfBirth = customer.DateOfBirth,
                    Password = customer.Password,
                    UserName = customer.UserName,
                    IdNumber = customer.IdNumber,
                    PassportNumber = customer.PassportNumber,
                    DrivingLicenseNumber = customer.DrivingLicenseNumber
                };

                customerTemp.Deals = customers.Select(c => c.Deals.FirstOrDefault()).DistinctBy(d => d.Id).ToList();
                //customerTemp.Cars = customers.Select(c => c.Cars.FirstOrDefault()).DistinctBy(car => car.CarId).ToList();

                IEnumerable<IGrouping<Guid, Car>> groupedCars = customers.Select(c => c.Cars.FirstOrDefault()).GroupBy(c => c.CarId);

                foreach (IGrouping<Guid, Car> group in groupedCars)
                {
                    Car? car = group.FirstOrDefault();

                    car.Inspections = group.Select(c => c.Inspections.SingleOrDefault()).DistinctBy(i => i?.InspectionId).ToList();

                    car.Repairs = group.Select(c => c.Repairs.SingleOrDefault()).DistinctBy(r => r?.Id).ToList();

                    customerTemp.Cars.Add(car);
                }

                DapperContext.CloseConnection(connection);

                var customerDto = new CustomerDto
                {
                    FirstName = customerTemp.FirstName,
                    LastName = customerTemp.LastName,
                    DateOfBirth = customerTemp.DateOfBirth,
                    Password = customerTemp.Password,
                    UserName = customerTemp.UserName,
                    IdNumber = customerTemp.IdNumber,
                    PassportNumber = customerTemp.PassportNumber,
                    DrivingLicenseNumber = customerTemp.DrivingLicenseNumber,

                    Deals = customerTemp.Deals,
                    Cars = customerTemp.Cars
                };

                return customerDto;
            }
            catch (SqlException)
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

        public async ValueTask<bool> IsCustomerInDatabaseAsync(string id, string connectionString)
        {
            try
            {
                SqlConnection connection = DapperContext.OpenConnection(connectionString);

                string sqlStoredProcedureName = "CheckIfCustomerEntryExist";

                object parameter = new
                {
                    Id = id
                };

                IEnumerable<int> results = await connection.QueryAsync<int>(sqlStoredProcedureName, parameter);

                int result = results.SingleOrDefault();

                DapperContext.CloseConnection(connection);

                bool isCustomerEntryExist = (result == 1) ? true : false;

                return isCustomerEntryExist;
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

        public async ValueTask<bool> CheckCredentialsAsync(string id, string userName, string password, string connectionString)
        {
            var argument = new
            {
                customerId = id
            };

            var procedureName = "GetCredentialsOfCustomer";

            SqlConnection connection = DapperContext.OpenConnection(connectionString);

            IEnumerable<CredentialCustomerDto> credentials = await connection.QueryAsync<CredentialCustomerDto>(procedureName, argument);

            DapperContext.CloseConnection(connection);

            CredentialCustomerDto credential = credentials.FirstOrDefault();

            string encryptedPassword = password + "f328373f";

            encryptedPassword = encryptedPassword.GetHashCode().ToString();

            bool isCredentialsValid = ((userName == credential.UserName) && (encryptedPassword == credential.Password));

            return isCredentialsValid;
        }

        public async Task<Deal> BuyRentCarAsync(Car car, Customer customer, ServiceManager serviceManager, DealManager dealManager, string dealType, string connectionString)
        {
            try
            {
                Deal newDeal = dealManager.GetNewDeal(customer.FirstName, customer.IdNumber, car.VinCode, car.CarId, dealType, car.Price);
                car.Status = Data.Enums.TransportStatus.Sold;

                dealManager.AddDealInToList(customer.Deals, newDeal);

                serviceManager.AddDealToCar(car, newDeal);

                AddCarInToCustomer(customer, car);

                string sqlProcedureName = "BuyRentCar";

                string dealId = newDeal.Id.ToString().ToUpper();
                string carId = car.CarId.ToString().ToUpper();
                string customerId = customer.IdNumber.ToString().ToUpper();

                var arguments = new
                {
                    @dealId = dealId,
                    @carId = carId,
                    @vinCode = car.VinCode,
                    @customerId = customerId,
                    @price = car.Price,
                    @dealType = dealType,
                    @name = newDeal.Name
                };

                SqlConnection connection = DapperContext.OpenConnection(connectionString);

                // SingleOrDefault()-METHOD DOES NOT WORK WITH await KEYWORD.
                IEnumerable<Deal> deals = await connection.QueryAsync<Deal>(sqlProcedureName, arguments);

                DapperContext.CloseConnection(connection);

                Deal deal = deals.SingleOrDefault();

                return deal;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (Exception)
            {
                // SOME LOGGING LOGIC

                throw;
            }
        }

        public void ShowMyDeals(Customer customer)
        {
            for (int i = 0; i < customer.Deals.Count; i++)
            {
                Console.WriteLine(customer.Deals[i].ToString());    // CHANGE IT PLS, IT IS A HARD-CONNECTION TO CONSOLE, SHOULD BE NOT.
            }
        }

        public string ShowCars(Customer customer, ServiceManager serviceManager)
        {
            StringBuilder displayBuilder = new StringBuilder();

            if (customer.Cars != null)
            {
                foreach (Car? car in customer.Cars)
                {
                    displayBuilder.Append(serviceManager.DisplayCar(car));

                    displayBuilder.Append(" || ");
                }

                string? output = displayBuilder.ToString();

                if (String.IsNullOrEmpty(output))
                {
                    return _noInfo;
                }
                else
                {
                    return output;
                }
            }
            else
            {
                return $"{nameof(customer.Cars)} = {_noInfo}";
            }
        }

        public void AddCarInToCustomer(Customer customer, Car car)
        {
            customer.Cars.Add(car);
        }
    }
}
