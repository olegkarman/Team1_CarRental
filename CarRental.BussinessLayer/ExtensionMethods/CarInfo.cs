using System;
using System.Reflection;
using CarRental.Data.Enums;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.RecordTypes;
using System.Text;

namespace CarRental.BussinessLayer.ExtensionMethods;

internal static class CarInfo
{
    // THE PURPOSE OF THE CLASS:
    // // A HOLDER OF ADDITIONAL METHODS TO CHECK A CAR STATUS.

    // FIELDS

    // USED MICROSOFT CONVENTION TO NAME PRIVATE FIELDS.
    private const string _noInfo = "NO INFORAMTION";

    // METHODS

    public static string GetOwnership(this Car car)
    {
        string owner;
        string ownershipType;

        if (car.Owner != null)
        {
            owner = $"{car.Owner.FirstName} {car.Owner.LastName} ({car.Owner.DateOfBirth})";
        }
        else
        {
            owner = _noInfo;
        }

        if (car.Engagement != null)
        {
            ownershipType = car.Engagement.DealType;
        }
        else
        {
            ownershipType = _noInfo;
        }

        return $"OWNER: {owner} | OWNERSHIP: {ownershipType}";
    }

    public static string GetCurrentFuelInPercent(this Car car)
    {
        string result;

        float percentFuel;

        if ((car.CurrentFuel == null) || (car.MaxFuelCapacity == null))
        {
            result = _noInfo;

            return result;
        }

        percentFuel = ((float)car.CurrentFuel / (float)car.MaxFuelCapacity);

        result = String.Format("{0:P0}", percentFuel);

        return result;
    }

    public static string GetTechnicalInfo(this Car car)
    {
        string[] techInfoNames = [nameof(car.Engine), nameof(car.Transmission), nameof(car.Interior), nameof(car.Wheels), nameof(car.Lights), nameof(car.Signal)];

        string[] techInfoStrings = new string[techInfoNames.Length];
        techInfoStrings = [car.Engine, car.Transmission, car.Interior, car.Wheels, car.Lights, car.Signal];

        StringBuilder techInfoBuilder = new StringBuilder();

        // foreeach CANNOT ACCESS THE ELEMENTS OF AN ARRAY, SO for-LOOP IS USED.
        for (int index = 0; index < techInfoStrings.Length; index = index + 1)
        {
            if(string.IsNullOrEmpty(techInfoStrings[index]))
            {
                techInfoStrings[index] = _noInfo;
            }

            techInfoBuilder.Append(techInfoNames[index]);
            techInfoBuilder.Append(" = ");
            techInfoBuilder.Append(techInfoStrings[index]);
            techInfoBuilder.Append(" | ");
        }

        return techInfoBuilder.ToString();
    }

    public static string GetExploitationInfo(this Car car)
    {
        string mileage;
        string repairsCount;

        if (car.Mileage != null)
        {
            mileage = car.Mileage.ToString(); 
        }
        else
        {
            mileage = _noInfo;
        }

        if (car.Repairs != null)
        {
            repairsCount = car.Repairs.Count.ToString();
        }
        else
        {
            repairsCount = _noInfo;
        }

        return $"{nameof(car.Mileage)} = {mileage} | {nameof(car)} сapitally repaired {repairsCount} times.";
    }

    public static bool AreAllComponentsPresent(this Car car)
    {
        bool areNotAllComponentsPresent = String.IsNullOrEmpty(car.Engine) || String.IsNullOrEmpty(car.Transmission) || String.IsNullOrEmpty(car.Interior) || String.IsNullOrEmpty(car.Wheels) || String.IsNullOrEmpty(car.Lights) || String.IsNullOrEmpty(car.Signal);

        return !areNotAllComponentsPresent;
    }

    public static string GetAge(this Car car)
    {
        if (car.Year != null)
        {
            return $"{(int)DateTime.Now.Year - (int)car.Year}";
        }
        else
        {
            return _noInfo;
        }
    }
}
