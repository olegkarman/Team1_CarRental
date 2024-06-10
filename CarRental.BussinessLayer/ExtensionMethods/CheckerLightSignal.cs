using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

namespace CarRental.BussinessLayer.ExtensionMethods;

internal static class CheckerLightSignal
{
    // THE PURPOSE OF THE CLASS:
    // // A HOLDER OF ADDITIONAL METHODS TO CHECK A CAR STATUS.

    // METHODS

    public static PitchComponent Signal(this Car car)
    {
        return car.Signal.Pitch;
    }

    public static PowerComponent Light(this Car car)
    {
        return car.Lights.Power;
    }
}
