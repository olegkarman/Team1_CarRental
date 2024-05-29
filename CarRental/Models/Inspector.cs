using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;
public class Inspector : User
{
    public Inspector(string firstName, string lastName, DateTime dateOfBirth, string password, string userName) : base(firstName, lastName, dateOfBirth, password, userName)
    {
    }

    public string InspectorId { get; set; }
}
