using System.Data;
using System.Drawing;
using System.Text;
using CarRental.BussinessLayer.DTOs;
using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Enums;
using CarRental.Data.Models;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.Data.Models.Checkup;
using CarRental.Data.Models.RecordTypes;
using Dapper;
using Microsoft.Data.SqlClient;
using Z.Dapper.Plus;

namespace CarRental.BussinessLayer.Managers;

public class ServiceManager : ICarManager
{
    // THE PURPOSE OF THE CLAS:
    //      TO HOLD A LIST OF CARS AND TO OPERATE WITH IT.

    // FIELDS

    private const string _noInfo = "NO INFORMATION";
    private StringBuilder _carsInfo;
    private Random _random;
    private DatabaseContextDapper _dapperContext;


    // PROPERTTES

    internal List<Car>? CurrentCars { get; private set; }

    public ServiceManagerSupplements SupplementData { get; private set; }

    public IRandomCarGeneration RandomCarGenerator { get; init; }
    public IVehicleValidation Validator { get; init; }
    public IIndexValidation IndexValidator { get; init; }
    public ICharMaps CharMaps { get; init; }
    public IMechanicManager MechanicalManager { get; init; }
    public IRepairManager JunkRepairManager { get; init; }
    public INullValidation NullValidator { get; init; }
    public IDataContext DataContext { get; init; }
    public IDapperConfiguration DapperConfigs { get; init; }
    public IFileContext FileContext { get; init; }
    public ITextProcessing TextProcessor { get; init; }

    // CONSTRUCTORS

    public ServiceManager()
    {
        this._random = new Random();
        this._carsInfo = new StringBuilder();
        this.CurrentCars = new List<Car>();

        _dapperContext = new DatabaseContextDapper();
    }

    public ServiceManager
    (
        IRandomCarGeneration randomCarGenerator,
        IVehicleValidation validator,
        IIndexValidation indexValidator,
        ICharMaps charMaps,
        IMechanicManager mechanicalManager,
        IRepairManager junkRepairManager,
        INullValidation nullValidator,
        IDataContext dataContext,
        IDapperConfiguration dapperConfigs,
        IFileContext fileContext,
        ITextProcessing textProcessor 
    )
    {
        RandomCarGenerator = randomCarGenerator;
        Validator = validator;
        IndexValidator = indexValidator;
        CharMaps = charMaps;
        MechanicalManager = mechanicalManager;
        JunkRepairManager = junkRepairManager;
        NullValidator = nullValidator;
        DataContext = dataContext;
        DapperConfigs = dapperConfigs;
        FileContext = fileContext;
        TextProcessor = textProcessor;

        _random = new Random();
        _carsInfo = new StringBuilder();
        CurrentCars = new List<Car>();
    }

    // METHODS

    // CREATE

