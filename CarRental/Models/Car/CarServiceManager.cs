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
    internal Car OntainNewCar(Depot depot, CarSelectPattern pattern)
    {
        return depot.GetNewCar(pattern);
    }

    // TO GET RANDOM CAR

    internal Car OntainNewCar(Depot depot, Dictionary<string, CarSelectPattern> patterns)
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

    // DISPLAY SELECTED CAR INFO

    public string DisplayCurrentCar()
    {
        return this.SelectedCar.ToString();    // MAKE BETTER FORMATTING PLS.
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
