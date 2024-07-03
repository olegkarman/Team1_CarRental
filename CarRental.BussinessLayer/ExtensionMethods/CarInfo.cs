using CarRental.Data.Enums;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.RecordTypes;

namespace CarRental.BussinessLayer.ExtensionMethods;

internal static class CarInfo
{
    // THE PURPOSE OF THE CLASS:
    // // A HOLDER OF ADDITIONAL METHODS TO CHECK A CAR STATUS.

    // FIELDS

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

    public static string Light(this Car car)
    {
        return car.Lights;
    }

    public static string TechnicalInfo(this Car car)
    {
        return $"{nameof(car.Engine)} = {car.Engine} | {nameof(car.Transmission)} = {car.Transmission} | {nameof(car.Interior)} = {car.Interior} | {nameof(car.Wheels)} = {car.Wheels} | {nameof(car.Lights)} = {car.Lights} | {nameof(car.Signal)} = {car.Signal} | {nameof(car.MaxFuelCapacity)} = {car.MaxFuelCapacity} | {nameof(car.CurrentFuel)} = {car.CurrentFuel} |";
    }

    public static string ExploitationInfo(this Car car)
    {
        return $"{nameof(car.Mileage)} = {car.Mileage} | {nameof(car)} сapitally repaired {car.Repairs.Count} times.";
    }
}
