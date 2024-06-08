using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Enums;
using CarRental.Data.Models.Car;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 07-JUN-2024

namespace CarRental.Data.Models.Car.ExtensionMethods;

internal static class CheckExtensions
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