    public async Task<SimpleCarDto> CreateSimpleCar
    (
        string connectionString,
        string vinCode,
        string numberPlate,
        string brand,
        string model,
        int price
    )
    {
        try
        {
            SqlConnection connection = DataContext.OpenConnection(connectionString);

            string sqlProcedureInsert = "CreateSimpleCar";
            string sqlProcedureSelect = "GetSimpleCar";

            string carId = Guid.NewGuid().ToString().ToUpper();

            var argumentsInsert = new
            {
                carId,
                vinCode,
                numberPlate,
                brand,
                model,
                price
            };

            var argumentsSelect = new
            {
                carId
            };

            await connection.ExecuteAsync(sqlProcedureInsert, argumentsInsert);

            IEnumerable<Car> cars = await connection.QueryAsync<Car>(sqlProcedureSelect, argumentsSelect);

            Car car = cars.SingleOrDefault();

            var simpleCar = new SimpleCarDto
            {
                CarId = car.CarId.ToString().ToUpper(),
                VinCode = car.VinCode,
                NumberPlate = car.NumberPlate,
                Brand = car.Brand,
                Model = car.Model,
                Price = car.Price
            };

            DataContext.CloseConnection(connection);

            return simpleCar;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
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

    public void GetNewRandomCurrentCars(int count)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        this.CurrentCars.Clear();

        for (int index = 0; index < count; index = index + 1)
        {
            this.CurrentCars.Add(GetNewRandomCar());
        }
    }

    public async ValueTask<bool> AddCarsIntoDatabaseAsync(List<Car> cars, string connectionString)
    {
        try
        {
            bool isAddCars = false;

            SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

            foreach (Car car in cars)
            {
                string sqlProcedureName = "CreateCar";

                int? status = (int?)car.Status;

                var objectArguments = new
                {
                    carId = car.CarId,
                    vinCode = car.VinCode,
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
                    statusId = status
                };

                await connection.ExecuteScalarAsync(sqlProcedureName, objectArguments);
            }

            SupplementData.DataContext.CloseConnection(connection);

            int indexToCheck = _random.Next(0, cars.Count);

            Guid guidToCheck = cars[indexToCheck].CarId;

            isAddCars = await IsCarInDatabaseAsync(guidToCheck, connectionString);

            return isAddCars;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async ValueTask<bool> AddCarIntoDatabaseAsync(Car car, string connectionString)
    {
        try
        {
            bool isAddCar = false;

            SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

            string query = "CreateCar";

            int? status = (int?)car.Status;

            var objectArguments = new
            {
                carId = car.CarId,
                vinCode = car.VinCode,
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
                statusId = status
            };

            await connection.ExecuteScalarAsync(query, objectArguments);

            SupplementData.DataContext.CloseConnection(connection);

            isAddCar = await IsCarInDatabaseAsync(car.CarId, connectionString);

            return isAddCar;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async ValueTask<bool> AddCurrentCarsIntoDatabaseAsync(string connectionString)
    {
        SupplementData.NullValidator.CheckNull(this.CurrentCars);

        return await AddCarsIntoDatabaseAsync(CurrentCars, connectionString);
    }

    public async ValueTask<bool> BulkAddCurrentCarsIntoDatabaseAsync(string connectionString)
    {
        return await BulkAddCarsIntoDatabaseAsync(CurrentCars, connectionString);
    }

    public async ValueTask<bool> BulkAddCarsIntoDatabaseAsync(List<Car> cars, string connectionString)
    {
        try
        {
            bool isAddBulk = false;

            SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

            DapperPlusManager
                .Entity<Car>()
                .Table("Cars")
                .Map(car => car.CarId.ToString().ToUpper(), "CarId")
                .Map(car => null, "CustomerId")
                .Map(car => null, "DealId")
                .Map(car => (int?)car.Status, "StatusId")
                .AutoMap();

            await connection.BulkInsertAsync(cars);

            SupplementData.DataContext.CloseConnection(connection);

            isAddBulk = true;

            return isAddBulk;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    // RETRIVE

    public async Task<CustomerDto> GetCustomerByIdAsync(string connectionString, string id, string category = "Customer")
    {
        try
        {
            id = id.ToUpper();

            string procedureName = "GetCustomer";

            var arguments = new
            {
                customerId = id.ToUpper(),
                customerCategory = category
            };

            SqlConnection connection = DataContext.OpenConnection(connectionString);

            IEnumerable<CustomerTemp> customers = await connection.QueryAsync<CustomerTemp, Car?, Deal?, Inspection?, Repair?, CustomerTemp>
            (
                procedureName,
                (customer, car, deal, inspection, repair) =>
                {
                    //car.Owner = customer;
                    car.Engagement = deal;
                    car.Inspections.Add(inspection);
                    car.Repairs.Add(repair);

                    customer.Cars.Add(car);
                    customer.Deals.Add(deal);

                    return customer;
                },
                arguments,
                splitOn: "carCarId, dealId, inspectionInspectionId, repairId"
            );

            CustomerTemp customer = customers.FirstOrDefault();

            var customerTemp = new CustomerTemp
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Password = customer.Password,
                UserName = customer.UserName,
                IdNumber = customer.IdNumber,
                PassportNumber = customer.PassportNumber,
                DrivingLicenseNumber = customer.DrivingLicenseNumber
            };

            customerTemp.Deals = customers.Select(c => c.Deals.FirstOrDefault()).DistinctBy(d => d.Id).ToList();
            //customerTemp.Cars = customers.Select(c => c.Cars.FirstOrDefault()).DistinctBy(car => car.CarId).ToList();

            IEnumerable<IGrouping<Guid, Car>> groupedCars = customers.Select(c => c.Cars.FirstOrDefault()).GroupBy(c => c.CarId);

            foreach (IGrouping<Guid, Car> group in groupedCars)
            {
                Car? car = group.FirstOrDefault();

                car.Inspections = group.Select(c => c.Inspections.SingleOrDefault()).DistinctBy(i => i?.InspectionId).ToList();

                car.Repairs = group.Select(c => c.Repairs.SingleOrDefault()).DistinctBy(r => r?.Id).ToList();

                customerTemp.Cars.Add(car);
            }

            DataContext.CloseConnection(connection);

            //CustomerTemp customer = customers.SingleOrDefault();

            var customerDto = new CustomerDto
            {
                FirstName = customerTemp.FirstName,
                LastName = customerTemp.LastName,
                DateOfBirth = customerTemp.DateOfBirth,
                Password = customerTemp.Password,
                UserName = customerTemp.UserName,
                IdNumber = customerTemp.IdNumber,
                PassportNumber = customerTemp.PassportNumber,
                DrivingLicenseNumber = customerTemp.DrivingLicenseNumber,

                Deals = customerTemp.Deals,
                Cars = customerTemp.Cars
            };

            return customerDto;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async Task<SimpleCarDto> GetSimpleCarByIdAsync(/*DatabaseContextDapper dapperContext,*/ string carId, string connectionString)
    {
        try
        {
            var dapperContext = SupplementData.DataContext;

            SqlConnection connection = dapperContext.OpenConnection(connectionString);

            string sqlProcedureSelect = "GetSimpleCar";

            var argumentsSelect = new
            {
                carId
            };

            IEnumerable<Car> cars = await connection.QueryAsync<Car>(sqlProcedureSelect, argumentsSelect);

            Car car = cars.SingleOrDefault();

            var simpleCar = new SimpleCarDto
            {
                CarId = car.CarId.ToString().ToUpper(),
                VinCode = car.VinCode,
                NumberPlate = car.NumberPlate,
                Brand = car.Brand,
                Model = car.Model,
                Price = car.Price
            };

            dapperContext.CloseConnection(connection);

            return simpleCar;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async ValueTask<bool> IsCarInDatabaseAsync(Guid guid, string connectionString)
    {
        try
        {
            SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

            string sqlStoredProcedureName = "CheckIfCarEntryExist";

            string id = guid.ToString().ToUpper();

            var parameter = new
            {
                Id = id
            };

            int sqlOutput = await connection.ExecuteScalarAsync<int>(sqlStoredProcedureName, parameter);

            SupplementData.DataContext.CloseConnection(connection);

            bool result = (sqlOutput == 1) ? true : false;

            return result;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async Task<List<Car>> GetAllCarsOfCustomerFromDatabaseAsync(string customerId, string connectionString)
    {
        try
        {
            SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

            string sqlStoredProcedureName = "GetAllCarsOfCustomer";
            string id = customerId.ToUpper();

            object parameter = new
            {
                CustomerId = id
            };

            List<Car> cars = new List<Car>
            (
                await connection.QueryAsync<Car, CustomerTemp?, Deal?, Inspection?, Repair?, Car>
                (
                   sqlStoredProcedureName,
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

            List<IGrouping<Guid, Car>> groupedCars = new List<IGrouping<Guid, Car>>(cars.GroupBy(c => c.CarId));

            List<Car> resultCars = new List<Car>();

            foreach (IGrouping<Guid, Car> group in groupedCars)
            {
                Car? car = group.FirstOrDefault();

                car.Inspections = group.Select(c => c.Inspections.SingleOrDefault()).DistinctBy(i => i?.InspectionId).ToList();

                car.Repairs = group.Select(c => c.Repairs.SingleOrDefault()).DistinctBy(r => r?.Id).ToList();

                resultCars.Add(car);
            }

            SupplementData.DataContext.CloseConnection(connection);

            return resultCars;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async Task<Car?> GetCarFromDatabaseAsync(Guid id, string connectionString)
    {
        try
        {
            SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

            string SqlStoredProcedureName = "GetCar";
            string carId = id.ToString().ToUpper();

            var parameter = new
            {
                Id = carId
            };

            List<Car> cars = new List<Car>
            (
                await connection.QueryAsync<Car, CustomerTemp?, Deal?, Inspection?, Repair?, Car>
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

            Car car = cars.FirstOrDefault();

            car.Inspections = cars.Select(c => c.Inspections.SingleOrDefault()).DistinctBy(i => i?.InspectionId).ToList();

            car.Repairs = cars.Select(c => c.Repairs.SingleOrDefault()).DistinctBy(r => r?.Id).ToList();

            SupplementData.DataContext.CloseConnection(connection);

            return car;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
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

    public Car GetCarFromCurrentCars(int index)
    {
        return ChooseCarFromList(CurrentCars, index);
    }

    public string DisplayCar(Car car)
    {
        SupplementData.NullValidator.CheckNull(car);

        return $"{nameof(car)} | {car.ToString()}";
    }

    // O KARMANSKYI
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

    // UPDATE

    public async Task<SimpleCarDto> UpdateNumberPlatePriceSimpleCar(string connectionString, string carId, string numberPlate, int price)
    {
        SqlConnection connection = DataContext.OpenConnection(connectionString);

        var sqlProcedureUpdate = "UpdateNumberPlatePriceCar";

        var argumentsUpdate = new
        {
            carId,
            numberPlate,
            price
        };

        await connection.ExecuteAsync(sqlProcedureUpdate, argumentsUpdate);

        var sqlProcedureSelect = "GetSimpleCar";

        var argumentsSelect = new
        {
            carId
        };

        IEnumerable<Car> cars = await connection.QueryAsync<Car>(sqlProcedureSelect, argumentsSelect);

        Car car = cars.SingleOrDefault();

        var simpleCarDto = new SimpleCarDto
        {
            CarId = car.CarId.ToString().ToUpper(),
            VinCode = car.VinCode,
            NumberPlate = car.NumberPlate,
            Brand = car.Brand,
            Model = car.Model,
            Price = car.Price
        };

        DataContext.CloseConnection(connection);

        return simpleCarDto;
    }

    public async ValueTask<bool> ChangeCarIsFitForUseAsync(Guid carGuid, bool isFitForUse, string connectionString)
    {
        try
        {
            bool resultIsFit = false;

            SqlConnection connection = SupplementData.DataContext.OpenConnection(connectionString);

            string carId = carGuid.ToString().ToUpper();

            var arguments = new
            {
                isFitForUse = isFitForUse,
                carId = carId
            };

            string sqlStatement = @"UpdateCarIsFitForUse";

            await connection.ExecuteAsync(sqlStatement, arguments);

            SupplementData.DataContext.CloseConnection(connection);

            resultIsFit = true;

            return resultIsFit;
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async Task RepairAsync(Car car, Mechanic mechanic, string connectionString)
    {
        try
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

                    await InscribeRepairAsync(car, mechanic, isSuccessfull, connectionString);
                }
                else if (chance < 2)
                {
                    isSuccessfull = false;

                    await InscribeRepairAsync(car, mechanic, isSuccessfull, connectionString);
                }
            }
            else if (!isFitForUse)
            {
                chance = _random.Next(0, 11);

                if (chance > 1)
                {
                    isSuccessfull = true;

                    car.IsFitForUse = isSuccessfull;

                    await InscribeRepairAsync(car, mechanic, isSuccessfull, connectionString);
                }
                else
                {
                    isSuccessfull = false;

                    await InscribeRepairAsync(car, mechanic, isSuccessfull, connectionString);
                }
            }
        }
        catch (SqlException)
        {
            throw;
        }
        catch (InvalidOperationException)
        {
            throw;
        }
        catch (AggregateException)
        {
            throw;
        }
        catch (Exception)
        {
            // SOME LOGGING LOGIC

            throw;
        }
    }

    public async Task InscribeRepairAsync(Car car, Mechanic mechanic, bool isSuccessfull, string connectionString)
    {
        Repair repair = await SupplementData.JunkRepairManager.GetNewRepairAsync(car, mechanic, isSuccessfull, connectionString);

        AddRepairInToCar(car, repair);

        SupplementData.JunkRepairManager.AddRepairInToList(SupplementData.JunkRepairManager.Repairs, repair);

        SupplementData.MechanicalManager.AddRepairInToMechanicList(mechanic, repair);
    }

    public void AddRepairInToCar(Car car, Repair repair)
    {
        SupplementData.NullValidator.CheckNull(car);

        SupplementData.JunkRepairManager.AddRepairInToList(car.Repairs, repair);
    }

    public void AddDealToCar(Car car, Deal deal)
    {
        SupplementData.NullValidator.CheckNull(car);

        car.Engagement = deal;
    }

    // DELETE

    public async ValueTask<bool> DeleteSimpleCar(string connectionString, string carId)
    {
        var sqlProcedureDelete = "DeleteSimpleCar";

        var arguments = new
        {
            carId
        };

        var sqlProcedureCheck = "CheckIfCarExist";

        SqlConnection connection = DataContext.OpenConnection(connectionString);

        await connection.ExecuteAsync(sqlProcedureDelete, arguments);

        IEnumerable<bool> bits = await connection.QueryAsync<bool>(sqlProcedureCheck, arguments);

        DataContext.CloseConnection(connection);

        bool isExist = bits.SingleOrDefault();

        bool isSuccessful = !isExist;

        return isSuccessful;
    }

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

    public void DeleteCarFromCurrentCars(int index)
    {
        DeleteCarFromList(this.CurrentCars, index);
    }

    // METHODS
    // // INITIALIZATION

    public void InitializeManagment()
    {
        try
        {
            var dataInit = new SupplementDataInitializator();

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
                DapperConfigs = dataInit.InitializeDapperConfigs(),
                FileContext = dataInit.InitializeFileManagement(),
                TextProcessor = dataInit.InitializeTextProcessing()
            };
        }
        catch (NullReferenceException exception)
        {
            throw exception;
        }
    }

    public void ConfigureOrm()
    {
        DapperConfigs.ConfigureGuidToStringMapping();
        DapperConfigs.SetCustomMappingForEntities();
    }
}
