using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Extentions;
public static class CustomerExtention
{
    public static string GetCustomerDocuments(this Customer customer)
    {
        return $"{customer.DrivingLicenseNumber} {customer.PassportNumber}";
    }
}
