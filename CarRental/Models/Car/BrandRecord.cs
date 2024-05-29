using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Interfaces;

namespace CarRental.Models.Car;

public class BrandRecord : IBrandRecordable
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public string Id { get; init; }
    public string Name { get; init; }
    public string[] Models { get; init; }
    /*public Dictionary<string, ICarSelectivePattern> ModelPattern { get; set; }*/

    // CONSTRUCTORS

    public BrandRecord(string recordId, string brandName, string[] models/*, Dictionary<string, ICarSelectivePattern> dictionaryModelPattern*/)
    {
        this.Id = recordId;
        this.Name = brandName;
        this.Models = models;
        //this.ModelPattern = dictionaryModelPattern;
    }
}
