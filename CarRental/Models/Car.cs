using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models;

internal class Car
{
    //THE COMMENT OF O. KARMANSKYI.
    /*VinCode: string
    SerialNumber: string
    TransmissionType: string
    Model: string
    Brand: string
    Year: int
    Status: string (available, rented, sold, in repair, etc.)
    Methods:
    TakeCarFromParking()
    SendToRepair()
    Refuel()
    RemoveCar()*/

    // FIELDS

    const string InvalidCar = "Car has no mark";
    internal readonly string Year;

    // PROPERTIES

    internal required string Id { get; init; }
    internal string Mark { get; init; }

    // CONSTRUCTORS


    // METHODS


}
