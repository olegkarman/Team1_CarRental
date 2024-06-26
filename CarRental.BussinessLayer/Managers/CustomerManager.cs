﻿using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.BussinessLayer.Managers
{
    public class CustomerManager
    {
        // FIELDS
        private const string _noInfo = "NO INFORMATION";
        
        // WHERE IS SO-CALLED 'CRUD' FOR THE CUSTOMER-INSTANCE???
        
        public void BuyCar(Car car, Customer customer, ServiceManager serviceManager, DealManager dealManager)
        {
            // NULL-VALIDATION SHOULD BE.
            // THIS IS WORK OF DEAL-MANAGER, NOT CUSTOMER MANAGER.
            // Deal newDeal = new Deal(customer.PassportNumber, car.VinCode, "purchase", car.Price);
            Deal newDeal = dealManager.GetNewDeal(customer.FirstName, customer.PassportNumber, car.VinCode, car.CarId, "purchase", car.Price);
            car.Status = Data.Enums.TransportStatus.Sold;

            // FIRST CHANGE THE STATUS, THEN ADD A CAR-INSTANCE INTO DEAL, ETC...
            //customer.Deals.Add(newDeal);
            dealManager.AddDealInToList(customer.Deals, newDeal);

            serviceManager.AddDealToCar(car, newDeal);  // CALL THE CAR MANAGER INSTEAD.

            AddCarInToCustomer(customer, car);
        }

        public void RentCar(Car car, Customer customer, ServiceManager serviceManager, DealManager dealManager)
        {
            //Deal newDeal = new Deal(customer.PassportNumber, car.VinCode, "rental", car.Price);
            Deal newDeal = dealManager.GetNewDeal(customer.FirstName, customer.PassportNumber, car.VinCode, car.CarId, "rental", car.Price);

            car.Status = Data.Enums.TransportStatus.Rented;

            //customer.Deals.Add(newDeal);
            dealManager.AddDealInToList(customer.Deals, newDeal);

            serviceManager.AddDealToCar(car, newDeal);

            AddCarInToCustomer(customer, car);
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
            // SHOULD BE SOME VALIDATION THERE. NULL-VALIDATION FOR AN EXAMPLE, BUT FROM A SEPARATE VALIDATOR-CLASS.

            customer.Cars.Add(car);
        }
    }
}
