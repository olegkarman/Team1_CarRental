using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Models.Automobile.RecordTypes;

public record class Brand
{
    // THE PURPOSE OF THE CLASS:
    // // A CLASS TO HOLD INFO ABOUT BRANDS OF CARS.

    // FIELDS

    private const string _noInfo = "NO INFORMATION";

    // PROPERTIES

    public Guid Id { get; init; }
    public string BrandName { get; init; }
    public string[] Models { get; init; }

    // CONSTRUCTORS

    public Brand()
    {

    }

    public Brand(Guid recordId, string brandName, string[] models/*, Dictionary<string, ICarSelectivePattern> dictionaryModelPattern*/)
    {
        Id = recordId;
        BrandName = brandName;
        Models = models;
    }
}
