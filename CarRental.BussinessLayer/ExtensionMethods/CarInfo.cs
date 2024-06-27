using CarRental.Data.Enums;
using CarRental.Data.Models.Automobile;

namespace CarRental.BussinessLayer.ExtensionMethods;

internal static class CarInfo
{
    // THE PURPOSE OF THE CLASS:
    // // A HOLDER OF ADDITIONAL METHODS TO CHECK A CAR STATUS.

    // METHODS

    public static string Signal(this Car car)
    {
        return car.Signal;
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
        return $"{nameof(car.Mileage)} = {car.Mileage} | Capitally repaired {car.Repairs.Count} times.";
    }
}
