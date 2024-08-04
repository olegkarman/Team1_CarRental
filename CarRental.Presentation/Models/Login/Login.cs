﻿using CarRental.Models.Serialiser;
using System.Text.Json;

namespace CarRental.Models.Login;

internal class Login
{
    private string _usersFileName;
    private JsonSerializerOptions _options;

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
        _usersFileName = Path.Combine(Directory.GetCurrentDirectory(), "users.json");

        CheckIfFileExists(_usersFileName);

        _options = new JsonSerializerOptions();
        _options.Converters.Add(new UserJsonConverter());
    }

    public (User?, bool) StartLogin()
    {
        while (true)
        {
            Console.WriteLine("Welcome to Car portal");
            Console.WriteLine();
            Console.WriteLine("Select your next move");
            Console.WriteLine();
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
            Console.Write("Choose an option: ");
            string option = Console.ReadLine();
            Console.WriteLine();

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

        var users = Serializer.DeserializeFromFile<User>(_usersFileName);
        if (users.OfType<Customer>().Any(user => user.ValidateCredentials(username)))
        {
            Console.WriteLine("Username already exists.");
            return;
        }

        var customer = Registration.RegisterCustomer(username, password);
        users.Add(customer);
        Serializer.SerializeToFile(_usersFileName, users);
        Console.WriteLine("Registration successful.");
    }

    private (User?, bool) LoginUser()
    {
        Console.Write("Enter your username: ");
        string username = Console.ReadLine();
        Console.Write("Enter your password: ");
        string password = Console.ReadLine();

        var users = Serializer.DeserializeFromFile<User>(_usersFileName);
        var customer = users.OfType<Customer>().FirstOrDefault(user => user.ValidateCredentials(username, password));
        var inspector = users.OfType<Inspector>().FirstOrDefault(user => user.ValidateCredentials(username, password));

        if (customer != null)
        {
            Console.WriteLine($"Login successful as Customer. Hello, {customer.FirstName}");
            return (customer, true);
        }
        else if (inspector != null)
        {
            Console.WriteLine($"Login successful as Inspector. Hello, {inspector.FirstName}");
            return (inspector, false);
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
            return (null, false);
        }
    }
}