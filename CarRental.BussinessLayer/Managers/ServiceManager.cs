using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.BussinessLayer.ExtensionMethods;
using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile.RecordTypes;
using System.Drawing;
using CarRental.Data.Models.RecordTypes;
using CarRental.Data.Models.Checkup;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Diagnostics;
using System.Data;

namespace CarRental.BussinessLayer.Managers;

public class ServiceManager : ICarManager
{
    // THE PURPOSE OF THE CLAS:
    //      TO HOLD A LIST OF CARS AND TO OPERATE WITH IT.

    // FIELDS

    private const string _noInfo = "NO INFORMATION";
    private StringBuilder _carsInfo;
    private Random _random;


    // PROPERTTES

    internal List<Car>? CurrentCars { get; private set; }
    internal Car? SelectedCar { get; private set; }
    public ServiceManagerSupplements SupplementData { get; private set; }

    // CONSTRUCTORS

    public ServiceManager()
    {
        this._random = new Random();
        this._carsInfo = new StringBuilder();
        this.CurrentCars = new List<Car>();
    }

    // METHODS

    // CREATE

    public Car GetNewCar(Guid carId, string vinCode, string model, string brand, string numberPlate, int price)
    {
        SupplementData.Validator.CheckNull(vinCode, model, brand, numberPlate);

        Car car = new Car
        {
            CarId = carId,
            VinCode = vinCode,
            Model = model,
            Brand = brand,
            NumberPlate = numberPlate,
            Price = price
        };

        SupplementData.NullValidator.CheckNull(car);

        return car;
    }

    public Car GetNewCar
    (
        Guid carId,
        string vinCode,
        string model,
        string brand,
        int year,
        string numberPlate,
        int price,
        string engine,
        string transmission,
        string interior,
        string wheels,
        string lights,
        string signal,
        KnownColor color,
        int numberOfSeats,
        int numberOfDoors,
        float mileage,
        int maxFuelCapacity,
        float currentFuel,
        TransportStatus status,
        bool isFitForUse
    )
    {
        // CHECK ONLY NECCESSARY COMPONENTS.
        SupplementData.Validator.CheckNull(vinCode, model, brand, numberPlate);

        Car car = new Car
        {
            CarId = carId,
            VinCode = vinCode,
            Model = model,
            Brand = brand,
            Year = year,
            NumberPlate = numberPlate,
            Price = price,
            Engine = engine,
            Transmission = transmission,
            Interior = interior,
            Wheels = wheels,
            Lights = lights,
            Signal = signal,
            Color = color,
            NumberOfSeats = numberOfSeats,
            NumberOfDoors = numberOfDoors,
            Mileage = mileage,
            MaxFuelCapacity = maxFuelCapacity,
            CurrentFuel = currentFuel,
            Status = status,
            IsFitForUse = isFitForUse,
            Repairs = new List<Repair>()
        };

        SupplementData.NullValidator.CheckNull(car);

        return car;
    }

    public Car GetNewRandomCar()
    {
        Guid carId = SupplementData.RandomCarGenerator.GetNewCarId();
        string vinCode = SupplementData.RandomCarGenerator.GetNewVinCode();
        string model = SupplementData.RandomCarGenerator.GetNewModelName();
        string brand = SupplementData.RandomCarGenerator.GetNewBrandName();
        string numberPlate = SupplementData.RandomCarGenerator.GetNewNumberPlate();
        int price = SupplementData.RandomCarGenerator.GetNewPrice();

        string engine = SupplementData.RandomCarGenerator.GetNewEngine();
        string transmission = SupplementData.RandomCarGenerator.GetNewTransmission();
        string interior = SupplementData.RandomCarGenerator.GetNewInterior();
        string wheels = SupplementData.RandomCarGenerator.GetNewWheels();
        string lights = SupplementData.RandomCarGenerator.GetNewLights();
        string signal = SupplementData.RandomCarGenerator.GetNewSignal();
        KnownColor color = SupplementData.RandomCarGenerator.GetNewColor();
        int numberOfSeats = SupplementData.RandomCarGenerator.GetNewNumberOfSeats();
        int numberOfDoors = SupplementData.RandomCarGenerator.GetNewNumberOfDoors();
        int year = SupplementData.RandomCarGenerator.GetNewYear();
        float mileage = SupplementData.RandomCarGenerator.GetNewMileage();
        int maxFuelCapacity = SupplementData.RandomCarGenerator.GetNewMaxFuelCapacity();
        float currentFuel = SupplementData.RandomCarGenerator.GetNewCurrentFuel();
        TransportStatus status = SupplementData.RandomCarGenerator.GetNewStatus();
        bool isFitForUse = SupplementData.RandomCarGenerator.GetNewIsFitForUse();

        Car car = new Car
        {
            CarId = carId,
            VinCode = vinCode,
            Model = model,
            Brand = brand,
            Year = year,
            NumberPlate = numberPlate,
            Price = price,
            Engine = engine,
            Transmission = transmission,
            Interior = interior,
            Wheels = wheels,
            Lights = lights,
            Signal = signal,
            Color = color,
            NumberOfSeats = numberOfSeats,
            NumberOfDoors = numberOfDoors,
            Mileage = mileage,
            MaxFuelCapacity = maxFuelCapacity,
            CurrentFuel = currentFuel,
            Status = status,
            IsFitForUse = isFitForUse,
            Repairs = new List<Repair>()
        };

        SupplementData.NullValidator.CheckNull(car);

        return car;
    }

