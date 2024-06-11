using System.Text.Json;

namespace CarRental.Data.Models.Serialiser;

public static class Serializer
{
    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        AllowTrailingCommas = true,
        IncludeFields = true,
        Converters = { new UserJsonConverter() }
    };
    public static void SerializeToFile<T>(string filePath, T objectToSerialize)
    {
        var jsonString = JsonSerializer.Serialize(objectToSerialize, options);
        File.WriteAllText(filePath, jsonString);
    }

    public static List<T> DeserializeFromFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "[]");
        }

        var jsonString = File.ReadAllText(filePath);

        if (jsonString.Length == 0)
        {
            return new List<T>();
        }

        var data = JsonSerializer.Deserialize<List<T>>(jsonString, options);

        return data;
    }
}