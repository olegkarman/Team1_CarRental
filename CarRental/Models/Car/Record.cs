using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Models.Car;

internal class Record : ICarRecordable
{
    // THE PURPOSE OF THE CLASS:
    // // THE ADDITIONAL INFORMATION ABOUT A SPECIFIC CAR.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES.

    // ID OF RECORD.
    public string RecordId { get; init; }
    public Guid uiD { get; init; }

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

    // METHODS

    public override string ToString()
    {
        return $"{nameof(this.RecordId)} = {RecordId} | {nameof(this.RecordCreationDate)} = {RecordCreationDate} | {nameof(this.BrandName)} = {BrandName} | {nameof(this.ModelName)} = {ModelName} | {nameof(this.Year)} = {Year} | {nameof(this.NumberPlate)} = {NumberPlate} | {nameof(this.VinCode)} = {VinCode} | {nameof(this.Price)} = {Price} | {nameof(this.uiD)} = {uiD} | {nameof(this.IsFitForUse)} = {IsFitForUse} | {nameof(this.TechnicalInfo)} = {TechnicalInfo} | }}";
    }
}
