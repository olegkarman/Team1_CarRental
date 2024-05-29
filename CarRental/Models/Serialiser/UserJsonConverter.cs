using System.Text.Json.Serialization;
using System.Text.Json;

namespace CarRental.Models.Serialiser;

public class UserJsonConverter : JsonConverter<User>
{
    public override User Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;

        if (jsonObject.GetProperty("DrivingLicenseNumber").GetString() != null)
        {
            return JsonSerializer.Deserialize<Customer>(jsonObject.GetRawText());
        }
        else
        {
            return JsonSerializer.Deserialize<Inspector>(jsonObject.GetRawText());
        }
    }

    public override void Write(Utf8JsonWriter writer, User value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, (dynamic)value, options);
    }
}
