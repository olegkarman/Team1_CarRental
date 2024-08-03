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

        public void AddCustomerIntoDatabase(Customer customer, string connectionString)
        {
            SqlConnection connection = DapperContext.OpenConnection(connectionString);

            string sqlStoredProcedureName = "CreateCustomer";

            string id = customer.IdNumber.ToUpper();

            // SHOULD MOVE THIS LOGIC TO SEPARATE CLASS.
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

            connection.Execute(sqlStoredProcedureName, arguments);

            DapperContext.CloseConnection(connection);
        }

        public bool? IsCustomerInDatabase(string id, string connectionString)
        {
            SqlConnection connection = DapperContext.OpenConnection(connectionString);

            string sqlStoredProcedureName = "CheckIfCustomerEntryExist";

            object parameter = new
            {
                Id = id
            };

            int result = connection.ExecuteScalar<int>(sqlStoredProcedureName, parameter);

            DapperContext.CloseConnection(connection);

            if (result == 1)
            {
                return true;
            }
            else if (result == 0)
            {
                return false;
            }
            else
            {
                return null;
            }
        }

        // WHERE IS SO-CALLED 'CRUD' FOR THE CUSTOMER-INSTANCE??? NEVERMIND...

        public bool BuyCar(Car car, Customer customer, ServiceManager serviceManager, DealManager dealManager, string connectionString)
        {
            Deal newDeal = dealManager.GetNewDeal(customer.FirstName, customer.IdNumber, car.VinCode, car.CarId, "purchase", car.Price);
            car.Status = Data.Enums.TransportStatus.Sold;

            serviceManager.ChangeCarStatusId(car.CarId, car.Status, connectionString);

            //dealManager.AddDealIntoDatabase(newDeal, connectionString);

            dealManager.AddDealInToList(customer.Deals, newDeal);

            serviceManager.AddDealToCar(car, newDeal); 

            AddCarInToCustomer(customer, car);

            //serviceManager.ChangeCarOwnershipInDatabase(car.CarId, customer.IdNumber, connectionString);
            //serviceManager.ChangeCarDealshipInDatabase(car.CarId, newDeal.Id, connectionString);

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
                @dealType = "purchase",
                @name = newDeal.Name
            };

            bool result = connection.Query<bool>(sqlProcedureName, arguments).SingleOrDefault();

            DapperContext.CloseConnection(connection);

            return result;
        }

        public void RentCar(Car car, Customer customer, ServiceManager serviceManager, DealManager dealManager, string connectionString)
        {
            //Deal newDeal = new Deal(customer.PassportNumber, car.VinCode, "rental", car.Price);
            Deal newDeal = dealManager.GetNewDeal(customer.FirstName, customer.IdNumber, car.VinCode, car.CarId, "rental", car.Price);

            car.Status = Data.Enums.TransportStatus.Rented; // CALL CAR-MANAGER INSTED.

            dealManager.AddDealIntoDatabase(newDeal, connectionString);

            //customer.Deals.Add(newDeal);
            dealManager.AddDealInToList(customer.Deals, newDeal);

            serviceManager.AddDealToCar(car, newDeal);

            AddCarInToCustomer(customer, car);

            serviceManager.ChangeCarOwnershipInDatabase(car.CarId, customer.IdNumber, connectionString);
            serviceManager.ChangeCarDealshipInDatabase(car.CarId, newDeal.Id, connectionString);
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

            if (customer.Cars != null)  // ACTUALLY VALIDATION IS BETTER TO SPARE INTO A SEPARATE CLASS, BUT I DO NOT WANT TOO MUCH REWRITE THE CLASS WHICH IS NOT MINE.
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
