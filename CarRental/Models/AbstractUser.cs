using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;
public abstract class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    private string Password { get; init; }
    private string UserName { get; init; }

    public readonly Guid IdNumber;
    protected User(string firstName, string lastName, DateTime dateOfBirth, string password, string userName)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Password = password;
        UserName = userName;
        IdNumber = Guid.NewGuid();
    }
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
