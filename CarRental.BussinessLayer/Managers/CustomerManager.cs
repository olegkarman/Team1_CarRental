using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Managers
{
    public class CustomerManager
    {
        // FIELDS
        private const string _noInfo = "NO INFORMATION";
        
        // WHERE IS SO-CALLED 'CRUD' FOR THE CUSTOMER-INSTANCE???
        
        public void BuyCar(Car car, Customer customer, ServiceManager serviceManager)
        {
            Deal newDeal = new Deal(customer.PassportNumber, car.VinCode, "purchase", car.Price);
            customer.Deals.Add(newDeal);

            serviceManager.AddDealToCar(car, newDeal);  // CALL THE CAR MANAGER INSTEAD.

            car.Status = Data.Enums.TransportStatus.Sold;
        }

        public void RentCar(Car car, Customer customer, ServiceManager serviceManager)
        {
            Deal newDeal = new Deal(customer.PassportNumber, car.VinCode, "rental", car.Price);
            customer.Deals.Add(newDeal);

            serviceManager.AddDealToCar(car, newDeal);

            car.Status = Data.Enums.TransportStatus.Rented;
        }

        public void ShowMyDeals(Customer customer)
        {
            for (int i = 0; i < customer.Deals.Count; i++)
            {
                Console.WriteLine(customer.Deals[i].ToString());    // CHANGE IT PLS, IT IS A HARD-CONNECTION TO CONSOLE, SHOULD BE NOT.
            }
        }

        // WITH HELP OF STRING BUILDER IT GOING TO BE EASIER FOR PERFORMANCE.
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

                return displayBuilder.ToString();
            }
            else
            {
                return $"{nameof(customer.Cars)} = {_noInfo}";
            }
        }
    }
}
