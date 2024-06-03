using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Extensions;
public static class CustomerExtension
{
    public static string GetCustomerDocuments(this Customer customer)
    {
        return $"{customer.DrivingLicenseNumber} {customer.PassportNumber}";
    }
}
