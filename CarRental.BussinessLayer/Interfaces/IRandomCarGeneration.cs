using System.Drawing;
using CarRental.Data.Enums;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IRandomCarGeneration
    {
        // PROPERTIES

        public string[] Models { get; set; }
        public string[] Brands { get; set; }
        public string[] Engines { get; set; }
        public string[] Transmissions { get; set; }
        public string[] Interiors { get; set; }
        public string[] Wheels { get; set; }
        public string[] Lights { get; set; }
        public string[] Signals { get; set; }

        // METHODS

        public Guid GetNewCarId();
        public string GetNewVinCode();
        public string GetNewNumberPlate();
        public string GetNewModelName();
        public string GetNewBrandName();
        public int GetNewPrice();
        public string GetNewEngine();
        public string GetNewTransmission();
        public string GetNewInterior();
        public string GetNewWheels();
        public string GetNewLights();
        public string GetNewSignal();
        public KnownColor GetNewColor();
        public int GetNewNumberOfSeats();
        public int GetNewNumberOfDoors();
        public float GetNewMileage();
        public int GetNewYear();
        public int GetNewMaxFuelCapacity();
        public float GetNewCurrentFuel();
        public TransportStatus GetNewStatus();
        public bool GetNewIsFitForUse();
    }
}
