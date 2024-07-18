using CarRental.Data.Models;

namespace CarRental.Extensions;
public static class CustomerExtension
{
    public static string GetCustomerDocuments(this Customer customer)
    {
        return $"{customer.DrivingLicenseNumber} {customer.PassportNumber}";
    }
}
