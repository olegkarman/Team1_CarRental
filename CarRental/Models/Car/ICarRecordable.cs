using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public interface ICarRecordable
{
    public string BrandName { get; }
    public string[] Models { get; }
}
