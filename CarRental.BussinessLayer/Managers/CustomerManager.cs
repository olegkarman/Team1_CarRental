using CarRental.Data.Models.Car;
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
        public void BuyCar(Car car, Customer customer)
        {
            Deal newDeal = new Deal(customer.PassportNumber, car.VinCode, "purchase", car.Price);
            customer.Deals.Add(newDeal);
            car.Status = Data.Enums.TransportStatus.Sold;
        }

        public void RentCar(Car car, Customer customer)
        {
            Deal newDeal = new Deal(customer.PassportNumber, car.VinCode, "rental", car.Price);
            customer.Deals.Add(newDeal);
            car.Status = Data.Enums.TransportStatus.Rented;
        }

        public void ShowMyDeals(Customer customer)
        {
            for (int i = 0; i < customer.Deals.Count; i++)
            {
                Console.WriteLine(customer.Deals[i].ToString());
            }
        }
    }
}
