using System.Text.Json;

public static class Serializer
{
    public static void SerializeToFile<T>(string filePath, T objectToSerialize)
    {
        var jsonString = JsonSerializer.Serialize(objectToSerialize);
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

        var data = JsonSerializer.Deserialize<List<T>>(jsonString);

        return data;
    }
}
