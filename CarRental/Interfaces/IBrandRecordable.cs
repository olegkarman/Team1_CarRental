using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Interfaces;

internal interface IBrandRecordable : IRecordable
{
    public string BrandName { get; init; }
    public string[] Models { get; init; }
}
