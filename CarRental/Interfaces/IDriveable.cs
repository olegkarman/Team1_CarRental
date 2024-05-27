using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Interfaces;

public interface IDriveable
{
    // WHAT RETURN TYPE TO CHOOSE?
    public bool Drive(ICanDrive driver, IDrivingPattern pattern);
}
