using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

internal class CarRecord : ICarRecordable
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES.

    // ID OF RECORD.
    public string RecordId { get; init; }

    // CAR VIN CODE.
    public string VinCode { get; init; }

    public string BrandName { get; init; }
    public string ModelName { get; init; }

    // CURRENT CAR NUMBER.
    public string NumberPlate { get; set; }

    // CREATION DATE.
    //public DateTime RecordCreationDate { get; init; }
    public string RecordCreationDate { get; init; }

    public int Year { get; init; }

    // PRICE.
    public int Price { get; set; }

    // IS FIT FOR USE?
    public bool IsFitForUse { get; set; }

    // TECH-INFO.
    public string TechnicalInfo { get; set; }

    // CURRENT OWNER.
    // INSPECTION[S].
    // REPAIR[S].
    // INSURANCE.

    // CONSTRUCTORS

    public CarRecord
    (
        string recordId,
        string vinCode,
        string brandName,
        string modelName,
        string recordCreationDate,
        int year
    )
    {
        this.RecordId = recordId;
        this.VinCode = vinCode;
        this.BrandName = brandName;
        this.ModelName = modelName;
        this.RecordCreationDate = recordCreationDate;
        this.Year = year;
    }
}
