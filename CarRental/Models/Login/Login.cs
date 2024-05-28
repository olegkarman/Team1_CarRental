namespace CarRental.Models.Login;

internal class Login
{
    private string _customersFileName;
    private string _inspectorsFileName;

    public void CheckIfFileExists(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close();
        }
    }

    public Login()
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        Directory.SetCurrentDirectory(projectDirectory);
        _customersFileName = Path.Combine(Directory.GetCurrentDirectory(), "customers.json");

        CheckIfFileExists(_customersFileName);

        _inspectorsFileName = Path.Combine(Directory.GetCurrentDirectory(), "inspectors.json");

        CheckIfFileExists(_inspectorsFileName);
    }

    public Customer StartLogin()
    {
        Customer customer = null;
        while (true)
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RegisterUser();
                    break;
                case "2":
                    customer = LoginUser();
                    if (customer != null)
                    {
                        return customer;
                    }
                    break;
                case "3":
                    Console.WriteLine("Program stopped");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please, select a valid option");
                    break;
            }
        }
    }

    private void RegisterUser()
    {
        Console.Write("Enter a username: ");
        string username = Console.ReadLine();
        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        var users = Serializer.DeserializeFromFile<Customer>(_customersFileName);
        if (users.Any(user => user.ValidateCredentials(username)))
        {
            Console.WriteLine("Username already exists.");
            return;
        }

        var customer = Registration.RegisterCustomer(username, password);
        users.Add(customer);
        Serializer.SerializeToFile(_customersFileName, users);
        Console.WriteLine("Registration successful.");
    }

    private Customer? LoginUser()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        var users = Serializer.DeserializeFromFile<Customer>(_customersFileName);
        if (users.Any(user => user.ValidateCredentials(username, password)))
        {
            Console.WriteLine("Login successful.");
            return users.Find(user => user.ValidateCredentials(username, password));
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
            return null;
        }
    }
}
