using CarRental.Data.Models.Portal;
using CarRental.Data.Models;
using CarRental.BussinessLayer.Interfaces;
using System;
using System.Text;
using CarRental.Data.Models.Automobile;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

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
        private MechanicManager _mechanicManager;
        private RepairManager _repairManager;

        public PortalManager() { }
        public PortalManager(Portal portal, IOutputManager outputManager)
        {
            _portalInstance = portal;
            _outputManager = outputManager;
            _carServiceManager = new ServiceManager();
            _inspectorCars = new InspectorCars();
            _customerManager = new CustomerManager();
            _inspectionsManager = new InspectionsManager();
            _mechanicManager = new MechanicManager();
            _repairManager = new RepairManager();
        }

        public void StartMainMenu()
        {
            _carServiceManager.InitializeManagment();

            this._carServiceManager.GetNewRandomCurrentCars(15);

            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            string patternInitialTrim = @"(?<=\{)(.*)(?=\})";
            string delimiterToSplit = "||";
            string textToDeleteFirst = " ";
            string textToDeleteSecond = "=";
            string brandMatch = @"(?<=Brand)(.*?)(?=\|)";
            string modelMatch = @"(?<=Model)(.*?)(?=\|)";
            string numberPlateMatch = @"(?<=NumberPlate)(.*?)(?=\|)";
            string colourMatch = @"(?<=Color)(.*?)(?=\|)";
            string yearMatch = @"(?<=Year)(.*?)(?=\|)";
            string statusMainMatch = @"(?<=Status)(.*?)(?=\|)";
            string statusSecondaryMatch = @"(?<=IsFitForUse)(.*?)(?=\|)";
            string guidMatch = @"(?<=CarId)(.*?)(?=\|)";

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
                    _outputManager.PrintMessage("5. Check your cars");
                    _outputManager.PrintMessage("6. Repair your car");
                    _outputManager.PrintMessage("7. Exit");
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
                            DisplayCustomerCars
                            (
                                _customerManager,
                                _portalInstance.UserData as Customer,
                                patternInitialTrim,
                                delimiterToSplit,
                                textToDeleteFirst,
                                textToDeleteSecond,
                                brandMatch,
                                modelMatch,
                                numberPlateMatch,
                                colourMatch,
                                yearMatch,
                                statusMainMatch,
                                statusSecondaryMatch
                            );

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
                    case "6":
                        if (_portalInstance.IsCustomer)
                        {
                            RepairCarFlow
                            (
                                _customerManager,
                                _portalInstance.UserData as Customer,
                                patternInitialTrim,
                                delimiterToSplit,
                                textToDeleteFirst,
                                textToDeleteSecond,
                                brandMatch,
                                modelMatch,
                                numberPlateMatch,
                                colourMatch,
                                yearMatch,
                                statusMainMatch,
                                statusSecondaryMatch,
                                guidMatch
                            );
                        }
                        else
                        {
                            _outputManager.PrintMessage("Program stopped");
                            Environment.Exit(0);
                        }
                        break;
                    case "7":
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

        // I THINK LOGIC OF DISPLAY SOMETHING IN CONSOLE SHOULD BE HERE ARE.
        public void DisplayCustomerCars
        (
            CustomerManager manager,
            Customer customer,
            string patternInitialTrim,
            string delimiterToSplit,
            string textToDeleteFirst,
            string textToDeleteSecond,
            string brandMatch,
            string modelMatch,
            string numberPlateMatch,
            string colourMatch,
            string yearMatch,
            string statusMainMatch,
            string statusSecondaryMatch
        )
        {
            _outputManager.PrintCarsInfoOfCustomerInTable
            (
                manager.ShowCars(customer, _carServiceManager),
                delimiterToSplit,
                patternInitialTrim,
                textToDeleteFirst,
                textToDeleteSecond,
                brandMatch,
                modelMatch,
                numberPlateMatch,
                colourMatch,
                yearMatch,
                statusMainMatch,
                statusSecondaryMatch
            );
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
                _customerManager.BuyCar(car, _portalInstance.UserData as Customer, this._carServiceManager);
            }
            else
            {
                _customerManager.RentCar(car, _portalInstance.UserData as Customer, this._carServiceManager);
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

        public void RepairCarFlow
        (
            CustomerManager manager,
            Customer customer,
            string patternInitialTrim,
            string delimiterToSplit,
            string textToDeleteFirst,
            string textToDeleteSecond,
            string brandMatch,
            string modelMatch,
            string numberPlateMatch,
            string colourMatch,
            string yearMatch,
            string statusMainMatch,
            string statusSecondaryMatch,
            string guidMatch
        )
        {
            // I JUST MIMICED METHODS ABOVE. DECIDED TO NOT DIFFERENT SOLUTION.
            _outputManager.ClearUserUI();

            DisplayCustomerCars
            (
                manager,
                customer,
                patternInitialTrim,
                delimiterToSplit,
                textToDeleteFirst,
                textToDeleteSecond,
                brandMatch,
                modelMatch,
                numberPlateMatch,
                colourMatch,
                yearMatch,
                statusMainMatch,
                statusSecondaryMatch
            );

            _outputManager.PrintMessage("");

            int numberInput;
            string input;
            string iD;
            bool isInputSuccessfull = false;

            if (customer.Cars.Count == 0)
            {
                _outputManager.PrintMessage("DEAR CUSTOMER, YOU HAVE NO ANY CAR TO REPAIR!!!");

                return;
            }

            // DO I MAKE DUPLICATE OF MY OWN LOGIC???
            string inputInfo = manager.ShowCars(customer, _carServiceManager);

            string[] carsInfo = inputInfo.Split(delimiterToSplit); 

            // UPPER BORDER OF COUNT VALIDATION??? MAYBE I WILL.
            for (int index = 0; index < carsInfo.Length; index = index + 1)
            {
                if (string.IsNullOrEmpty(carsInfo[index]))
                {
                    continue;
                }
                else
                {
                    carsInfo[index] = Regex.Match(carsInfo[index], patternInitialTrim).Value;  // STATIC, NO GC ADDITIONAL WORK.

                    carsInfo[index] = carsInfo[index].Replace(textToDeleteFirst, string.Empty); // TRIM WILL NOT WORK.

                    carsInfo[index] = carsInfo[index].Replace(textToDeleteSecond, string.Empty);
                }
            }

            do
            {
                _outputManager.PrintMessage("SELECT A CAR WHICH YOU WANT TO REPAIR BY ITS NUMBER №:");

                input = _outputManager.GetUserPrompt();

                isInputSuccessfull = int.TryParse(input, out numberInput) && (numberInput < customer.Cars.Count);

                if (!isInputSuccessfull)
                {
                    _outputManager.PrintMessage("YOU MADE A WRONG CHOICE!!! PLEASE, MAKE CORRECT SELECTION OF A CAR!");
                }
            }
            while (!isInputSuccessfull);

            iD = Regex.Match(carsInfo[numberInput], guidMatch).Value;

            Guid guid = new Guid(iD);

            // LOOKING FOR CAR BY ITS GUID, INSTEAD OF INDEX.
            Car car = _carServiceManager.ChooseCarFromList(customer.Cars, guid);

            // CREATE RANDOM MECHANIC.
            
            Mechanic mechanic = _mechanicManager.GetNewRandomMechanic();

            // DUE IT IS THE REFERENCE TYPE, THIS OPERATION SHOULD AFFECT THE INSTANCE IN customer.Cars LIST.
            _carServiceManager.Repair(car, mechanic);

            bool isSuccessfull = (bool)car.IsFitForUse;

            if (isSuccessfull)
            {
                _outputManager.PrintMessage("YOUR CAR IS REPAIRED SUCCESSFULLY!!!");
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage(_carServiceManager.DisplayCar(car));
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("REPAIR HISTORY:");

                foreach (Repair repair in car.Repairs)
                {
                    _outputManager.PrintMessage(_repairManager.ShowRepairInfo(repair));

                }

                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Press any key to continue...");
                _outputManager.GetUserPrompt();
            }
            else
            {
                _outputManager.PrintMessage("YOUR CAR IS NOT REPAIRED!!!");

                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Press any key to continue...");
                _outputManager.GetUserPrompt();
            }
        }
    }
}
