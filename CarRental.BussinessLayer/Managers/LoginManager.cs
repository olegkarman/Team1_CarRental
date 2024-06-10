using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Models;
using CarRental.Data.Models.Login;
using CarRental.Data.Models.Serialiser;
using CarRental.Data.Models.Validation;

namespace CarRental.BussinessLayer.Managers
{
    public class LoginManager(Login login, IOutputManager outputManager)
    {
        private Login _login = login;
        private IOutputManager _outputManager = outputManager;

        public (User?, bool) StartLogin()
        {
            while (true)
            {
                _outputManager.PrintMessage("Welcome to Car portal");
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Select your next move");
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("1. Register");
                _outputManager.PrintMessage("2. Login");
                _outputManager.PrintMessage("3. Exit");
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Choose an option: ");
                string option = _outputManager.GetUserPrompt();
                _outputManager.PrintMessage("");

                switch (option)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        var customer = LoginUser();
                        if (customer.Item1 != null)
                        {
                            return customer;
                        }
                        break;
                    case "3":
                        _outputManager.PrintMessage("Program stopped");
                        Environment.Exit(0);
                        break;
                    default:
                        _outputManager.PrintMessage("Please, select a valid option");
                        break;
                }
            }
        }

        private void RegisterUser()
        {
            _outputManager.PrintMessage("Enter a username: ");
            string username = _outputManager.GetUserPrompt();
            _outputManager.PrintMessage("Enter a password: ");
            string password = _outputManager.GetUserPrompt();

            string salt = "f328373f";
            var fullPassword = password + salt;
            var hashedPass = fullPassword.GetHashCode();


            var users = Serializer.DeserializeFromFile<User>(_login.UsersFileName);
            if (users.OfType<Customer>().Any(user => user.ValidateCredentials(username)))
            {
                _outputManager.PrintMessage("Username already exists.");
                return;
            }

            var customer = RegisterCustomer(username, password);
            users.Add(customer);
            Serializer.SerializeToFile(_login.UsersFileName, users);
            _outputManager.PrintMessage("Registration successful.");
        }

        private (User?, bool) LoginUser()
        {
            _outputManager.PrintMessage("Enter your username: ");
            string username = _outputManager.GetUserPrompt();
            _outputManager.PrintMessage("Enter your password: ");
            string password = _outputManager.GetUserPrompt();

            var users = Serializer.DeserializeFromFile<User>(_login.UsersFileName);
            var customer = users.OfType<Customer>().FirstOrDefault(user => user.ValidateCredentials(username, password));
            var inspector = users.OfType<Inspector>().FirstOrDefault(user => user.ValidateCredentials(username, password));

            if (customer != null)
            {
                _outputManager.PrintMessage($"Login successful as Customer. Hello, {customer.FirstName}");
                return (customer, true);
            }
            else if (inspector != null)
            {
                _outputManager.PrintMessage($"Login successful as Inspector. Hello, {inspector.FirstName}");
                return (inspector, false);
            }
            else
            {
                _outputManager.PrintMessage("Invalid username or password.");
                return (null, false);
            }
        }

        public Customer RegisterCustomer(string userName, string password)
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

            return new Customer(firstName, lastName, pasportNumber, drivingLicenseNumber, dob, password, userName);
        }
    }
}
