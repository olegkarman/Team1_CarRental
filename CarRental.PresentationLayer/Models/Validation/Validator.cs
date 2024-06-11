using System.Text.RegularExpressions;

namespace CarRental.Data.Models.Validation;
public static class Validator
{
    public static bool IsValidName(string name = "")
    {
        Regex regex = new Regex(@"^[A-Za-z]+$");
        return !string.IsNullOrWhiteSpace(name) && regex.IsMatch(name);
    }
}
