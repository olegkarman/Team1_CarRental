using CarRental.Data.Models.Gateway;
using CarRental.Data.Models;
using CarRental.BussinessLayer.Interfaces;
using System;
using System.Text;
using CarRental.Data.Models.Automobile;
using CarRental.BussinessLayer.Validators;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using CarRental.Data.Models.Automobile.RecordTypes;

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
        private DealManager _dealManager;
        private BrandManager _brandManager;

        public PortalManager() { }
        public PortalManager(Portal portal, IOutputManager outputManager)
        {
            _portalInstance = portal;
            _outputManager = outputManager;
            _carServiceManager = new ServiceManager();
            _inspectorCars = new InspectorCars();
            _customerManager = new CustomerManager();
            _inspectionsManager = new InspectionsManager();

            _dealManager = new DealManager
            {
                _indexValidator = new IndexOfListValidation(),
                _nameValidator = new UpdatedNameValidator(),
                _validator = new NullValidation()
            };

            _brandManager = new BrandManager
            {
                NullValidator = new NullValidation(),
                IndexValidator = new IndexOfListValidation()
            };
        }

        public void StartMainMenu(string connectionString, bool bulkInsertFlag)
        {
            _carServiceManager.InitializeManagment();

            // TO CONFIGURE ORM FOR Car-CLASS.
            _carServiceManager.SupplementData.DapperConfigs.ConfigureGuidToStringMapping();
            _carServiceManager.SupplementData.DapperConfigs.SetCustomMappingForEntities();

            // IF CUSTOMER IS NOT EXISTS IN A DATABSE, ADD IT THEN.
            if (_portalInstance.IsCustomer)
            {
                bool isCustomerInDb = (bool)_customerManager.IsCustomerInDatabase(_portalInstance.UserData.IdNumber, connectionString);

                if (!isCustomerInDb)
                {
                    Customer customer = _portalInstance.UserData as Customer;

                    _customerManager.AddCustomerIntoDatabase(customer, connectionString);
                }
            }

            _carServiceManager.GetNewRandomCurrentCars(15);

            // BULKINSERT TEST-SECTION

            //foreach (Car car in _carServiceManager.CurrentCars)
            //{
            //    Console.WriteLine(car);
            //}

            if (bulkInsertFlag)
            {
                _carServiceManager.BulkAddCurrentCarsIntoDatabase(connectionString);
            }
            else
            {
                _carServiceManager.AddCurrentCarsIntoDatabase(connectionString);
            }

            // END OF TEST-SECTION

            //_carServiceManager.AddCurrentCarsIntoDatabase(connectionString);

            // COPY CARS FROM A DATABASE TO THE CUSTOMERINSTANCE CORRESPONDING PROPERTY.
            if (_portalInstance.IsCustomer)
            {
                Customer customer = _portalInstance.UserData as Customer;

                customer.Cars = _carServiceManager.GetAllCarsOfCustomerFromDatabase(_portalInstance.UserData.IdNumber, connectionString);
            }

            ShowMainMenu(connectionString);
        }

        public void ShowMainMenu(string connectionString)
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
                            BuyRentCarFlow(connectionString);
                        }
                        else
                        {
                            InspectCarFlow();
                        }
                        break;
                    case "3":
                        if (_portalInstance.IsCustomer)
                        {
                            BuyRentCarFlow(connectionString, false);
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
                                guidMatch,
                                connectionString
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
            ShowMainMenu(connectionString);
        }

        public void DisplayCars()
        {
            _carServiceManager.DisplayCarsInTable(_outputManager);
        }

        // I THINK LOGIC OF DISPLAY SOMETHING IN CONSOLE USING OUTPUT MANAGER SHOULD BE HERE ARE.
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

        public void BuyRentCarFlow(string connectionString, bool buy = true)
        {
            _outputManager.ClearUserUI();
            DisplayCars();
            _outputManager.PrintMessage("");
            int index;
            while (true)
            {
                _outputManager.PrintMessage($"Which car do you want to buy? Select from 1 to {_carServiceManager.CurrentCars.Count}");
                string input = _outputManager.GetUserPrompt();

                if (int.TryParse(input, out index) && (index >= 1) && (index <= _carServiceManager.CurrentCars.Count)) // FIXED 15-VALUE CONST.
                {
                    break;
                }

                _outputManager.PrintMessage($"Error: Please enter a valid number from 1 to {_carServiceManager.CurrentCars.Count}.");
            }
            var car = _carServiceManager.GetCarFromCurrentCars(index - 1);
            if (buy)
            {
                _customerManager.BuyCar(car, _portalInstance.UserData as Customer, this._carServiceManager, this._dealManager, connectionString);
            }
            else
            {
                _customerManager.RentCar(car, _portalInstance.UserData as Customer, this._carServiceManager, this._dealManager, connectionString);
            }
            _outputManager.PrintMessage($"You have successfully {(buy ? "bought" : "rented")} a car");
            _carServiceManager.DeleteCarFromCurrentCars(index - 1);
            _outputManager.ClearUserUI();
            ShowMainMenu(connectionString);
        }

        public void InspectCarFlow()
        {
            _outputManager.ClearUserUI();
            DisplayCars();
            _outputManager.PrintMessage("");
            int index;
            while (true)
            {
                _outputManager.PrintMessage($"Which car do you want to inspect? Select from 1 to {_carServiceManager.CurrentCars.Count}");
                string input = _outputManager.GetUserPrompt();

                if (int.TryParse(input, out index) && (index >= 1) && (index <= _carServiceManager.CurrentCars.Count)) // FIXED 'HARD-CODE' SO-CALLED.
                {
                    break;
                }

                _outputManager.PrintMessage($"Error: Please enter a valid number from 1 to {_carServiceManager.CurrentCars.Count}.");
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
            string guidMatch,
            string connectionString
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

            // CREATE/PICK FROM DATABASE RANDOM MECHANIC.

            Guid yaroslav = new Guid("0BBEF7B3-CE96-4DC6-AF5D-899106C9BFD5");
            Guid soldier = new Guid("4B445309-CBC5-4895-8E02-4BAA0001238A");
            Guid theSummoner = new Guid("5FC4F1FD-396A-42B2-B4D4-8832091108AD");
            Guid roxy = new Guid("685F0F5D-2328-40B5-A32D-6E9233D55B96");
            Guid theMaster = new Guid("6ECCC761-9A37-46CD-BC24-C326D8BE544E");

            Guid selectedMechanic;

            Random random = new Random();

            int mechanicSelector = random.Next(0, 5);

            switch(mechanicSelector)
            {
                case 0:
                    selectedMechanic = yaroslav;
                    break;
                case 1:
                    selectedMechanic = soldier;
                    break;
                case 2:
                    selectedMechanic = theSummoner;
                    break;
                case 3:
                    selectedMechanic = roxy;
                    break;
                case 4:
                    selectedMechanic = theMaster;
                    break;
                default:
                    selectedMechanic = theMaster;
                    break;
            }

            Mechanic mechanic = _carServiceManager.SupplementData.MechanicalManager.GetMechanicFromDatabase(selectedMechanic, connectionString);

            //Mechanic mechanic = _carServiceManager.SupplementData.MechanicalManager.GetNewRandomMechanic();

            // DUE IT IS THE REFERENCE TYPE, THIS OPERATION SHOULD AFFECT THE INSTANCE IN customer.Cars LIST.
            _carServiceManager.Repair(car, mechanic, connectionString);

            bool isSuccessfull = (bool)car.IsFitForUse;

            _carServiceManager.ChangeCarIsFitForUse(car.CarId, isSuccessfull, connectionString);

            if (isSuccessfull)
            {
                _outputManager.PrintMessage("YOUR CAR IS FUNCTIONAL!");
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage(_carServiceManager.DisplayCar(car));
                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("REPAIR HISTORY:");

                foreach (Repair repair in car.Repairs)
                {
                    if (repair == null)
                    {
                        continue;
                    }

                    _outputManager.PrintMessage(_carServiceManager.SupplementData.JunkRepairManager.ShowRepairInfo(repair));
                }

                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Press any key to continue...");
                _outputManager.GetUserPrompt();
            }
            else
            {
                _outputManager.PrintMessage("FAIL!!!");

                _outputManager.PrintMessage("");
                _outputManager.PrintMessage("Press any key to continue...");
                _outputManager.GetUserPrompt();
            }
        }
    }
}
