using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Interfaces;
using CarRental.Data.Models.Car;
using CarRental.Data.Models.Car.RecordTypes;


// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

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

    internal List<Car>? CurrentCars { get; private set; }    // O. KARMANSKYI
    internal Car? SelectedCar { get; private set; }

    // CONSTRUCTORS

    public ServiceManager()
    {
        this._random = new Random();
        this._carsInfo = new StringBuilder();
        this.CurrentCars = new List<Car>();
    }

    // METHODS

    #region METHODS

    // TO GET RANDOM CAR

    internal Car GetNewCar()
    {
        // KEYS OF THE DICTIONARY INTO ARRAY.
        string[] models = _supplementData.ModelsPatterns.Keys.ToArray();

        // TO SELECT A RANDOM PATTERN FROM THE DICTIONARY.
        return _supplementData.DepotService.ObtainNewCar(_supplementData.ModelsPatterns[models[_random.Next(0, models.Length)]]);
    }

    // TO GET SPECIFIC CAR BY A MODEL.

    internal Car GetNewCar(string model)
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

    public void MakeNewListOf15Cars()
    {
        // NULL-CHECK-UP
        if (CurrentCars == null)
        {
            throw new ArgumentNullException(nameof(this.CurrentCars));
        }

        // TO ERASE ALL ELEMENTS.
        CurrentCars.Clear();

        try
        {
            for (int index = 0; index < 15; index = index + 1)
            {
                CurrentCars.Add(GetNewCar());
            }
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
    }

    // TO CHANGE Car.Status OF A Car-INSTANCE

    internal bool TryChangeCarStatus(Car car, TransportStatus status)
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

    internal bool TryChangeCarStatus(int index, TransportStatus status)
    {
        if (CurrentCars == null)
        {
            throw new ArgumentNullException(nameof(index));
        }

        if (index < 0 )
        {
            throw new IndexOutOfRangeException();
        }

        if (this.CurrentCars[index] == null)
        {
            throw new ArgumentNullException(nameof(index));
        }

        if (Enum.IsDefined(typeof(TransportStatus), status))
        {
            CurrentCars[index].Status = status;

            return true;
        }
        else
        {
            return false;
        }
    }

    internal bool TryChangeCarStatus(List<Car> cars, TransportStatus status)
    {
        if (cars == null)
        {
            throw new ArgumentNullException(nameof(cars));
        }

        if (Enum.IsDefined(typeof(TransportStatus), status))
        {
            foreach(Car car in cars)
            {
                car.Status = status;
            }

            return true;
        }
        else
        {
            return false;
        }
    }

    internal bool TryChangeCarStatus(TransportStatus status)
    {
        if (this.SelectedCar == null)
        {
            throw new ArgumentNullException(nameof(status));
        }

        if (Enum.IsDefined(typeof(TransportStatus), status))
        {
            this.SelectedCar.Status = status;

            return true;
        }
        else
        {
            return false;
        }
    }

    // TO SELECT A SPECIFIC CAR FROM THE LIST

    internal bool TrySelectCar(int index)
    {
        try
        {
            if (CurrentCars == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            // VALIDATION TO TRY AVOID ARGUMENT OUT OF RANGE EXCEPTION.
            if ((index < 0) || (index > CurrentCars.Count))
            {
                return false;
            }
            else if(CurrentCars[index] == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            
            SelectedCar = CurrentCars[index];

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
        catch
        {
            throw new Exception();
        }
    }

    // TRY TO FIND CAR BY ITS MODEL /*ЯКЩО ЧЕСНО, ПОГАНО У МЕНЕ ІЗ ПРЕДИКАТАМИ, НЕ ДУЖЕ ЇХ РОЗУМІЮ :/*/

    internal bool TrySelectCar(string model)
    {
        Car car;

        try
        {
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

            return true;
        }
        catch (FormatException exception)
        {
            throw exception;
        }
    }

    // TO DELETE THE CAR FROM A LIST

    public void DeleteCarFromList(int index)
    {
        try
        {
            if (CurrentCars == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            CurrentCars.RemoveAt(index);
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
    }

    public void DeleteCarFromList(string model)
    {
        try
        {
            if (CurrentCars == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            CurrentCars.RemoveAt(CurrentCars.IndexOf(CurrentCars.Find(x => x.Model.Contains(model))));
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

    // TO DELETE ALL CARS FROM THE LIST

    public void DeleteAllCarsFromList()
    {
        if (CurrentCars == null)
        {
            throw new ArgumentNullException(nameof(this.CurrentCars));
        }

        CurrentCars.Clear();
    }

    // GET CAR BY INDEX
    internal Car? GetCar(int index)
    {
        try
        {
            if (CurrentCars == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            if ((index < 0) || (index > CurrentCars.Count))
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
            else
            {
                if (CurrentCars == null)
                {
                    throw new ArgumentNullException(nameof(index));
                }

                return CurrentCars[index];
            }
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

    // TO TAKE OFF A CAR FROM THE LIST

    internal bool TryTakeCar(int index)
    {
        try
        {
            if (CurrentCars == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            if ((index <= 0) || (index > CurrentCars.Count))
            {
                return false;
            }
            else
            {
                SelectedCar = CurrentCars[index];
                CurrentCars.RemoveAt(index);
                return true;
            }
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

    internal bool TryTakeCar(string model)
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

    public string DisplayCar(int index)
    {
        try
        {
            return CurrentCars[index].ToString();
        }
        catch (IndexOutOfRangeException exception)
        {
            throw exception;
        }
        catch(ArgumentNullException exception)
        {
            throw exception;
        }
        catch (FormatException exception)
        {
            throw exception;
        }
    }

    // TO DISPLAY INFO OF A SPECIFIC BY ITS MODEL CAR FROM THE LIST 

    public string DisplayCar(string model)
    {
        try
        {
            if (CurrentCars == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            // THE EMPTY LINE CAN APPEAR.
            return CurrentCars.Find(x => x.Model.Contains(model)).ToString();
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

    //internal string DisplayCar(Car car)
    //{
    //    return car.ToString();
    //}

    // TO DISPLAY AVAILABLE CAR MODELS.

    public string DisplayAllModels()
    {
        _carsInfo.Clear();

        foreach (KeyValuePair<string, SelectPattern> pair in _supplementData.ModelsPatterns)
        {
            _carsInfo.Append(pair.Key + " | ");
        }

        return _carsInfo.ToString();
    }

    // TO DISPLAY LIST OF CARS IN TABLE
    // //
    // // ~EDITED NOT BY YPARKHOMENKO~
    // //
    // // ADVICE BY YPARKHOMENKO: DO NOT USE STRING CONCATINATION IN LOOPS, USE StringBuilder-CLASS FUNCTIONALITY INSTEAD.
    // // BETTER TO USE STRING OUTPUT RATHER THAN THE CONSOLE OUTPUT.
    // //

    public void DisplayCarsInTable()
    {
        // ADD NULL CHECK-UP

        if (CurrentCars == null)
        {
            throw new ArgumentNullException(nameof(this.CurrentCars));
        }

        string line = new string('-', 110); // adjust the number to fit your table
        string format = "{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} | {7,-10} | {8,-20}";

        Console.WriteLine(format, "Index", "Brand", "Model", "Year", "Price", "Status", "FitForUse", "PlateNumber", "VinCode");
        Console.WriteLine(line);

        for (int i = 0; i < CurrentCars.Count; i++)
        {
            var car = CurrentCars[i];
            Console.WriteLine(format, i + 1, car.Brand, car.Model, car.Year, car.Price, car.Status, car.IsFitForUse, car.Dossier.NumberPlate, car.VinCode);
        }
    }

    // TO DISPLAY LIST OF CARS WITH HELP OF StringBuilder CLASS.

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        if (CurrentCars == null)
        {
            throw new ArgumentNullException(nameof(this.CurrentCars));
        }

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"({CurrentCars.IndexOf(car)})~~| {car.Brand} -- {car.Model} -- YEAR: {car.year}\n-- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.Dossier.NumberPlate} -- VINCODE: {car.VinCode} |~~\n");
        }

        return _carsInfo.ToString();
    }

    // TO CHECK THE FUEL OF SELECTED CAR

    public string CheckFuelSelectedCar()
    {
        if (SelectedCar == null)
        {
            throw new ArgumentNullException(nameof(this.SelectedCar));
        }

        _carsInfo.Clear();

        float division = (float)_supplementData.Mechanic.CheckFuel(SelectedCar) / SelectedCar.MaxFuelCapacity;

        division = (float)division * 100;

        _carsInfo.Append($"{(int)division}%");

        return _carsInfo.ToString();
    }

    // TO CHECK THE MILEAGE

    public string ShowMileageSelected()
    {
        if (SelectedCar == null)
        {
            throw new ArgumentNullException(nameof(this.SelectedCar));
        }

        return SelectedCar.Mileage.ToString();
    }

    // TO REFILL THE SELECTED CAR

    public void RefillSelectedCar()
    {
        if (SelectedCar == null)
        {
            throw new ArgumentNullException(nameof(this.SelectedCar));
        }

        _supplementData.Mechanic.Refill(SelectedCar);
    }

    // CHECK SIGNAL

    public string CheckSignal()
    {
        if (SelectedCar == null)
        {
            throw new ArgumentNullException(nameof(this.SelectedCar));
        }

        if (SelectedCar.Signal == null)
        {
            throw new ArgumentNullException(nameof(this.SelectedCar.Signal));
        }

        return SelectedCar.Signal.ToString();
    }

    // CHECK LIGHT

    public string CheckLights()
    {
        if (SelectedCar == null)
        {
            throw new ArgumentNullException(nameof(this.SelectedCar));
        }

        if (SelectedCar.Lights == null)
        {
            throw new ArgumentNullException(nameof(this.SelectedCar.Lights));
        }

        return SelectedCar.Lights.ToString();
    }

    // METHODS
    // // INITIALIZATION

    internal void InitializeManagment()
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
                Mechanic = dataInit.InitializeMechanic()
            };
        }
        catch (NullReferenceException exception)
        {
            throw exception;
        }
        catch
        {
            // THORW SOME EXCEPTION UPWARD.
            throw new Exception();
        }
    }

    #endregion
}
