using CarRental.Models.Validation;

namespace CarRental.Models.Login;
internal static class Registration
{
    public static Customer RegisterCustomer(string login, string password)
    {
        Random rand = new Random();

        var firstName = "";
        var lastName = "";

        Console.WriteLine("Enter the first name of the user:");

        while (true)
        {
            firstName = Console.ReadLine();
            if (Validator.IsValidName(firstName))
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
            lastName = Console.ReadLine();
            if (Validator.IsValidName(firstName))
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

        /* Driving licence number */
        // Generate two random letters
        char letter1 = (char)rand.Next('A', 'Z' + 1);
        char letter2 = (char)rand.Next('A', 'Z' + 1);

        // Generate six random digits
        int pasportNumberToUse = rand.Next(0, 1000000); // Generate a random number between 0 and 999999

        // Combine the letters and the number into a string
        string pasportNumber = $"{letter1}{letter2}{pasportNumberToUse:D6}";

        return new Customer(firstName, lastName, pasportNumber, drivingLicenseNumber, dob, password, login);
    }
}
