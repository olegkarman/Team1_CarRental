using System;
using System.Collections.Generic;
using System.Linq;
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

    // METHODS

    // TO GET SPECIFIC CAR
    internal Car OntainNewCar(Depot depot, CarSelectPattern pattern)
    {
        return depot.GetNewCar(pattern);
    }

    // GET RANDOM CAR.
    internal Car OntainNewCar(Depot depot, Dictionary<string, CarSelectPattern> patterns)
    {
        // KEYS OF THE DICTIONARY INTO ARRAY.
        string[] models = patterns.Keys.ToArray();

        // TO SELECT A RANDOM PATTERN FROM THE DICTIONARY.
        return depot.GetNewCar(patterns[models[_random.Next(0, models.Length)]]);
    }

    // TO DISPLAY LIST OF CARS.

    public string DisplayCurrentCars()
    {
        _carsInfo.Clear();

        foreach (Car car in CurrentCars)
        {
            _carsInfo.Append($"~~|{car.Brand} -- {car.Model} -- YEAR: {car.year} -- PRICE: {car.Price} EUR -- STATUS: {car.Status} -- IS FIT FOR USE?: {car.IsFitForUse} -- NUMBER: {car.Record.NumberPlate} -- VINCODE: {car.VinCode} |~~");    
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
