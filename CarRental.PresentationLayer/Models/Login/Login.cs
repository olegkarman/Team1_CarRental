using CarRental.Models.Serialiser;
using System.Text.Json;

namespace CarRental.Data.Models.Login;

public class Login
{
    public string UsersFileName;
    public JsonSerializerOptions Options;

    public Login()
    {
        InitializeLoginProps();
    }
    public void CheckIfFileExists(string fileName)
    {
        if (!File.Exists(fileName))
        {
            File.Create(fileName).Close();
        }
    }
    public void InitializeLoginProps()
    {
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        Directory.SetCurrentDirectory(projectDirectory);
        UsersFileName = Path.Combine(Directory.GetCurrentDirectory(), "users.json");

        CheckIfFileExists(UsersFileName);

        Options = new JsonSerializerOptions();
        Options.Converters.Add(new UserJsonConverter());
    }
}
