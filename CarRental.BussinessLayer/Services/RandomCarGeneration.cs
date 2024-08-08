using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using CarRental.Data.Enums;

namespace CarRental.BussinessLayer.Services
{
    public class RandomCarGeneration
    {
        // FIELDS

        private char[] _charMap;
        private Random _pseudoRandom;
        private StringBuilder _identificatorBuilder;

        // PROPERTIES

        internal string[] Models { get; init; }
        internal string[] Brands { get; init; }
        internal string[] Engines { get; init; }
        internal string[] Transmissions { get; init; }
        internal string[] Interiors { get; init; }
        internal string[] Wheels { get; init; }
        internal string[] Lights { get; init; }
        internal string[] Signals { get; init; }

        // PROPERTIES

        // CONSTRUCTORS

        public RandomCarGeneration()
        {
            this._charMap = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];
            this._pseudoRandom = new Random();
            this._identificatorBuilder = new StringBuilder();
        }

        // METHODS

        internal Guid GetNewCarId()
        {
            return Guid.NewGuid();
        }

        internal string GetNewVinCode()
        {
            return GetIdentificator();
        }

        internal string GetNewModelName()
        {
            return Models[_pseudoRandom.Next(0, Models.Length)];
        }

        internal string GetNewBrandName()
        {
            return Brands[_pseudoRandom.Next(0, Brands.Length)];
        }

        internal string GetNewNumberPlate()
        {
            return GetIdentificator().Substring(0, 9).Insert(2, "-").Insert(8, "-");
        }

        internal int GetNewPrice()
        {
            return _pseudoRandom.Next(5000, 350001);
        }
        //    _carServiceManager.CurrentCars.Add(_carServiceManager.GetNewCar(guid, vinCode, model, brand, numberPlate, price));

        public string GetNewEngine()
        {
            return Engines[_pseudoRandom.Next(0, Engines.Length)];
        }

        public string GetNewTransmission()
        {
            return Transmissions[_pseudoRandom.Next(0, Transmissions.Length)];
        }

        public string GetNewInterior()
        {
            return Interiors[_pseudoRandom.Next(0, Interiors.Length)];
        }

        public string GetNewWheels()
        {
            return Wheels[_pseudoRandom.Next(0, Wheels.Length)];
        }

        public string GetNewLights()
        {
            return Lights[_pseudoRandom.Next(0, Lights.Length)];
        }

        public string GetNewSignal()
        {
            return Signals[_pseudoRandom.Next(0, Signals.Length)];
        }

        public KnownColor GetNewColor()
        {
            try
            {
                return (KnownColor)_pseudoRandom.Next(28, 175);
            }
            catch (InvalidCastException exception)
            {
                throw exception;
            }
        }

        public int GetNewNumberOfSeats()
        {
            return _pseudoRandom.Next(1, 13);
        }

        public int GetNewNumberOfDoors()
        {
            return _pseudoRandom.Next(1, 8);
        }

        public float GetNewMileage()
        {
            return (float)_pseudoRandom.Next(500, 8000000);
        }

        public int GetNewYear()
        {
            return _pseudoRandom.Next(1962, 2025);
        }

        public int GetNewMaxFuelCapacity()
        {
            return _pseudoRandom.Next(10, 1001);
        }

        public float GetNewCurrentFuel()
        {
            return _pseudoRandom.Next(10, 1001);
        }

        public TransportStatus GetNewStatus()
        {
            int resultStatusNumber;

            int generatedNumber = _pseudoRandom.Next(0, 6);

            switch (generatedNumber)
            {
                case 1:
                    resultStatusNumber = 1;
                    break;
                case 2:
                    resultStatusNumber = 2;
                    break;
                case 3:
                    resultStatusNumber = 3;
                    break;
                case 4:
                    resultStatusNumber = 4;
                    break;
                case 5:
                    resultStatusNumber = 200;
                    break;
                default:
                    resultStatusNumber = 0;
                    break;
            }

            return (TransportStatus)resultStatusNumber;
        }

        public bool GetNewIsFitForUse()
        {
            if (_pseudoRandom.Next(0, 11) < 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private string GetIdentificator()
        {
            _identificatorBuilder.Clear();

            for (int index = 0; index < 33; index = index + 1)
            {
                _identificatorBuilder.Append(_charMap[_pseudoRandom.Next(0, _charMap.Length)]);
            }

            return _identificatorBuilder.ToString();
        }
    }
}
