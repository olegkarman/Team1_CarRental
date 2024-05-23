using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class DriverCabin : ICarControllable
{
    public bool LetsDrive(IDriveable driver)
    {
        base.SetMaxSpeed();  // SET MAX SPEED BASED ON ENGINE AND SPEED COEFICIENT.

        // STOP METHOD IF NO FUEL.
        if (CurrentFuelCapacity == 0)
        {
            return false;
        }
        else
        {
            driver.Drive(base.MaxSpeed, out int averageSpeed, out int drivingTime);

            // A CAR CANNOT DRIVE WITHOUT REFILLING THE FUEL STOCK.
            if (drivingTime > this.CurrentFuelCapacity / this.Engine.AverageFuelConsumption)
            {
                drivingTime = this.CurrentFuelCapacity / this.Engine.AverageFuelConsumption;
            }

            // TO INCREASE AVTOPROBIG.
            this._mileage = this._mileage + (averageSpeed * drivingTime);

            return true;
        }
    }
}
