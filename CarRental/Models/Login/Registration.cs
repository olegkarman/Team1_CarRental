using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRental.Models.Login;
internal static class Registration
{
    public static bool IsValidName(string name = "")
    {
        Regex regex = new Regex(@"^[A-Za-z]+$");
        return !string.IsNullOrWhiteSpace(name) && regex.IsMatch(name);
    }
    static void RegisterCustomer(string login, string password)
    {
        Random rand = new Random();

        var firstName = "";
        var lastName = "";

        Console.WriteLine("Enter the first name of the user:");

        while (true)
        {
            if (IsValidName(firstName))
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong format. Please, enter a proper name:");
            }
        }

        Console.WriteLine("Enter the last name of the user:");
        while (true)
        {
            if (IsValidName(lastName))
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong format. Please, enter a proper last name:");
            }
        }

        /* DoB */
        DateTime start = new DateTime(1940, 1, 1);
        int range = (new DateTime(2002, 12, 31) - start).Days;
        DateTime dob = start.AddDays(rand.Next(range));

        /* Driving licence number */
        int number = rand.Next(0, 1000000); // Generate a random number between 0 and 999999
        string drivingLicenseNumber = number.ToString("D6");
    }
}
