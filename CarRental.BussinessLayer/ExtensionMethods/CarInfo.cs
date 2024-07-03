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

        // foreeach CANNOT ACCESS ELEMENTS OF AN ARRAY, SO THE for-LOOP IS USED.
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
        return $"{nameof(car.Mileage)} = {car.Mileage} | {nameof(car)} сapitally repaired {car.Repairs.Count} times.";
    }
}
