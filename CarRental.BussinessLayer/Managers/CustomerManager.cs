using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.RecordTypes;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Diagnostics;

namespace CarRental.BussinessLayer.Managers
{
    public class CustomerManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        public DatabaseContextDapper DapperContext { get; init; }
        
        // CONSTRUCTORS

        public CustomerManager()
        {
            DapperContext = new DatabaseContextDapper();
        }

        // METHODS

        public async Task AddCustomerIntoDatabaseAsync(Customer customer, string connectionString)
        {
            try
            {
                SqlConnection connection = DapperContext.OpenConnection(connectionString);

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

                await connection.ExecuteAsync(sqlStoredProcedureName, arguments);

                DapperContext.CloseConnection(connection);
            }
            catch (AggregateException)
            {
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

                List<int> results = new List<int>(await connection.QueryAsync<int>(sqlStoredProcedureName, parameter));

                int result = results.SingleOrDefault();

                DapperContext.CloseConnection(connection);

                bool isCustomerEntryExist = (result == 1) ? true : false;

                return isCustomerEntryExist;
            }
            catch (AggregateException)
            {
                throw;
            }
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

                SqlConnection connection = DapperContext.OpenConnection(connectionString);

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

                // SingleOrDefault()-METHOD DOES NOT WORK WITH await KEYWORD.
                List<Deal> deals = new List<Deal>(await connection.QueryAsync<Deal>(sqlProcedureName, arguments));

                Deal deal = deals.SingleOrDefault();

                DapperContext.CloseConnection(connection);

                return deal;
            }
            catch(SqlException)
            {
                throw;
            }
            catch(InvalidOperationException)
            {
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
