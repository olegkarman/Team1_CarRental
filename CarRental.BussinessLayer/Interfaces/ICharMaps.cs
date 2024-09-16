namespace CarRental.BussinessLayer.Interfaces
{
    public interface ICharMaps
    {
        internal List<char[]> CharMaps { get; init; }

        public void InitializeCharMap(List<char[]> charMap);

        public List<char[]> CreateCustomeCharMap(char[] chars);
    }
}
