using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public class WeylandYutaniCarRepairShopPortal
{
    public static void DisplayMenu()
    { 
        Console.WriteLine("        .\r\n       ,O,\r\n      ,OOO,\r\n'oooooOOOOOooooo'\r\n  `OOOOOOOOOOO`\r\n    `OOOOOOO`\r\n    OOOO'OOOO\r\n   OOO'   'OOO\r\n  O'         'O\n\u2606☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\nWE PROUD TO WELCOME YOU IN WEYLAND-YUTANI CAR REPAIR SHOP!!!\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆");

        WYCDepot depot = new CarRental.Models.Car.WYCDepot();
        // /**/
        // BrandModelsNamesDataSheet dataSheet = new BrandModelsNamesDataSheet();
        // CarServiceManager serviceManager = new CarServiceManager();

        /*internal void SetBrandRecords(BrandModelsNamesDataSheet brandModelsNamesDataSheet)
    {
        // DATA INITIALIZATION
        
        //this._brandModelData = new BrandModelsNamesDataSheet();
        //this._patternInit = new PatternInitializator(_brandModelData);

        this._records =
        [
            // ZAPOROZHETS
            new BrandRecord
            (
                // ID
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[0].ToUpper()),

                // ZAPOROZHETS
                _brandModelData.BrandNamesData[0],

                // SELECTS PROPER NAMES FOR THE ARRAY AND COPY IT INTO AN ARRAY AND THEN INTO RECORD-CLASS.

                _brandModelData.ModelNamesData[0..2]
            ),

            // PEUGEOT
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[1].ToUpper()),

                _brandModelData.BrandNamesData[1],

                _brandModelData.ModelNamesData[3..13]
            ),

            // VOLKSWAGEN
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[2].ToUpper()),

                _brandModelData.BrandNamesData[2],

                _brandModelData.ModelNamesData[14..24]
            ),

            // NISSAN
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[3].ToUpper()),

                _brandModelData.BrandNamesData[3],

                _brandModelData.ModelNamesData[25..35]
            ),

            // GYGULI
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[4].ToUpper()),

                _brandModelData.BrandNamesData[4],

                _brandModelData.ModelNamesData[36..42]
            ),

            // JEEP
            new BrandRecord
            (
                (DateTime.Now.ToString() + _brandModelData.BrandNamesData[5].ToUpper()),

                _brandModelData.BrandNamesData[5],

                _brandModelData.ModelNamesData[43..52]
            )
        ];*/


        Console.WriteLine(depot.GetNewCar());

        // VIEW CAR TECHNICAL INFO.
        // VIEW CAR RECORD.
        // VIEW MECHANIC INFO.
        // VIEW CAR IN DEPO.
        // VIEW CAR IN SHOP.
        // MAKE CHECK-UP FOR SELECTED CAR.
        // MAKE REPAIR FOR SELECTED CAR.
        // MAKE TUNNING (CHANGE PARTS).
        // CHANGE COLOR.
        // WASH A CAR?
        // EXTENSION METHODS: TRY BEEP, TRY LIGHTS.
        // MAKE TEST DRIVE FOR SELECTED CAR.
        // MOVE CAR INTO DEPO.
        // MOVE CAR INTO THE SHOP.
    }
}
