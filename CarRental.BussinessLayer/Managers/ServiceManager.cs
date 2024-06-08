using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;
using CarRental.Data.Models.Car;
using CarRental.Data.Models.Car.RecordTypes;
using CarRental.Data.Models.Car.Seeds;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.BussinessLayer.Managers;

public class ServiceManager : ICarManager
{
    // THE PURPOSE OF THE CLAS:
    //      TO BE A CONNECTION LINK BETWEEN MENU AND HIDDEN MECHANISM OF CAR-INSTANCE GENERATION.
    //      TO HOLD A LIST OF CARS AND TO OPERATE WITH IT.

    // FIELDS

    private const string _noInfo = "NO INFO";
    private StringBuilder _carsInfo;
    private Random _random;
    private ServiceManagerSupplements _supplementData;

    // PROPERTTES

    internal List<Car>? CurrentCars { get; private set; }
    internal Car? SelectedCar { get; private set; }

    // CONSTRUCTORS

    public ServiceManager()
    {
        this._random = new Random();
        this._carsInfo = new StringBuilder();
        this.CurrentCars = new List<Car>();
    }

    // METHODS

    // TO GET RANDOM CAR

    public Car GetNewCar()
    {
        // KEYS OF THE DICTIONARY INTO ARRAY.
        string[] models = _supplementData.ModelsPatterns.Keys.ToArray();

        // TO SELECT A RANDOM PATTERN FROM THE DICTIONARY.
        return _supplementData.DepotService.ObtainNewCar(_supplementData.ModelsPatterns[models[_random.Next(0, models.Length)]]);
    }

    // TO GET SPECIFIC CAR BY A MODEL.

    public Car GetNewCar(string model)
    {
        try
        {
            return _supplementData.DepotService.ObtainNewCar(_supplementData.ModelsPatterns[model]);
        }
        catch (KeyNotFoundException exception)
        {
            // THROW AN EXCEPTION UPWARD.
            throw exception;
        }
    }

    // TO GENERATE A LIST OF CARS

    public List<Car> MakeNewListOfCars()
    {
        return new List<Car>();
    }

    // TO MAKE A LIST OF CARS WITH A SPECIFIC NUMBER OF RANDOM VEHICLES

    public List<Car> MakeNewListOfCars(int count)
    {
        List<Car> cars = new List<Car>();

        for (int index = 0; index < count; index = index + 1)
        {
            cars.Add(GetNewCar());
        }

        return cars;
    }

    // TO MAKE A LIST OF CURRENT CARS WITH SPECIFIC AMOUNT OF RANDOM VEHICLES INSIDE

    public void MakeNewListOfCurrentCars(int count)
    {
        CheckNull(this.CurrentCars);

        CurrentCars.Clear();

        this.CurrentCars = MakeNewListOfCars(count);
    }

    // TO CHANGE Car.Status OF A Car-INSTANCE

    public bool TryChangeCarStatus(Car car, TransportStatus status)
    {
        if (car == null)
        {
            throw new ArgumentNullException(nameof(car));
        }

        if (Enum.IsDefined(typeof(TransportStatus), status))
        {
            car.Status = status;

            return true;
        }
        else
        {
            return false;
        }
       
    }

    public void ChangeCurrentCarStatus(int index, TransportStatus status)
    {
        CheckNull(this.CurrentCars);

        Car car = ChooseCarFromList(CurrentCars, index);

        CheckNull(car);

        CheckType(status);

        CurrentCars[index].Status = status;
    }

    public void ChangeCarsStatus(List<Car> cars, TransportStatus status)
    {
        CheckNull(cars);
        CheckType(status);
        
        foreach(Car car in cars)
        {
            car.Status = status;
        }
    }

    public void ChangeCurrentCarsStatus(TransportStatus status)
    {
        CheckNull(this.CurrentCars);

        CheckType(status);

        foreach (Car car in CurrentCars)
        {
            car.Status = status;
        }
    }

    public void ChangeSelectedCarStatus(TransportStatus status)
    {
        CheckNull(this.SelectedCar);
        CheckType(status);

        this.SelectedCar.Status = status;
    }

    // TO CHECK TYPE

    public void CheckType(TransportStatus status)
    {
        if (!Enum.IsDefined(typeof(TransportStatus), status))
        {
            throw new InvalidCastException(nameof(status));
        }
    }

    // TO SELECT A SPECIFIC CAR FROM THE CURRENT CARS LIST

