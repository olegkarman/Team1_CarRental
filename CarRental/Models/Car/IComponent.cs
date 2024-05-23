using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public interface IComponent
{
    public ComponentStatus Status { get; set; }
}
