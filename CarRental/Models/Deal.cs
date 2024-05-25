using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;
internal class Deal
{
    /*DealDate: DateTime
    CompanyId: int
    CustomerId: int
    DealType: string (purchase, rental)
    CarId: int
    Price: double
    Methods:
    CreateDeal(Customer customer, Car car, string dealType, double price)
    CancelDeal(int dealId)*/

    internal DateTime DealDate {  get; set; }
    internal int CompanyId { get; set; }
    internal int CustomerId { get; set; }
    internal int CarId { get; set; }
    internal double Price { get; set; }

    internal enum DealType
    {
        purchase,
        rental
    }

    internal void CreateDeal(Customer customer, Car car, string dealType, double price)
    {

    }

    internal void CancelDeal(int dealId)
    {
        Console.WriteLine($"\{fvbye");
    }
}
