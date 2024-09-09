using CarRental.BussinessLayer.Interfaces;

namespace CarRental.Data.Models.Automobile.RecordTypes;

public record class PatternCharMapsDto : ICharMaps
{
    // PROPERTIES

    public List<char[]> CharMaps { get; init; }

    // METHODS

    public void InitializeCharMap(List<char[]> charMap)
    {
        // SOME LOGIC MAY BE IMPLEMENTED IN FUTURE
    }

    public List<char[]> CreateCustomeCharMap(char[] chars)
    {
        // LOGIC

        return new List<char[]>();
    }

    // CONSTRUCTOR

    public PatternCharMapsDto()
    {
        this.CharMaps = new List<char[]>();
        this.CharMaps.Add(['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9']);
        this.CharMaps.Add(['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z']);
        this.CharMaps.Add(['0', '1', '2', '3', '4', '5', '6', '7', '8', '9']);
    }
}
