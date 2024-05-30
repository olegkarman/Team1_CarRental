using CarRental.Models.Car;

namespace CarRental.Models.Portal;
public class Portal
{
    public User UserData { get; set; }
    public bool IsCustomer { get; set; }
    private DealManager _dealManager;
    private ServiceManager _carServiceManager;

    public Portal(User userData, bool isCustomer) {
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
                Console.WriteLine("2. Buy a car (in development)");
                Console.WriteLine("3. Rent a car (in development)");
                Console.WriteLine("4. Check your deals (in development)");
                Console.WriteLine("5. Exit");
            } else
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
                    _carServiceManager.DisplayCarsInTable();
                    Console.ReadLine();
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
}
