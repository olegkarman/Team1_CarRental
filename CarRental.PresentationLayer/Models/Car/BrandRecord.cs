using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Data.Models.Car;

public class BrandRecord : IBrandRecordable
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

    public BrandRecord()
    {
        
    }

    public BrandRecord(string recordId, string brandName, string[] models/*, Dictionary<string, ICarSelectivePattern> dictionaryModelPattern*/)
    {
        this.RecordId = recordId;
        this.BrandName = brandName;
        this.Models = models;
        //this.ModelPattern = dictionaryModelPattern;
    }
}
