namespace CarRental.BussinessLayer.Interfaces
{
    public interface ITextProcessing
    {
        public string ReplaceSpacesByEmpty(string inputString);
        public string ParseOutputCarsInfo(string carsInfo);
        public string ParseOutputCarInfo(string carInfo);
    }
}
