using CarRental.Models.Car;

namespace CarRental.Models.Portal;
public class Portal
{
    public User UserData { get; set; }
    public bool IsCustomer { get; set; }
    private DealManager _dealManager;
    private ServiceManager _carServiceManager;

    public Portal(User userData, bool isCustomer)
    {
        UserData = userData;
        IsCustomer = isCustomer;
        _dealManager = new DealManager();
        _carServiceManager = new ServiceManager();
    }

    public void StartMainMenu()
    {
        _carServiceManager.InitializeManagment();
        _carServiceManager.MakeNewListOf15Cars();
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine($"Welcome {UserData.FirstName}");
            Console.WriteLine();
            Console.WriteLine("Select your next move");
            Console.WriteLine();
            Console.WriteLine("1. Show the list of cars");
            if (IsCustomer)
            {
                Console.WriteLine("2. Buy a car");
                Console.WriteLine("3. Rent a car");
                Console.WriteLine("4. Check your deals");
                Console.WriteLine("5. Exit");
            }
            else
            {
                Console.WriteLine("2. Inspect a car (in development)");
                Console.WriteLine("3. Check your inspections (in development)");
                Console.WriteLine("4. Exit");
            }
            Console.WriteLine();
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();
            Console.WriteLine();

            switch (option)
            {
                case "1":
                    DisplayCars();
                    Console.ReadLine();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue...");
                    break;
                case "2":
                    if (IsCustomer)
                    {
                        BuyRentCarFlow();
                    }
                    else
                    {
                        break;
                    }
                    break;
                case "3":
                    if (IsCustomer)
                    {
                        BuyRentCarFlow(false);
                    }
                    else
                    {
                        break;
                    }
                    break;
                case "4":
                    if (IsCustomer)
                    {
                        (UserData as Customer).ShowMyDeals();
                        Console.ReadLine();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                    }
                    else
                    {
                        break;
                    }
                    break;
                default:
                    Console.WriteLine("Please, select a valid option");
                    break;
            }
            ConsoleHelper.ConsoleHelper.ClearConsoleWithDelay(2);
            break;
        }
        ShowMainMenu();
    }

    public void DisplayCars()
    {
        _carServiceManager.DisplayCarsInTable();
    }

    public void BuyRentCarFlow(bool buy = true)
    {
        Console.Clear();
        DisplayCars();
        Console.WriteLine();
        int index;
        while (true)
        {
            Console.WriteLine("Which car do you want to buy? Select from 1 to 15");
            string input = Console.ReadLine();

            if (int.TryParse(input, out index) && index >= 1 && index <= 15)
            {
                break;
            }

            Console.WriteLine("Error: Please enter a valid number from 1 to 15.");
        }
        _carServiceManager.TrySelectCar(index - 1);
        var car = _carServiceManager.GetCar(index);
        if (buy)
        {
            (UserData as Customer).BuyCar(car);
        }
        else
        {
            (UserData as Customer).RentCar(car);
        }
        Console.WriteLine($"You have successfully {(buy ? "bought" : "rented")} a car");
        _carServiceManager.DeleteCarFromList(index - 1);
        ConsoleHelper.ConsoleHelper.ClearConsoleWithDelay(2);
        ShowMainMenu();
    }
}