    public void SelectCarFromCurrentCars(int index)
    {
        CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, index);
    }

    // TRY TO FIND CAR BY ITS MODEL /*ЯКЩО ЧЕСНО, ПОГАНО У МЕНЕ ІЗ ПРЕДИКАТАМИ, НЕ ДУЖЕ ЇХ РОЗУМІЮ :/*/

    public void SelectCarFromCurrentCars(string model)
    {
        CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, model);
    }

    // TO DELETE THE CAR FROM A LIST

    public void DeleteCarFromList(List<Car> list, int index)
    {
        try
        {
            CheckNull(list);

            list.RemoveAt(index);
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
    }

    public void DeleteCarFromList(List<Car> list, string model)
    {
        try
        {
            CheckNull(list);

            list.RemoveAt(list.IndexOf(ChooseCarFromList(list, model)));
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

    // TO DELETE ALL CARS FROM THE LIST

    public void DeleteAllCarsFromList(List<Car> list)
    {
        CheckNull(list);

        list.Clear();
    }

    public void DeleteAllCarsFromCurrentCars()
    {
        DeleteAllCarsFromList(this.CurrentCars);
    }

    // GET CAR BY INDEX FROM CURRENT CARS LIST

    public Car GetCarFromCurrentCars(int index)
    {
        return ChooseCarFromList(CurrentCars, index);
    }

    // TO TAKE OFF A CAR FROM THE CURRENT CARS LIST

    public void TakeCarFromCurrentCars(int index)
    {        
        SelectedCar = ChooseCarFromList(CurrentCars, index);
        CurrentCars.RemoveAt(index);
    }

    public bool TryTakeCar(string model)
    {
        try
        {
            Car car;

            if (CurrentCars == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            car = CurrentCars.Find(x => x.Model.Contains(model));

            if (car == null)
            {
                return false;
            }

            SelectedCar = car;

            CurrentCars.RemoveAt(CurrentCars.IndexOf(CurrentCars.Find(x => x.Model.Contains(model))));

            return true;
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
        catch (FormatException exception)
        {
            throw exception;
        }
    }

    // TO DISPLAY INFO OF A SELECTED CAR

    public string DisplayCurrentCar()
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

    // TO DISPLAY INFO A SPECIFIC BY INDEX CAR FROM THE LIST

    public string DisplayCarFromList(List<Car> cars, int index)
    {
        CheckNull(cars);

        return ChooseCarFromList(cars, index).ToString();
    }

    // TO DISPLAY INFO OF A SPECIFIC BY ITS MODEL CAR FROM THE LIST 

    public string DisplayCarFromList(List<Car> cars, string model)
    {
        CheckNull(cars);

        return ChooseCarFromList(cars, model).ToString();
    }

    public string DisplayCarFromCurrentCars(int index)
    {
        CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, index).ToString();
    }

    public string DisplayCarFromCurrentCars(string model)
    {
        CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, model).ToString();
    }

    // TO DISPLAY INFO ABOUT A CAR

    public string DisplayCar(Car car)
    {
        CheckNull(car);

        return $"{nameof(car)} | {car.ToString()}";
    }

    // TO DISPLAY AVAILABLE CAR MODELS.

    public string DisplayAllModels()
    {
        try
        {
            _carsInfo.Clear();

            foreach (KeyValuePair<string, ModelComponentsPattern> pair in _supplementData.ModelsPatterns)
            {
                _carsInfo.Append(pair.Key + " | ");
            }

            return _carsInfo.ToString();
        }
        catch (NullReferenceException exception)
        {
            throw exception;
        }
    }

    // TO DISPLAY LIST OF CARS IN TABLE
    // //
    // // ~THIS METHOD ADDED AND EDITED NOT BY YPARKHOMENKO~
    // //
    // // ADVICE BY YPARKHOMENKO: DO NOT USE STRING CONCATINATION IN LOOPS, USE StringBuilder-CLASS FUNCTIONALITY INSTEAD.
    // // BETTER TO USE STRING OUTPUT RATHER THAN THE CONSOLE OUTPUT.
    // //

    //public void DisplayCarsInTable()
    //{
    //    // ADD NULL CHECK-UP

    //    if (CurrentCars == null)
    //    {
    //        throw new ArgumentNullException(nameof(this.CurrentCars));
    //    }

    //    string line = new string('-', 110); // adjust the number to fit your table
    //    string format = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-20}";

    //    Console.WriteLine(format, "Index", "Brand", "Model", "Year", "Price", "Status", "FitForUse", "PlateNumber", "VinCode");
    //    Console.WriteLine(line);

    //    for (int i = 0; i < CurrentCars.Count; i++)
    //    {
    //        var car = CurrentCars[i];
    //        Console.WriteLine(format, i + 1, car.Brand, car.Model, car.Year, car.Price, car.Status, car.IsFitForUse, car.Dossier.NumberPlate, car.VinCode);
    //    }
    //}

    // TO DISPLAY LIST OF CARS WITH HELP OF StringBuilder CLASS.

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        CheckNull(this.CurrentCars);

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"({CurrentCars.IndexOf(car)})~~| {car.Brand} -- {car.Model} -- YEAR: {car.year}\n-- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.Dossier.NumberPlate} -- VINCODE: {car.VinCode} |~~\n");
        }

        return _carsInfo.ToString();
    }

    public string CheckFuelCar(Car car)
    {
        CheckNull(car);

        _carsInfo.Clear();

        try
        {
            float division = (float)_supplementData.Mechanic.CheckFuel(car) / car.MaxFuelCapacity;

            division = (float)division * 100;

            _carsInfo.Append($"{(int)division}%");

            return _carsInfo.ToString();
        }
        catch(DivideByZeroException exception)
        {
            throw exception;
        }
    }

    public string CheckFuelSelectedCar()
    {
        return CheckFuelCar(SelectedCar);
    }

    public string ShowMileage(Car car)
    {
        CheckNull(car);

        return car.Mileage.ToString();
    }

    public string ShowMileageSelectedCar()
    {
        return ShowMileage(this.SelectedCar);
    }

    public void RefillCar(Car car)
    {
        CheckNull(car);

        _supplementData.Mechanic.Refill(car);
    }

    public void RefillSelectedCar()
    {
        CheckNull(this.SelectedCar);

        _supplementData.Mechanic.Refill(SelectedCar);
    }

    // TO CHECK IF INDEX IN THE RANGE OF CURRENT CAR LIST

    public Car ChooseCarFromList(List<Car> list, int index)
    {

        CheckNull(list);
            
        if ((index < 0) || (index > list.Count))
        {
            throw new IndexOutOfRangeException();
        }

        Car car = list[index];

        CheckNull(car);

        return car;
    }

    public Car ChooseCarFromList(List<Car> list, string model)
    {
        CheckNull(list);

        try
        {
            // THE EMPTY LINE CAN APPEAR.
            return list.Find(x => x.Model.Contains(model));
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

    // NULL CHECK

    public void CheckNull(Car car)
    {
        if (car == null)
        {
            throw new ArgumentNullException(nameof(car));
        }
    }

    public void CheckNull(List<Car> cars)
    {
        if (cars == null)
        {
            throw new ArgumentNullException(nameof(cars));
        }
    }

    public void CheckNull(IComponent component)
    {
        if (component == null)
        {
            throw new ArgumentNullException(nameof(component));
        }
    }

    public string CheckSignal(Car car)
    {
        CheckNull(car);
        CheckNull(car.Signal);

        return car.Signal.ToString();
    }

    public string CheckLights(Car car)
    {
        CheckNull(car);
        CheckNull(car.Signal);

        return car.Lights.ToString();
    }

    // METHODS
    // // INITIALIZATION

    public void InitializeManagment()
    {
        try
        {
            // TO CREATE TEMPORARY INSTANCE WHICH HELP TO INITIALIZE DATA.
            SupplementDataInitializator dataInit = new SupplementDataInitializator();

            PatternInitializator patternInit = new PatternInitializator();

            // TO ASSIG REFERENE BELOW IN THE OBJECT-INITILIZER.
            BrandModelsNamesDataSheet brandModelsData = dataInit.InitializeDataSheet();

            BrandRecord[] brandRecords = dataInit.InitializeBrandRecordsArray(patternInit, brandModelsData);

            this._supplementData = new ServiceManagerSupplements
            {
                BrandModelsDataSheet = brandModelsData,
                DepotService = dataInit.InitializeDepot(),
                BrandRecords = brandRecords,
                ModelsPatterns = dataInit.InitializeModelsPatternsDictionary(patternInit, brandRecords, brandModelsData),
                Mechanic = dataInit.InitializeMechanic(),
                Validator = dataInit.InitializeValidator()
            };
        }
        catch (NullReferenceException exception)
        {
            throw exception;
        }
        catch
        {
            throw new Exception();
        }
    }
}
