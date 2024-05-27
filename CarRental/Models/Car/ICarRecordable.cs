using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public interface ICarRecordable : IRecordable
{
    public string BrandName { get; init; }
    public string ModelName { get; init; }
    public string VinCode { get; init; }
    public string NumberPlate { get; set; }
    public int Year { get; init; }
    public string RecordCreationDate { get; init; }
    public int Price { get; set; }
    public bool IsFitForUse {get; set; }
    public string TechnicalInfo { get; set; }
}
