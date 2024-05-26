using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public interface ICarRecordable : IRecordable
{
    //public string RecordId { get; init; }
    public string BrandName { get; init; }
    public string ModelName { get; init; }
    public string VinCode { get; init; }
    public string NumberPlate { get; set; }
    public int Year { get; init; }
    //public DateTime RecordCreationDate { get; init; }
    public string RecordCreationDate { get; init; }
    //public string Insurance { get; set; }
    public int Price { get; set; }
    public bool IsFitForUse {get; set; }
    public string TechnicalInfo { get; set; }
    //public List<Inspection> Inspection { get; set; }
    //public List<Repair> Repairs { get; set; }
}
