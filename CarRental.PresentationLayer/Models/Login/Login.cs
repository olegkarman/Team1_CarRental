using CarRental.Models.Serialiser;
using System.Text.Json;

namespace CarRental.Data.Models.Login;

public class Login
{
    public readonly string UsersFileName;
    public JsonSerializerOptions Options;

    public void CheckIfFileExists(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close();
        }
    }

    public Login()
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        Directory.SetCurrentDirectory(projectDirectory);
        UsersFileName = Path.Combine(Directory.GetCurrentDirectory(), "users.json");

        CheckIfFileExists(UsersFileName);

        Options = new JsonSerializerOptions();
        Options.Converters.Add(new UserJsonConverter());
    }
}
