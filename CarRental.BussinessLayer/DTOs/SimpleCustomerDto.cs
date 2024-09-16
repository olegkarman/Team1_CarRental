using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.DTOs
{
    public class SimpleCustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string UserName { get; init; }
        public string IdNumber { get; init; }
        public string PassportNumber { get; init; }
        public float BasicDiscount { get; set; }
        public required string DrivingLicenseNumber { get; set; }
    }
}
