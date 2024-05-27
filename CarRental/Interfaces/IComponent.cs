using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Enumerables;

namespace CarRental.Interfaces;

public interface IComponent
{
    public ComponentStatus Status { get; set; }
}