    public List<Car> MakeNewListOfCars()
    {
        return new List<Car>();
    }

    public void AddCarInToList(List<Car> cars, Car car)
    {
        SupplementData.NullValidator.CheckNull(cars);
        SupplementData.NullValidator.CheckNull(car);

        cars.Add(car);
    }

    public void GetNewRandomCurrentCars(int count)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        this.CurrentCars.Clear();

        for (int index = 0; index < count; index = index + 1)
        {
            this.CurrentCars.Add(GetNewRandomCar());
        }
    }

    public void AddCarIntoDatabase(Car car, string connectionString)
    {
        SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

        string query = "CreateCar";

        int? status = (int?)car.Status;
        //int? statusId;

        switch (status)
        {
            case 0:
                status = 6;
                break;
            case 1:
                status = 1;
                break;
            case 2:
                status = 3;
                break;
            case 3:
                status = 4;
                break;
            case 4:
                status = 2;
                break;
            case 200:
                status = 5;
                break;
        }
        
        // I DO NOT UNDERSTAND THIS SYNTAXIS.
        Object objectArguments = new
        {
            carId = car.CarId,
            vinCode = car.VinCode,
            //customerId = null, //car.Owner.IdNumber, // ANONYMOUS TYPE NULL PROBLEMS.
            numberPlate = car.NumberPlate,
            brand = car.Brand,
            model = car.Model,
            price = car.Price,
            numberOfSeats = car.NumberOfSeats,
            numberOfDoors = car.NumberOfDoors,
            mileage = car.Mileage,
            maxFuelCapacity = car.MaxFuelCapacity,
            currentFuel = car.CurrentFuel,
            year = car.Year,
            isFitForUse = car.IsFitForUse,
            engine = car.Engine,
            transmission = car.Transmission,
            interior = car.Interior,
            wheels = car.Wheels,
            lights = car.Lights,
            signal = car.Signal,
            color = car.Color,
            //dealId = car.Engagement.Id,
            statusId = status
        };

        connection.ExecuteScalar(query, objectArguments);

        SupplementData.DataContext.CloseConnection(connection);
    }

    public void AddCurrentCarsIntoDatabase(string connectionString)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        foreach (Car car in CurrentCars)
        {
            AddCarIntoDatabase(car, connectionString);
        }
    }

    // RETRIVE

    public List<Car> GetAllCarsOfCustomerFromDatabase(string customerId, string connectionString)
    {
        SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

        string SqlStoredProcedureName = "GetAllCarsOfCustomer";
        string id = customerId.ToUpper();

        object parameter = new
        {
            CustomerId = id
        };

        List<Car> cars = new List<Car>
        (
            connection.Query<Car, CustomerTemp?, Deal?, Inspection?, Repair?, Car>
            (
               SqlStoredProcedureName,
               (car, customerTemp, deal, inspection, repair) =>
               {
                   car.Owner = customerTemp;
                   car.Engagement = deal;
                   car.Inspections.Add(inspection);
                   car.Repairs.Add(repair);

                   return car;
               },
               parameter,
               splitOn: "userIdNumber, dealId, inspectionInspectionId, repairId"
            )
        );

        //IEnumerable<IGrouping<Guid, Car>> groupedCars = cars.GroupBy(c => c.CarId);

        List<IGrouping<Guid, Car>> groupedCars = new List<IGrouping<Guid, Car>>(cars.GroupBy(c => c.CarId));

        List<Car> resultCars = new List<Car>();

        foreach (IGrouping<Guid, Car> group in groupedCars)
        {
            Car car = group.First();

            car.Inspections = cars.Select(c => c.Inspections.Single()).DistinctBy(i => i?.InspectionId).ToList();

            car.Repairs = cars.Select(c => c.Repairs.Single()).DistinctBy(r => r?.Id).ToList();

            resultCars.Add(car);
        }

        SupplementData.DataContext.CloseConnection(connection);

        return resultCars;
    }

    public bool? IsCarInDatabase(Guid id, string connectionString)
    {
        SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

        string SqlStoredProcedureName = "CheckIfCarEntryExist";
        string carId = id.ToString().ToUpper();

        object parameter = new
        {
            Id = carId
        };

        //DynamicParameters dynamicParameters = new DynamicParameters();

        //dynamicParameters.Add("RowCount", DbType.Int32, direction: ParameterDirection.Output);

        int result = connection.ExecuteScalar<int>(SqlStoredProcedureName, parameter);

        //result = dynamicParameters.Get<int>("RowCount");

        SupplementData.DataContext.CloseConnection(connection);

        if (result == 1)
        {
            return true;
        }
        else if (result == 0)
        {
            return false;
        }
        else
        {
            return null;
        }
    }

    public Car GetCarFromDatabase(Guid id, string connectionString)
    {
        SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

        string SqlStoredProcedureName = "GetCar";
        string carId = id.ToString().ToUpper();

        object parameter = new
        {
            Id = carId
        };

        List<Car> cars = new List<Car>
        (
            connection.Query<Car, CustomerTemp?, Deal?, Inspection?, Repair?, Car>
            (
               SqlStoredProcedureName,
               (car, customerTemp, deal, inspection, repair) =>
               {
                   car.Owner = customerTemp;
                   car.Engagement = deal;
                   car.Inspections.Add(inspection);
                   car.Repairs.Add(repair);

                   return car;
               },
               parameter,
               splitOn: "userIdNumber, dealId, inspectionInspectionId, repairId"
            )
        );

        // LAMBDA-EXPRESSION APPROACH

        //IEnumerable<IGrouping<Guid, Car>> groupedCars = cars.GroupBy(c => c.CarId);

        Car car = cars.First();

        car.Inspections = cars.Select(c => c.Inspections.Single()).DistinctBy(i => i?.InspectionId).ToList();

        car.Repairs = cars.Select(c => c.Repairs.Single()).DistinctBy(r => r?.Id).ToList();

        SupplementData.DataContext.CloseConnection(connection);

        return car;
    }

    public Car ChooseCarFromList(List<Car> cars, int index)
    {

        SupplementData.NullValidator.CheckNull(cars);

        SupplementData.IndexValidator.ValidateIndexOfList(cars, index);

        Car car = cars[index];

        SupplementData.NullValidator.CheckNull(car);

        return car;
    }

    public Car ChooseCarFromList(List<Car> cars, string model)
    {
        SupplementData.NullValidator.CheckNull(cars);
        SupplementData.Validator.CheckNullEmpty(model);

        try
        {
            // THE EMPTY LINE CAN APPEAR.
            return cars.Find(x => x.Model.Contains(model));
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
        catch (NullReferenceException exception)
        {
            throw exception;
        }
        catch (FormatException exception)
        {
            throw exception;
        }
    }

    public Car ChooseCarFromList(List<Car> cars, Guid guid)
    {
        SupplementData.NullValidator.CheckNull(cars);

        try
        {
            return cars.Find(x => x.CarId.CompareTo(guid) == 0);
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
        catch (NullReferenceException exception)
        {
            throw exception;
        }
        catch (FormatException exception)
        {
            throw exception;
        }
    }

    public void SelectCarFromCurrentCars(int index)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, index);
    }

    public void SelectCarFromCurrentCars(string model)
    {
        SupplementData.Validator.CheckNullEmpty(model);
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, model);
    }

    public void SelectCarFromCurrentCars(Guid guid)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, guid);
    }

    public Car GetCarFromCurrentCars(int index)
    {
        return ChooseCarFromList(CurrentCars, index);
    }

    public Car GetCarFromCurrentCars(Guid guid)
    {
        return ChooseCarFromList(CurrentCars, guid);
    }

    public void TakeCarFromCurrentCars(int index)
    {
        SelectedCar = ChooseCarFromList(CurrentCars, index);
        CurrentCars.RemoveAt(index);
    }

    public void TakeCarFromCurrentCars(Guid guid)
    {
        SelectedCar = ChooseCarFromList(CurrentCars, guid);
        CurrentCars.RemoveAt(CurrentCars.IndexOf(ChooseCarFromList(CurrentCars, guid)));
    }

    public void MoveCarFromCurrentCarsToSelected(string model)
    {
        SupplementData.Validator.CheckNullEmpty(model);

        Car car;

        SupplementData.NullValidator.CheckNull(CurrentCars);

        car = ChooseCarFromList(CurrentCars, model);

        SupplementData.NullValidator.CheckNull(car);

        this.SelectedCar = car;

        CurrentCars.RemoveAt(CurrentCars.IndexOf(ChooseCarFromList(CurrentCars, model)));
    }

    public void MoveCarFromCurrentCarsToSelected(Guid guid)
    {
        Car car;

        SupplementData.NullValidator.CheckNull(CurrentCars);

        car = ChooseCarFromList(CurrentCars, guid);

        SupplementData.NullValidator.CheckNull(car);

        this.SelectedCar = car;

        CurrentCars.RemoveAt(CurrentCars.IndexOf(ChooseCarFromList(CurrentCars, guid)));
    }

    public string DisplaySelectedCar()
    {
        try
        {
            return this.SelectedCar.ToString();
        }
        catch (ArgumentNullException exception)
        {
            throw exception;
        }
    }

    public string DisplayCarFromList(List<Car> cars, int index)
    {
        SupplementData.NullValidator.CheckNull(cars);

        return ChooseCarFromList(cars, index).ToString();
    }

    public string DisplayCarFromList(List<Car> cars, string model)
    {
        SupplementData.Validator.CheckNullEmpty(model);
        SupplementData.NullValidator.CheckNull(cars);

        return ChooseCarFromList(cars, model).ToString();
    }

    public string DisplayCarFromList(List<Car> cars, Guid guid)
    {
        SupplementData.NullValidator.CheckNull(cars);

        return ChooseCarFromList(cars, guid).ToString();
    }

    public string DisplayCarFromCurrentCars(int index)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, index).ToString();
    }

    public string DisplayCarFromCurrentCars(string model)
    {
        SupplementData.Validator.CheckNullEmpty(model);
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, model).ToString();
    }

    public string DisplayCarFromCurrentCars(Guid guid)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, guid).ToString();
    }

    public string DisplayCar(Car car)
    {
        SupplementData.NullValidator.CheckNull(car);

        return $"{nameof(car)} | {car.ToString()}";
    }

    // TO DISPLAY LIST OF CARS IN TABLE
    // //
    // // ~THIS METHOD ADDED AND EDITED NOT BY YPARKHOMENKO~
    // //
    // // ADVICE BY YPARKHOMENKO: DO NOT USE STRING CONCATINATION IN LOOPS, USE StringBuilder-CLASS FUNCTIONALITY INSTEAD.
    // // BETTER TO USE STRING OUTPUT RATHER THAN THE CONSOLE OUTPUT.
    // //

    public void DisplayCarsInTable(IOutputManager outputManager)
    {
        // ADD NULL CHECK-UP

        if (CurrentCars == null)
        {
            throw new ArgumentNullException(nameof(this.CurrentCars));
        }

        string line = new string('-', 110); // adjust the number to fit your table
        string format = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-20}";

        outputManager.PrintMessage(format, "Index", "Brand", "Model", "Year", "Price", "Status", "FitForUse", "PlateNumber", "VinCode");
        outputManager.PrintMessage(line);

        for (int i = 0; i < CurrentCars.Count; i++)
        {
            var car = CurrentCars[i];
            outputManager.PrintMessage(format, i + 1, car.Brand, car.Model, car.Year, car.Price, car.Status, car.IsFitForUse, car.NumberPlate, car.VinCode);
        }
    }

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"({CurrentCars.IndexOf(car)})~~| {car.Brand} -- {car.Model} -- YEAR: {car.Year}\n-- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.NumberPlate} -- VINCODE: {car.VinCode} |~~\n");
        }

        return _carsInfo.ToString();
    }

    //public string CheckFuelCar(Car car)
    //{
    //    SupplementData.NullValidator.CheckNull(car);

    //    _carsInfo.Clear();

    //    try
    //    {
    //        float? division = (float?)SupplementData.Mechanic.CheckFuel(car) / car.MaxFuelCapacity;

    //        division = (float)division * 100;

    //        _carsInfo.Append($"{(int)division}%");

    //        return _carsInfo.ToString();
    //    }
    //    catch (DivideByZeroException exception)
    //    {
    //        throw exception;
    //    }
    //}

    //public string CheckFuelSelectedCar()
    //{
    //    return CheckFuelCar(SelectedCar);
    //}

    public string ShowMileage(Car car)
    {
        SupplementData.NullValidator.CheckNull(car);

        return car.Mileage.ToString();
    }

    public string ShowMileageSelectedCar()
    {
        return ShowMileage(this.SelectedCar);
    }

    public string CheckSignal(Car car)
    {
        SupplementData.NullValidator.CheckNull(car);

        return car.Signal.ToString();
    }

    public string CheckLights(Car car)
    {
        SupplementData.NullValidator.CheckNull(car);

        return car.Lights.ToString();
    }

    public string CheckTechInfo(Car car)
    {
        return car.TechnicalInfo();
    }

    public string CheckExpoitation(Car car)
    {
        return car.ExploitationInfo();
    }

    public string ShowDeal(Car car)
    {
        SupplementData.NullValidator.CheckNull(car);

        return $"{car.Engagement.ToString()}";
    }

    //public Car RetriveCarFromDatabase(string connectionString)
    //{
    //    SupplementData.DataContext.OpenConnection(connectionString)



    //    return car;
    //}

    // UPDATE

    public void ChangeCarDealshipInDatabase(Guid carGuid, Guid dealId, string connectionString)
    {
        SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

        // ADD SOME VALIDATION AGAINST SO-CALLED SQL-INJECTION.

        string id = dealId.ToString().ToUpper();

        string carId = carGuid.ToString().ToUpper();

        object arguments = new
        {
            id = id,
            dealId = dealId
        };

        string sqlStatement =
        @"
            UPDATE Cars
                SET DealId = @id
                WHERE CarId = @dealId;
        ";

        connection.Execute(sqlStatement, arguments);

        SupplementData.DataContext.CloseConnection(connection);
    }

    public void ChangeCarOwnershipInDatabase(Guid carGuid, string customerId, string connectionString)
    {
        SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

        // ADD SOME VALIDATION AGAINST SO-CALLED SQL-INJECTION.

        string id = customerId.ToUpper();
        //string id = customerId;

        string carId = carGuid.ToString().ToUpper();

        object arguments = new
        {
            id = id,
            carId = carId
        };

        string sqlStatement =
        @"
            UPDATE Cars
                SET CustomerId = @id
                WHERE CarId = @carId;
        ";

        connection.Execute(sqlStatement, arguments);

        SupplementData.DataContext.CloseConnection(connection);
    }

    public void ChangeEngine (Car car, string engine)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.NullValidator.CheckNull(engine);

        car.Engine = engine;
    }

    public void ChangeTransmission(Car car, string transmission)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.NullValidator.CheckNull(transmission);

        car.Transmission = transmission;
    }

    public void ChangeInterior(Car car, string interior)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.NullValidator.CheckNull(interior);

        car.Interior = interior;
    }

    public void ChangeWheels(Car car, string wheels)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.NullValidator.CheckNull(wheels);

        car.Wheels = wheels;
    }

    public void ChangeLights(Car car, string lights)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.NullValidator.CheckNull(lights);

        car.Lights = lights;
    }

    public void ChangeSignal(Car car, string signal)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.NullValidator.CheckNull(signal);

        car.Signal = signal;
    }

    public void ChangeColor(Car car, KnownColor color)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.Validator.CheckType(color);

        car.Color = color;
    }

    public void ChangePrice(Car car, int price)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.Validator.CheckPrice(price);

        car.Price = price;
    }

    public void ChangeNumberPlate(Car car, string numberPlate)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.NullValidator.CheckNull(numberPlate);

        car.NumberPlate = numberPlate;
    }

    public void ChangeNumberOfSeats(Car car, int number)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.Validator.CheckZeroNegative(number);

        car.NumberOfSeats = number;
    }

    public void ChangeNumberDoors(Car car, int number)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.Validator.CheckZeroNegative(number);

        car.NumberOfDoors = number;
    }

    public void ChangeMileage(Car car, float mileage)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.Validator.CheckZeroNegative(mileage);

        car.Mileage = mileage;
    }

    public void ChangeMaxFuelCapacity(Car car, int capacity)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.Validator.CheckZeroNegative(capacity);

        car.MaxFuelCapacity = capacity;
    }

    public void ChangeCurrentFuel(Car car, float capacity)
    {
        SupplementData.NullValidator.CheckNull(car);
        SupplementData.Validator.CheckZeroNegative(capacity);

        car.CurrentFuel = capacity;
    }

    public void ChangeFitForUse(Car car, bool isUse)
    {
        SupplementData.NullValidator.CheckNull(car);

        car.IsFitForUse = isUse;
    }

    public void ChangeCarStatus(Car car, TransportStatus status)
    {
        SupplementData.NullValidator.CheckNull(car);

        SupplementData.Validator.CheckType(status);

        car.Status = status;
    }

    public void ChangeCarStatus(Car car, int status)
    {
        SupplementData.NullValidator.CheckNull(car);

        SupplementData.Validator.CheckType((TransportStatus)status);

        car.Status = (TransportStatus)status;
    }

    public void ChangeCurrentCarStatus(int index, TransportStatus status)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        Car car = ChooseCarFromList(CurrentCars, index);

        SupplementData.NullValidator.CheckNull(car);

        SupplementData.Validator.CheckType(status);

        CurrentCars[index].Status = status;
    }

    public void ChangeCurrentCarStatus(Guid guid, TransportStatus status)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        Car car = ChooseCarFromList(CurrentCars, guid);

        SupplementData.NullValidator.CheckNull(car);

        SupplementData.Validator.CheckType(status);

        // THIS IS A REFEREBCE TYPE, THE CHANGE WILL AFFECT CAR INSTANCE IN THE LIST.
        car.Status = status;
    }

    public void ChangeCarsStatus(List<Car> cars, TransportStatus status)
    {
        SupplementData.NullValidator.CheckNull(cars);
        SupplementData.Validator.CheckType(status);
        
        foreach(Car car in cars)
        {
            car.Status = status;
        }
    }

    public void ChangeCurrentCarsStatus(TransportStatus status)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        SupplementData.Validator.CheckType(status);

        foreach (Car car in CurrentCars)
        {
            car.Status = status;
        }
    }

    public void ChangeSelectedCarStatus(TransportStatus status)
    {
        SupplementData.NullValidator.CheckNull(this.SelectedCar);
        SupplementData.Validator.CheckType(status);

        this.SelectedCar.Status = status;
    }

    public void ChangerOwner(Car car, Customer owner)
    {
        SupplementData.NullValidator.CheckNull(car);

        // I SHOULD CHECK CUSTOMER OVER NULL.
        car.Owner = owner;
    }

    public void Repair(Car car, Mechanic mechanic)
    {
        SupplementData.NullValidator.CheckNull(car);

        bool isSuccessfull;

        SupplementData.NullValidator.CheckNull(car.IsFitForUse);

        bool isFitForUse = (bool)car.IsFitForUse;

        int chance;

        if ((car.Status == (TransportStatus)0) || (car.Status == (TransportStatus)4) || (car.Status == (TransportStatus)200))
        {
            // REPRESENT NOT 100% PROBABILITY TO REPAIR THE CAR.
            chance = _random.Next(0, 11);

            if (chance > 1)
            {
                isSuccessfull = true;

                car.Status = (TransportStatus)1;

                Repair repair = SupplementData.JunkRepairManager.GetNewRepair(car, mechanic, isSuccessfull);

                AddRepairInToCar(car, repair);

                SupplementData.JunkRepairManager.AddRepairInToList(SupplementData.JunkRepairManager.Repairs, repair);

                SupplementData.MechanicalManager.AddRepairInToMechanicList(mechanic, repair);
            }
            else if (chance < 2)
            {
                isSuccessfull = false;

                Repair repair = SupplementData.JunkRepairManager.GetNewRepair(car, mechanic, isSuccessfull);

                AddRepairInToCar(car, repair);

                SupplementData.JunkRepairManager.AddRepairInToList(SupplementData.JunkRepairManager.Repairs, repair);

                SupplementData.MechanicalManager.AddRepairInToMechanicList(mechanic, repair);
            }
        }
        else if (!isFitForUse)
        {
            chance = _random.Next(0, 11);

            if (chance > 1)
            {
                isSuccessfull = true;

                car.IsFitForUse = true;

                Repair repair = SupplementData.JunkRepairManager.GetNewRepair(car, mechanic, isSuccessfull);

                AddRepairInToCar(car, repair);

                SupplementData.JunkRepairManager.AddRepairInToList(SupplementData.JunkRepairManager.Repairs, repair);

                SupplementData.MechanicalManager.AddRepairInToMechanicList(mechanic, repair);
            }
            else
            {
                isSuccessfull = false;

                Repair repair = SupplementData.JunkRepairManager.GetNewRepair(car, mechanic, isSuccessfull);

                AddRepairInToCar(car, repair);

                SupplementData.JunkRepairManager.AddRepairInToList(SupplementData.JunkRepairManager.Repairs, repair);

                SupplementData.MechanicalManager.AddRepairInToMechanicList(mechanic, repair);
            }
        }
    }

    public void AddRepairInToCar(Car car, Repair repair)
    {
        SupplementData.NullValidator.CheckNull(car);

        SupplementData.JunkRepairManager.AddRepairInToList(car.Repairs, repair);
    }

    public void AddDealToCar(Car car, Deal deal)
    {
        SupplementData.NullValidator.CheckNull(car);

        // CHECK NULL DEAL

        car.Engagement = deal;
    }

    // DELETE

    public void DeleteCarFromList(List<Car> list, int index)
    {
        try
        {
            SupplementData.NullValidator.CheckNull(list);

            list.RemoveAt(index);
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
    }

    public void DeleteCarFromList(List<Car> cars, string model)
    {
        try
        {
            SupplementData.Validator.CheckNullEmpty(model);
            SupplementData.NullValidator.CheckNull(cars);

            cars.RemoveAt(cars.IndexOf(ChooseCarFromList(cars, model)));
        }
        catch (KeyNotFoundException exception)
        {
            throw exception;
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
    }

    public void DeleteCarFromList(List<Car> cars, Guid guid)
    {
        try
        {
            SupplementData.NullValidator.CheckNull(cars);

            cars.RemoveAt(cars.IndexOf(ChooseCarFromList(cars, guid)));
        }
        catch (KeyNotFoundException exception)
        {
            throw exception;
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public void DeleteCarFromCurrentCars(int index)
    {
        DeleteCarFromList(this.CurrentCars, index);
    }

    public void DeleteCarFromCurrentCars(string model)
    {
        DeleteCarFromList(this.CurrentCars, model);
    }

    public void DeleteCarFromCurrentCars(Guid guid)
    {
        DeleteCarFromList(this.CurrentCars, guid);
    }

    public void DeleteAllCarsFromList(List<Car> cars)
    {
        SupplementData.NullValidator.CheckNull(cars);

        cars.Clear();
    }

    public void DeleteAllCarsFromCurrentCars()
    {
        DeleteAllCarsFromList(this.CurrentCars);
    }

    //public void RefillCar(Car car)
    //{
    //    SupplementData.NullValidator.CheckNull(car);

    //    SupplementData.Mechanic.Refill(car);
    //}

    //public void RefillSelectedCar()
    //{
    //    SupplementData.NullValidator.CheckNull(this.SelectedCar);

    //    SupplementData.Mechanic.Refill(SelectedCar);
    //}

    // METHODS
    // // INITIALIZATION

    public void InitializeManagment()
    {
        try
        {
            // TO CREATE TEMPORARY INSTANCE WHICH HELP TO INITIALIZE DATA.
            SupplementDataInitializator dataInit = new SupplementDataInitializator();

            this.SupplementData = new ServiceManagerSupplements
            {
                Validator = dataInit.InitializeValidator(),
                IndexValidator = dataInit.InitializeIndexValidator(),
                CharMaps = dataInit.InitializeCharacterMaps(),
                RandomCarGenerator = dataInit.InitializeRandomCarGenerator(),
                MechanicalManager = dataInit.InitializeMechanization(),
                JunkRepairManager = dataInit.InitializeRepair(),
                NullValidator = dataInit.InitializeNullValidator(),
                DataContext = dataInit.InitializeDataContext(),
                DapperConfigs = dataInit.InitializeDapperConfigs()
            };
        }
        catch (NullReferenceException exception)
        {
            throw exception;
        }
    }
}
