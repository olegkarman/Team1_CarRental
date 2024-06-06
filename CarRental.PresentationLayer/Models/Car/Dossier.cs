using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Interfaces;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 3. Methods, properties"
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 30-MAY-2024

namespace CarRental.Data.Models.Car;

// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

public class Dossier : IDossierable
{
    // THE PURPOSE OF THE CLASS:
    // // THE ADDITIONAL INFORMATION ABOUT A SPECIFIC CAR.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES.

    // ID OF RECORD.
    public string DossierId { get; init; }
    public Guid uiD { get; init; }

    // CAR VIN CODE.
    public string VinCode { get; init; }

    public string BrandName { get; init; }
    public string ModelName { get; init; }

    // CURRENT CAR NUMBER.
    public string NumberPlate { get; set; }

    // CREATION DATE.
    //public DateTime RecordCreationDate { get; init; }
    public string DossierCreationDate { get; init; }

    public int Year { get; init; }

    // PRICE.
    public int Price { get; set; }

    // IS FIT FOR USE?
    public bool IsFitForUse { get; set; }

    public ICanDrive LastDriver { get; set; }

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
        return $"{nameof(this.DossierId)} = {DossierId} | {nameof(this.DossierCreationDate)} = {DossierCreationDate} | {nameof(this.BrandName)} = {BrandName} | {nameof(this.ModelName)} = {ModelName} | {nameof(this.Year)} = {Year} | {nameof(this.NumberPlate)} = {NumberPlate} | {nameof(this.VinCode)} = {VinCode} | {nameof(this.Price)} = {Price} | {nameof(this.uiD)} = {uiD} | {nameof(this.IsFitForUse)} = {IsFitForUse} | {nameof(this.TechnicalInfo)} = {TechnicalInfo} | }}";
    }
}
