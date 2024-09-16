namespace CarRental.Data.Models;

public abstract class User
{
    // PROPERTIES

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Password { get; init; }
    public string UserName { get; init; }
    public string IdNumber { get; init; }

    // CONSTRUCTORS

    public User()
    {

    }

    protected User(string firstName, string lastName, DateTime dateOfBirth, string password, string userName)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Password = password;
        UserName = userName;
        IdNumber = Guid.NewGuid().ToString();
    }

    // METHODS

    public bool ValidateCredentials(string login, string password)
    {
        if (login == UserName && password == Password)
        {
            return true;
        }
        return false;
    }

    public bool ValidateCredentials(string login)
    {
        if (login == UserName)
        {
            return true;
        }
        return false;
    }
}