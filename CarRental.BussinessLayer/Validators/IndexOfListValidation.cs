using CarRental.BussinessLayer.Interfaces;

namespace CarRental.BussinessLayer.Validators
{
    public class IndexOfListValidation : IIndexValidation
    {
        // METHODS

        public void ValidateIndexOfList<T>(List<T> models, int index)
        {
            if ((index < 0) || (index >= models.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void ValidateList<T>(List<T> models)
        {
            // LOGIC OF VALDIATION (IN FUTURE UPDATES).
        }

        public void ValidateDictionary<T>(Dictionary<T, string> dictionary)
        {
            // LOGIC OF VALIDATION.
        }
    }
}
