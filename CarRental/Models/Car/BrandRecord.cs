using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public record class BrandRecord : IBrandRecordable
{
    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES

    public string RecordId { get; init; }
    public string BrandName { get; init; }
    public string[] Models { get; init; }

    // CONSTRUCTORS

    public BrandRecord ()
    {
        this.RecordId = _noInfo;
        this.BrandName = _noInfo;
        this.Models = [_noInfo];
    }

    public BrandRecord(string recordId, string brandName, string[] models)
    {
        this.RecordId = recordId;
        this.BrandName = brandName;
        this.Models = models;
    }
}
