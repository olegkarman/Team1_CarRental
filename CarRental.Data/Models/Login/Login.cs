using System.Text.Json;
using CarRental.Data.Models.Serialiser;

namespace CarRental.Data.Models.Login;

public class Login
{
    public string UsersFileName;
    private JsonSerializerOptions _options;

    public Login()
    {
        InitializeLoginProps();
    }
    private void CheckIfFileExists(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close();
        }
    }
    private void InitializeLoginProps()
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        Directory.SetCurrentDirectory(projectDirectory);
        UsersFileName = Path.Combine(Directory.GetCurrentDirectory(), "users.json");

        CheckIfFileExists(UsersFileName);

        _options = new JsonSerializerOptions();
        _options.Converters.Add(new UserJsonConverter());
    }
}
