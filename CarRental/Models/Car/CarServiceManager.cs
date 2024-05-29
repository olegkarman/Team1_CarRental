using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models.Car;

namespace CarRental.Models.Car;

public class CarServiceManager
{
    // THE PURPOSE OF THE CLAS:
    //      TO BE A CONNECTION LINK BETWEEN MENU AND HIDDEN MECHANISM OF CAR-INSTANCE GENERATION.
    //      TO HOLD A LIST OF CARS AND TO OPERATE WITH IT.

    // FIELDS

    private StringBuilder _carsInfo;
    private Random _random;
    private ServiceManagerSupplements _supplementData;
    
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

    // TO GET SPECIFIC CAR BY A MODEL.

    internal Car GetNewCar(string model)
    {
        return _supplementData.DepotService.ObtainNewCar(_supplementData.ModelsPatterns[model]);
    }

    // TO GET RANDOM CAR

    internal Car ObtainNewCar()
    {
        // KEYS OF THE DICTIONARY INTO ARRAY.
        string[] models = _supplementData.ModelsPatterns.Keys.ToArray();

        // TO SELECT A RANDOM PATTERN FROM THE DICTIONARY.
        return _supplementData.DepotService.ObtainNewCar(_supplementData.ModelsPatterns[models[_random.Next(0, models.Length)]]);
    }

    // TO GENERATE A LIST OF CARS

    public void MakeNewListOf15Cars(Depot depot, Dictionary<string, CarSelectPattern> patterns)
    {
        // TO ERASE ALL ELEMENTS.
        CurrentCars.Clear();

        for(int index = 0; index < 15; index = index + 1)
        {
            CurrentCars.Add(ObtainNewCar());
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
    // // INITIALIZATION

    internal void InitializeManagment()
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
            ModelsPatterns = dataInit.InitializeModelsPatternsDictionary(patternInit, brandRecords, brandModelsData)
        };  
    }
}
