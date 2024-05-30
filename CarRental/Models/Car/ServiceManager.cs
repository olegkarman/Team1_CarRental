using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Car;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

public class ServiceManager
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

    internal List<Car> CurrentCars { get; private set; }    // O. KARMANSKYI
    internal Car SelectedCar { get; private set; }

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
        // TO ERASE ALL ELEMENTS.
        CurrentCars.Clear();
        try
        {
            for (int index = 0; index < 15; index = index + 1)
            {
                CurrentCars.Add(GetNewCar());
            }
        }
        catch(IndexOutOfRangeException exception)
        {
            throw exception;
        }
    }

    // TO SELECT A SPECIFIC CAR FROM THE LIST

    internal bool TrySelectCar(int index)
    {
        try
        {
            // VALIDATION TO TRY AVOID ARGUMENT OUT OF RANGE EXCEPTION.
            if ((index <= 0) || (index > CurrentCars.Count))
            {
                return false;
            }
            else
            {
                SelectedCar = CurrentCars[index];

                return true;
            }
        }
        catch(IndexOutOfRangeException exception)
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

            car = CurrentCars.Find(x => x.Model.Contains(model));

            if (car == null)
            {
                return false;
            }

            SelectedCar = car;

            return true;
        }
        catch(FormatException exception)
        {
            throw exception;
        }
    }

    // TO DELETE THE CAR FROM A LIST

    public void DeleteCarFromList(int index)
    {
        try
        {
            CurrentCars.RemoveAt(index);
        }
        catch(IndexOutOfRangeException exception)
        {
            throw exception;
        }
    }

    public void DeleteCarFromList(string model)
    {
        try
        {
            CurrentCars.RemoveAt(CurrentCars.IndexOf(CurrentCars.Find(x => x.Model.Contains(model))));
        }
        catch(KeyNotFoundException exception)
        {
            throw exception;
        }
        catch(IndexOutOfRangeException exception)
        {
            throw exception;
        }
        catch(FormatException exception)
        {
            throw exception;
        }
    }

    // TO DELETE ALL CARS FROM THE LIST

    public void DeleteAllCarsFromList()
    {
        CurrentCars.Clear();
    }

    // TO TAKE OFF A CAR FROM THE LIST

    internal bool TryTakeCar(int index)
    {
        try
        {
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
        catch(IndexOutOfRangeException exception)
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
            return this.SelectedCar.ToString();    // MAKE BETTER FORMATTING PLS.
        }
        catch(ArgumentNullException exception)
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

    // TO DISPLAY AVAILABLE CAR MODELS.

    public string DisplayAllModels()
    {
        _carsInfo.Clear();

        foreach(KeyValuePair<string, SelectPattern> pair in _supplementData.ModelsPatterns)
        {
            _carsInfo.Append(pair.Key + " | ");
        }

        return _carsInfo.ToString();
    }

    // TO DISPLAY LIST OF CARS WITH HELP OF StringBuilder CLASS.

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"({CurrentCars.IndexOf(car)})~~| {car.Brand} -- {car.Model} -- YEAR: {car.year}\n-- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.Record.NumberPlate} -- VINCODE: {car.VinCode} |~~\n");    
        }

        return _carsInfo.ToString();
    }

    // TO CHECK THE FUEL OF SELECTED CAR

    public string CheckFuelSelectedCar()
    {
        _carsInfo.Clear();

        float division = (float)_supplementData.Mechanic.CheckFuel(CarRental.Models.Car.SelectedCar) / SelectedCar.MaxFuelCapacity;

        division = (float)division * 100;
        
        _carsInfo.Append($"{(int)division}%");

        return _carsInfo.ToString();
    }

    // TO CHECK THE MILEAGE

    public string ShowMileageSelected()
    {
        return CarRental.Models.Car.SelectedCar.Mileage.ToString();
    }

    // TO REFILL THE SELECTED CAR

    public void RefillSelectedCar()
    {
        _supplementData.Mechanic.Refill(CarRental.Models.Car.SelectedCar);
    }

    // CHECK SIGNAL

    public string CheckSignal()
    {
        return SelectedCar.Signal.ToString();
    }

    // CHECK LIGHT

    //public string CheckLights()
    //{
    //    return SelectedCar.Light.ToString();
    //}

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
