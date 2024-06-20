using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.BussinessLayer.Interfaces;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;
using CarRental.Data.Models.Car;
using CarRental.Data.Models.Car.RecordTypes;

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

    // RANDOM CAR

    public Car GetNewCar()
    {

    }

    public Car GetNewCar(string model)
    {

    }

    public List<Car> MakeNewListOfCars()
    {
        return new List<Car>();
    }

    // RANDOM VEHICLES

    public List<Car> MakeNewListOfCars(int count)
    {
        List<Car> cars = new List<Car>();

        for (int index = 0; index < count; index = index + 1)
        {
            cars.Add(GetNewCar());
        }

        return cars;
    }

    public void MakeNewListOfCurrentCars(int count)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        CurrentCars.Clear();

        this.CurrentCars = MakeNewListOfCars(count);
    }

    public void ChangeCarStatus(Car car, TransportStatus status)
    {
        _supplementData.Validator.CheckNull(car);

        _supplementData.Validator.CheckType(status);

        car.Status = status;
       
    }

    public void ChangeCurrentCarStatus(int index, TransportStatus status)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        Car car = ChooseCarFromList(CurrentCars, index);

        _supplementData.Validator.CheckNull(car);

        _supplementData.Validator.CheckType(status);

        CurrentCars[index].Status = status;
    }

    public void ChangeCurrentCarStatus(Guid guid, TransportStatus status)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        Car car = ChooseCarFromList(CurrentCars, guid);

        _supplementData.Validator.CheckNull(car);

        _supplementData.Validator.CheckType(status);

        // THIS IS A REFEREBCE TYPE, THE CHANGE WILL AFFECT CAR INSTANCE IN THE LIST.
        car.Status = status;
    }

    public void ChangeCarsStatus(List<Car> cars, TransportStatus status)
    {
        _supplementData.Validator.CheckNull(cars);
        _supplementData.Validator.CheckType(status);
        
        foreach(Car car in cars)
        {
            car.Status = status;
        }
    }

    public void ChangeCurrentCarsStatus(TransportStatus status)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        _supplementData.Validator.CheckType(status);

        foreach (Car car in CurrentCars)
        {
            car.Status = status;
        }
    }

    public void ChangeSelectedCarStatus(TransportStatus status)
    {
        _supplementData.Validator.CheckNull(this.SelectedCar);
        _supplementData.Validator.CheckType(status);

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

    public void SelectCarFromCurrentCars(int index)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, index);
    }

    public void SelectCarFromCurrentCars(string model)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, model);
    }

    public void SelectCarFromCurrentCars(Guid guid)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        this.SelectedCar = ChooseCarFromList(CurrentCars, guid);
    }

    public void DeleteCarFromList(List<Car> list, int index)
    {
        try
        {
            _supplementData.Validator.CheckNull(list);

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
            _supplementData.Validator.CheckNull(list);

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

    public void DeleteCarFromList(List<Car> list, Guid guid)
    {
        try
        {
            _supplementData.Validator.CheckNull(list);

            list.RemoveAt(list.IndexOf(ChooseCarFromList(list, guid)));
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

    public void DeleteAllCarsFromList(List<Car> list)
    {
        _supplementData.Validator.CheckNull(list);

        list.Clear();
    }

    public void DeleteAllCarsFromCurrentCars()
    {
        DeleteAllCarsFromList(this.CurrentCars);
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
          Car car;

        _supplementData.Validator.CheckNull(CurrentCars);

        car = ChooseCarFromList(CurrentCars, model);

        _supplementData.Validator.CheckNull(car);

        this.SelectedCar = car;

          CurrentCars.RemoveAt(CurrentCars.IndexOf(ChooseCarFromList(CurrentCars, model)));
    }

    public void MoveCarFromCurrentCarsToSelected(Guid guid)
    {
        Car car;

        _supplementData.Validator.CheckNull(CurrentCars);

        car = ChooseCarFromList(CurrentCars, guid);

        _supplementData.Validator.CheckNull(car);

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
        _supplementData.Validator.CheckNull(cars);

        return ChooseCarFromList(cars, index).ToString();
    }

    public string DisplayCarFromList(List<Car> cars, string model)
    {
        _supplementData.Validator.CheckNull(cars);

        return ChooseCarFromList(cars, model).ToString();
    }

    public string DisplayCarFromList(List<Car> cars, Guid guid)
    {
        _supplementData.Validator.CheckNull(cars);

        return ChooseCarFromList(cars, guid).ToString();
    }

    public string DisplayCarFromCurrentCars(int index)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, index).ToString();
    }

    public string DisplayCarFromCurrentCars(string model)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, model).ToString();
    }

    public string DisplayCarFromCurrentCars(Guid guid)
    {
        _supplementData.Validator.CheckNull(this.CurrentCars);

        return ChooseCarFromList(this.CurrentCars, guid).ToString();
    }

    public string DisplayCar(Car car)
    {
        _supplementData.Validator.CheckNull(car);

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
            outputManager.PrintMessage(format, i + 1, car.Brand, car.Model, car.year, car.Price, car.Status, car.IsFitForUse, car.NumberPlate, car.VinCode);
        }
    }

    // TO DISPLAY LIST OF CARS WITH HELP OF StringBuilder CLASS.

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        _supplementData.Validator.CheckNull(this.CurrentCars);

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"({CurrentCars.IndexOf(car)})~~| {car.Brand} -- {car.Model} -- YEAR: {car.year}\n-- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.NumberPlate} -- VINCODE: {car.VinCode} |~~\n");
        }

        return _carsInfo.ToString();
    }

    public string CheckFuelCar(Car car)
    {
        _supplementData.Validator.CheckNull(car);

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
        _supplementData.Validator.CheckNull(car);

        return car.Mileage.ToString();
    }

    public string ShowMileageSelectedCar()
    {
        return ShowMileage(this.SelectedCar);
    }

    public void RefillCar(Car car)
    {
        _supplementData.Validator.CheckNull(car);

        _supplementData.Mechanic.Refill(car);
    }

    public void RefillSelectedCar()
    {
        _supplementData.Validator.CheckNull(this.SelectedCar);

        _supplementData.Mechanic.Refill(SelectedCar);
    }

    // TO CHECK IF INDEX IN THE RANGE OF CURRENT CAR LIST

    public Car ChooseCarFromList(List<Car> list, int index)
    {

        _supplementData.Validator.CheckNull(list);
            
        if ((index < 0) || (index >= list.Count))
        {
            throw new IndexOutOfRangeException();
        }

        Car car = list[index];

        _supplementData.Validator.CheckNull(car);

        return car;
    }

    public Car ChooseCarFromList(List<Car> list, string model)
    {
        _supplementData.Validator.CheckNull(list);

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

    public Car ChooseCarFromList(List<Car> list, Guid guid)
    {
        _supplementData.Validator.CheckNull(list);

        try
        {
            return list.Find(x => x.CarId.CompareTo(guid) == 0);
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

    public string CheckSignal(Car car)
    {
        _supplementData.Validator.CheckNull(car);

        return car.Signal.ToString();
    }

    public string CheckLights(Car car)
    {
        _supplementData.Validator.CheckNull(car);

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

            this._supplementData = new ServiceManagerSupplements
            {
                Mechanic = dataInit.InitializeMechanic(),
                Validator = dataInit.InitializeValidator(),
                CharMaps = dataInit.InitializeCharacterMaps()
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
