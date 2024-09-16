namespace CarRental.BussinessLayer.Interfaces
{
    public interface IIndexValidation
    {
        public void ValidateIndexOfList<T>(List<T> models, int index);
        public void ValidateList<T>(List<T> models);
        public void ValidateDictionary(Dictionary<string, string> dictionary);
    }
}
