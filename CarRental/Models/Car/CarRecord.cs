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

    public CarRecord()
    {
        this.RecordId = _noInfo;
        this.VinCode = _noInfo;
        this.BrandName = _noInfo;
        this.ModelName = _noInfo;
        this.NumberPlate = _noInfo;
        this.RecordCreationDate = DateTime.Now.ToString();
        this.Year = 0;
        this.Price = 0;
        this.IsFitForUse = false;
        this.TechnicalInfo = _noInfo;
    }

    public CarRecord
    (
        string recordId,
        string vinCode,
        string brandName,
        string modelName,
        string numberPlate,
        string recordCreationDate,
        int year,
        int price,
        bool isFitForUse,
        string technicalInfo
    )
    {
        this.RecordId = recordId;
        this.VinCode = vinCode;
        this.BrandName = brandName;
        this.ModelName = modelName;
        this.NumberPlate = numberPlate;
        this.RecordCreationDate = recordCreationDate;
        this.Year = year;
        this.Price = price;
        this.IsFitForUse = isFitForUse;
        this.TechnicalInfo = technicalInfo;
    }
}
