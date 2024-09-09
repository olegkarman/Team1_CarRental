namespace CarRental.BussinessLayer.Interfaces
{
    public interface IRandomCarGeneration
    {
        // METHODS

        public Guid GetNewCarId();
        public string GetNewVinCode();
        public string GetNewNumberPlate();
    }
}
