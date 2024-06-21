using CarRental.Data.Models.Portal;
using CarRental.Data.Models;
using CarRental.BussinessLayer.Interfaces;
using System;
using System.Text;

namespace CarRental.BussinessLayer.Managers
{
    public class PortalManager
    {
        private Portal _portalInstance;
        private IOutputManager _outputManager;
        private ServiceManager _carServiceManager;
        private InspectorCars _inspectorCars;
        private CustomerManager _customerManager;
        private InspectionsManager _inspectionsManager;

        public PortalManager() { }
        public PortalManager(Portal portal, IOutputManager outputManager)
        {
            _portalInstance = portal;
            _outputManager = outputManager;
            _carServiceManager = new ServiceManager();
            _inspectorCars = new InspectorCars();
            _customerManager = new CustomerManager();
            _inspectionsManager = new InspectionsManager();
        }

        public void StartMainMenu()
        {
            _carServiceManager.InitializeManagment();

            this._carServiceManager.GetNewRandomCurrentCars(15);

            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                _outputManager.PrintMessage($"Welcome {_portalInstance.UserData.FirstName}");
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Select your next move");
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("1. Show the list of cars");
                if (_portalInstance.IsCustomer)
                {
                    _outputManager.PrintMessage("2. Buy a car");
                    _outputManager.PrintMessage("3. Rent a car");
                    _outputManager.PrintMessage("4. Check your deals");
                    _outputManager.PrintMessage("5. Exit");
                }
                else
                {
                    _outputManager.PrintMessage("2. Inspect a car");
                    _outputManager.PrintMessage("3. Check your inspections");
                    _outputManager.PrintMessage("4. Exit");
                }
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Choose an option: ");

                string option = _outputManager.GetUserPrompt();
                _outputManager.PrintMessage("");

                switch (option)
                {
                    case "1":
                        DisplayCars();
                        _outputManager.PrintMessage("");
                        _outputManager.PrintMessage("Press any key to continue...");
                        _outputManager.GetUserPrompt();
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
                            var inspections = _inspectionsManager.InspectionInfoList();
                            foreach (var inspection in inspections)
                            {
                                _outputManager.PrintMessage(inspection);
                            }
                            _outputManager.PrintMessage("");
                            _outputManager.PrintMessage("Press any key to continue...");
                            _outputManager.GetUserPrompt();
                        }
                        break;
                    case "4":
                        if (_portalInstance.IsCustomer)
                        {
                            _customerManager.ShowMyDeals(_portalInstance.UserData as Customer);
                            _outputManager.PrintMessage("");
                            _outputManager.PrintMessage("Press any key to continue...");
                            _outputManager.GetUserPrompt();
                        }
                        else
                        {
                            _outputManager.PrintMessage("Program stopped");
                            Environment.Exit(0);
                        }
                        break;
                    case "5":
                        if (_portalInstance.IsCustomer)
                        {
                            _outputManager.PrintMessage("Program stopped");
                            Environment.Exit(0);
                        }
                        else
                        {
                            _outputManager.PrintMessage("Please, select a valid option");
                        }
                        break;
                    default:
                        _outputManager.PrintMessage("Please, select a valid option");
                        break;
                }

                _outputManager.ClearUserUI();
                break;
            }
            ShowMainMenu();
        }

        public void DisplayCars()
        {
            _carServiceManager.DisplayCarsInTable(_outputManager);
        }

        public void BuyRentCarFlow(bool buy = true)
        {
            _outputManager.ClearUserUI();
            DisplayCars();
            _outputManager.PrintMessage("");
            int index;
            while (true)
            {
                _outputManager.PrintMessage("Which car do you want to buy? Select from 1 to 15");
                string input = _outputManager.GetUserPrompt();

                if (int.TryParse(input, out index) && index >= 1 && index <= 15)
                {
                    break;
                }

                _outputManager.PrintMessage("Error: Please enter a valid number from 1 to 15.");
            }
            var car = _carServiceManager.GetCarFromCurrentCars(index - 1);
            if (buy)
            {
                _customerManager.BuyCar(car, _portalInstance.UserData as Customer);
            }
            else
            {
                _customerManager.RentCar(car, _portalInstance.UserData as Customer);
            }
            _outputManager.PrintMessage($"You have successfully {(buy ? "bought" : "rented")} a car");
            _carServiceManager.DeleteCarFromCurrentCars(index - 1);
            _outputManager.ClearUserUI();
            ShowMainMenu();
        }

        public void InspectCarFlow()
        {
            _outputManager.ClearUserUI();
            DisplayCars();
            _outputManager.PrintMessage("");
            int index;
            while (true)
            {
                _outputManager.PrintMessage("Which car do you want to inspect? Select from 1 to 15");
                string input = _outputManager.GetUserPrompt();

                if (int.TryParse(input, out index) && index >= 1 && index <= 15)
                {
                    break;
                }

                _outputManager.PrintMessage("Error: Please enter a valid number from 1 to 15.");
            }
            var car = _carServiceManager.GetCarFromCurrentCars(index - 1);
            _inspectorCars.InspectCar(car, (_portalInstance.UserData as Inspector), _inspectionsManager);
            _outputManager.PrintMessage("");
            _outputManager.PrintMessage("Press any key to continue...");
            _outputManager.GetUserPrompt();
        }
    }
}
