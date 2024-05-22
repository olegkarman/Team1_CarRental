namespace CarRental.Models;
internal class Login
{
    private string _fileName;

    public Login()
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        Directory.SetCurrentDirectory(projectDirectory);
        _fileName = Path.Combine(Directory.GetCurrentDirectory(), "users.txt");

        if (!File.Exists(_fileName))
        {
            File.Create(_fileName).Close();
        }
    }

    public void StartLogin()
    {
        while (true)
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                RegisterUser();
            }
            else if (option == "2")
            {
                if (LoginUser())
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Please, select a valid option");
            }
        }
    }

    private void RegisterUser()
    {
        Console.Write("Enter a username: ");
        string username = Console.ReadLine();
        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        var data = File.ReadAllLines(_fileName);
        if (data.Any(line => line.Split(',')[0] == username))
        {
            Console.WriteLine("Username already exists.");
            return;
        }

        File.AppendAllText(_fileName, $"{username},{password}\n");
        Console.WriteLine("Registration successful.");
    }

    private bool LoginUser()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        var data = File.ReadAllLines(_fileName);
        if (data.Any(line => line == $"{username},{password}"))
        {
            Console.WriteLine("Login successful.");
            return true;
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
            return false;
        }
    }
}
