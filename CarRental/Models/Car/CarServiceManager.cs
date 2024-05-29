using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public class CarServiceManager
{
    // THE PURPOSE OF THE CLAS:
    //      TO BE A CONNECTION LINK BETWEEN MENU AND HIDDEN MECHANISM OF CAR-INSTANCE GENERATION.
    //      TO HOLD A LIST OF CARS AND TO OPERATE WITH IT.

    // FIELDS

    private StringBuilder _carsInfo;
    private Random _random;
    
    // PROPERTTES

    internal List<Car> CurrentCars { get; private set; }    // O. KARMANSKYI
    internal Car SelectedCar { get; private set; }

    // CONSTRUCTORS

    public CarServiceManager()
    {
        this._random = new Random();
        this._carsInfo = new StringBuilder();
        this.CurrentCars = new List<Car>();
    }

    // METHODS

    public void InitializeManagment()
    {
        // INIT OF INSTANCE OF BASIC CAR COMPLECTATION DATA.
        BrandModelsNamesDataSheet _brandModelsDataSheet = InitializeData();

        // INIT OF SERVICE INSTANCE WHICH CREATES CAR INSTANCES.
        Depot depot = InitializeDepot();

        // INIT OF AN INSTANCE OF THE CLASS WHIC RESPONSIBLE FOR PATTERN INITIALIZATION
        PatternInitializator patternInitializator = InitializePatternInitializator();

        // A DICTIONARY OF MODEL-PATTERNS
        Dictionary<string, CarSelectPattern> InitializeDictionaryModelPattern(patternInitializator, brandRecords, data);

        // AN ARRAY OF BRAND - MODEL RECORS
        BrandRecord[] brandRecords = InitializeBrandRecords(patternInitializator, data);

    }

    // TO GET SPECIFIC CAR BY A PATTERN

    internal Car ObtainNewCar(Depot depot, CarSelectPattern pattern)
    {
        return depot.GetNewCar(pattern);
    }

    // TO GET RANDOM CAR

    internal Car ObtainNewCar(Depot depot, Dictionary<string, CarSelectPattern> patterns)
    {
        // KEYS OF THE DICTIONARY INTO ARRAY.
        string[] models = patterns.Keys.ToArray();

        // TO SELECT A RANDOM PATTERN FROM THE DICTIONARY.
        return depot.GetNewCar(patterns[models[_random.Next(0, models.Length)]]);
    }

    // TO GENERATE A LIST OF CARS

    public void MakeNewListOf15Cars(Depot depot, Dictionary<string, CarSelectPattern> patterns)
    {
        // TO ERASE ALL ELEMENTS.
        CurrentCars.Clear();

        for(int index = 0; index < 15; index = index + 1)
        {
            CurrentCars.Add(ObtainNewCar(depot, patterns));
        }
    }

    // TO SELECT A SPECIFIC CAR FROM THE LIST

    internal bool TrySelectCar(int index)
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

    // TRY TO FIND CAR BY ITS MODEL /*ЯКЩО ЧЕСНО, ПОГАНО У МЕНЕ ІЗ ПРЕДИКАТАМИ, НЕ ДУЖЕ ЇХ РОЗУМІЮ :/*/

    internal bool TrySelectCar(string model)
    {
        Car car;

        car = CurrentCars.Find(x => x.Model.Contains(model));

        if (car == null)
        {
            return false;
        }

        SelectedCar = car;

        return true;
    }

    // TO DELETE THE CAR FROM A LIST

    public void DeleteCarFromList(int index)
    {
        CurrentCars.RemoveAt(index);
    }

    public void DeleteCarFromList(string model)
    {
        CurrentCars.RemoveAt(CurrentCars.IndexOf(CurrentCars.Find(x => x.Model.Contains(model))));
    }

    // TO DELETE ALL CARS FROM THE LIST

    public void DeleteAllCarsFromList()
    {
        CurrentCars.Clear();
    }

    // TO TAKE OFF A CAR FROM THE LIST

    internal bool TryTakeCar(int index)
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

    internal bool TryTakeCar(string model)
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

    // TO DISPLAY INFO OF A SELECTED CAR

    public string DisplayCurrentCar()
    {
        return this.SelectedCar.ToString();    // MAKE BETTER FORMATTING PLS.
    }

    // TO DISPLAY INFO A SPECIFIC BY INDEX CAR FROM THE LIST

    public string DisplayCar(int index)
    {
        return CurrentCars[index].ToString();
    }

    // TO DISPLAY INFO OF A SPECIFIC BY ITS MODEL CAR FROM THE LIST 

    public string DisplayCar(string model)
    {
        // THE EMPTY LINE CAN APPEAR.
        return CurrentCars.Find(x => x.Model.Contains(model)).ToString();
    }

    // TO DISPLAY LIST OF CARS WITH HELP OF StringBuilder CLASS.

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"({CurrentCars.IndexOf(car)})~~|{car.Brand} -- {car.Model} -- YEAR: {car.year}\n-- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.Record.NumberPlate} -- VINCODE: {car.VinCode} |~~\n");    
        }

        return _carsInfo.ToString();
    }

    // METHODS
    // // INITIALIZERS

    public Dictionary<string, CarSelectPattern> InitializeDictionaryModelPattern(PatternInitializator patternInit, BrandRecord[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
    {
        return patternInit.ChoosePatternForModel(brandRecords, dataWarehouse);
    }

    public BrandRecord[] InitializeBrandRecords(PatternInitializator patternInitializator, BrandModelsNamesDataSheet data)
    {
        return patternInitializator.InitializeBrandRecords(data);
    }

    PatternInitializator InitializePatternInitializator()
    {
        return new PatternInitializator();
    }

    public BrandModelsNamesDataSheet InitializeData()
    {
        return new BrandModelsNamesDataSheet();
    }

    public Depot InitializeDepot()
    {
        return new CarRental.Models.Car.Depot();
    }



    // GET NEW CAR
    // GENERATE CAR LIST
    // DELETE CAR FROM LIST
    // GET CAR INFO
}
