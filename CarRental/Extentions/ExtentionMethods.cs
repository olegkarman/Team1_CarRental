using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.Extentions;
public static class UserExtention
{
    public static string GetUserCredentials(this User user)
    {
        return $"{user.UserName} {user.Password}";
    }
}
