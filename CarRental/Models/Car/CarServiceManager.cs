using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public class CarServiceManager
{
    // FIELDS
    private StringBuilder _carsInfo;
    private Random _random;
    
    // PROPERTTES

    internal List<Car> CurrentCars { get; set; }
    internal Car SelectedCar { get; set; }

    // METHODS

    // TO GET SPECIFIC CAR
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

    // TO SELECT A SPECIFIC CAR FROM THE LIST

    internal bool TrySelectCar(int index)
    {
        // VALIDATION TO AVOID ARGUMENT OUT OF RANGE EXCEPTION.
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

    // TRY TO FIND CAR BY MODEL /*ЯКЩО ЧЕСНО, ПОГАНО У МЕНЕ ІЗ ПРЕДИКАТАМИ, НЕ ДУЖЕ ЇХ РОЗУМІЮ :/*/
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

    // TO DISPLAY INFO OF SPECIFIC BY ITS MODEL CAR FROM THE LIST 

    public string DisplayCar(string model)
    {
        // THE EMPTY LINE CAN APPEAR.
        return CurrentCars.Find(x => x.Model.Contains(model)).ToString();
    }

    // TO DISPLAY LIST OF CARS.

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"({CurrentCars.IndexOf(car)})~~|{car.Brand} -- {car.Model} -- YEAR: {car.year}\n-- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.Record.NumberPlate} -- VINCODE: {car.VinCode} |~~\n");    
        }

        return _carsInfo.ToString();
    }

    // CONSTRUCTORS

    public CarServiceManager()
    {
        this._random = new Random();
        this._carsInfo = new StringBuilder();
    }

    // GET NEW CAR
    // GENERATE CAR LIST
    // DELETE CAR FROM LIST
    // GET CAR INFO
}
