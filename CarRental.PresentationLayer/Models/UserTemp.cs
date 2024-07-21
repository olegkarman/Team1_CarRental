using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data.Models
{
    public class UserTemp : User
    {
        public UserTemp(string? firstName, string? lastName, DateTime dateOfBirth, string password, string userName, string userType) : base(firstName, lastName, dateOfBirth, password, userName)
        {
            UserType = userType;
        }

        public string UserType { get; set; }

    }
}
