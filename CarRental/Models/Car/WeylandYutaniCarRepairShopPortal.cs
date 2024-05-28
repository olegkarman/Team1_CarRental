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
        // CarServiceManager serviceManager = new CarServiceManager();

        // DATA INITIALIZATION

        BrandModelsNamesDataSheet dataSheet = new BrandModelsNamesDataSheet();

        /**/

        /*internal void SetBrandRecords(BrandModelsNamesDataSheet brandModelsNamesDataSheet)*/


        BrandRecord[] brandRecords =
        [
            // ZAPOROZHETS
            new BrandRecord
            (
                // ID
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[0].ToUpper()),

                // ZAPOROZHETS
                dataSheet.BrandNamesData[0],

                // SELECTS PROPER NAMES FOR THE ARRAY AND COPY IT INTO AN ARRAY AND THEN INTO RECORD-CLASS.

                dataSheet.ModelNamesData[0..2]
            ),

            // PEUGEOT
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[1].ToUpper()),

                dataSheet.BrandNamesData[1],

                dataSheet.ModelNamesData[3..13]
            ),

            // VOLKSWAGEN
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[2].ToUpper()),

                dataSheet.BrandNamesData[2],

                dataSheet.ModelNamesData[14..24]
            ),

            // NISSAN
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[3].ToUpper()),

                dataSheet.BrandNamesData[3],

                dataSheet.ModelNamesData[25..35]
            ),

            // GYGULI
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[4].ToUpper()),

                dataSheet.BrandNamesData[4],

                dataSheet.ModelNamesData[36..42]
            ),

            // JEEP
            new BrandRecord
            (
                (DateTime.Now.ToString() + dataSheet.BrandNamesData[5].ToUpper()),

                dataSheet.BrandNamesData[5],

                dataSheet.ModelNamesData[43..52]
            )
        ];


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
