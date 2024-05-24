using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal static class CarCheckExtensions
{
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
