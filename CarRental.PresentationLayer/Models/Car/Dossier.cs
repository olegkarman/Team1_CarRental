using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Interfaces;

namespace CarRental.Data.Models.Car;

public class Dossier : IDossierable
{
    // THE PURPOSE OF THE CLASS:
    // // THE ADDITIONAL INFORMATION ABOUT A SPECIFIC CAR.

    // FIELDS

    private const string _noInfo = "NO INFO";

    // PROPERTIES.

    public string DossierId { get; init; }
    public Guid uiD { get; init; }

    public string VinCode { get; init; }

    public string BrandName { get; init; }
    public string ModelName { get; init; }

    public string NumberPlate { get; set; }

    public string DossierCreationDate { get; init; }

    public int Year { get; init; }

    public int Price { get; set; }

    public bool IsFitForUse { get; set; }

    //public ICanDrive LastDriver { get; set; }

    public string TechnicalInfo { get; set; }


    // CONSTRUCTORS

    // METHODS

    public override string ToString()
    {
        return $"{nameof(this.DossierId)} = {DossierId} | {nameof(this.DossierCreationDate)} = {DossierCreationDate} | {nameof(this.BrandName)} = {BrandName} | {nameof(this.ModelName)} = {ModelName} | {nameof(this.Year)} = {Year} | {nameof(this.NumberPlate)} = {NumberPlate} | {nameof(this.VinCode)} = {VinCode} | {nameof(this.Price)} = {Price} | {nameof(this.uiD)} = {uiD} | {nameof(this.IsFitForUse)} = {IsFitForUse} | {nameof(this.TechnicalInfo)} = {TechnicalInfo} | }}";
    }
}
