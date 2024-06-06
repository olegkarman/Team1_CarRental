using CarHubTest;
using CarRental.Models.Portal;
using CarRental.Models;

namespace CarRental.BussinessLayer.Managers
{
    public class PortalManager
    {
        private Portal _portalInstance;

        public PortalManager() { }
        public PortalManager(Portal portal)
        {
            _portalInstance = portal;
        }

        public void StartMainMenu()
        {
            _portalInstance.CarServiceManager.InitializeManagment();
            _portalInstance.CarServiceManager.MakeNewListOf15Cars();
            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine($"Welcome {_portalInstance.UserData.FirstName}");
                Console.WriteLine();
                Console.WriteLine("Select your next move");
                Console.WriteLine();
                Console.WriteLine("1. Show the list of cars");
                if (_portalInstance.IsCustomer)
                {
                    Console.WriteLine("2. Buy a car");
                    Console.WriteLine("3. Rent a car");
                    Console.WriteLine("4. Check your deals");
                    Console.WriteLine("5. Exit");
                }
                else
                {
                    Console.WriteLine("2. Inspect a car");
                    Console.WriteLine("3. Check your inspections");
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
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case "2":
                        if (_portalInstance.IsCustomer)
                        {
                            BuyRentCarFlow();
                        }
                        else
                        {
                            InspectCarFlow();
                        }
                        break;
                    case "3":
                        if (_portalInstance.IsCustomer)
                        {
                            BuyRentCarFlow(false);
                        }
                        else
                        {
                            InspectionManager.PrintAllInspections();
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        if (_portalInstance.IsCustomer)
                        {
                            (_portalInstance.UserData as Customer).ShowMyDeals();
                            Console.WriteLine();
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Program stopped");
                            Environment.Exit(0);
                        }
                        break;
                    case "5":
                        if (_portalInstance.IsCustomer)
                        {
                            Console.WriteLine("Program stopped");
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Please, select a valid option");
                        }
                        break;
                    default:
                        Console.WriteLine("Please, select a valid option");
                        break;
                }

                /*ConsoleHelper.ClearConsoleWithDelay(2);*/
                break;
            }
            ShowMainMenu();
        }

        public void DisplayCars()
        {
            _portalInstance.CarServiceManager.DisplayCarsInTable();
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
            _portalInstance.CarServiceManager.TrySelectCar(index - 1);
            var car = _portalInstance.CarServiceManager.GetSelectedCar();
            if (buy)
            {
                (_portalInstance.UserData as Customer).BuyCar(car);
            }
            else
            {
                (_portalInstance.UserData as Customer).RentCar(car);
            }
            Console.WriteLine($"You have successfully {(buy ? "bought" : "rented")} a car");
            _portalInstance.CarServiceManager.DeleteCarFromList(index - 1);
            /*ConsoleHelper.ConsoleHelper.ClearConsoleWithDelay(2);*/
            ShowMainMenu();
        }

        public void InspectCarFlow()
        {
            Console.Clear();
            DisplayCars();
            Console.WriteLine();
            int index;
            while (true)
            {
                Console.WriteLine("Which car do you want to inspect? Select from 1 to 15");
                string input = Console.ReadLine();

                if (int.TryParse(input, out index) && index >= 1 && index <= 15)
                {
                    break;
                }

                Console.WriteLine("Error: Please enter a valid number from 1 to 15.");
            }
            _portalInstance.CarServiceManager.TrySelectCar(index - 1);
            var car = _portalInstance.CarServiceManager.GetSelectedCar();
            _portalInstance.InspectorCars.InspectCar(car, (_portalInstance.UserData as Inspector));
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
