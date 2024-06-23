using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Interfaces;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.Data.Models.Automobile;

public class Brand
{
    // THE PURPOSE OF THE CLASS:
    // // A CLASS TO HOLD INFO ABOUT BRANDS OF CARS.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public string RecordId { get; init; }
    public string BrandName { get; init; }
    public string[] Models { get; init; }
    /*public Dictionary<string, ICarSelectivePattern> ModelPattern { get; set; }*/

    // CONSTRUCTORS

    public Brand()
    {
        
    }

    public Brand(string recordId, string brandName, string[] models/*, Dictionary<string, ICarSelectivePattern> dictionaryModelPattern*/)
    {
        this.RecordId = recordId;
        this.BrandName = brandName;
        this.Models = models;
        //this.ModelPattern = dictionaryModelPattern;
    }
}
