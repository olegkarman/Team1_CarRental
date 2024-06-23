using CarRental.Data.Enums;
using CarRental.Data.Models.Automobile;

namespace CarRental.BussinessLayer.ExtensionMethods;

internal static class CheckerLightSignal
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
}
