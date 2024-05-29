using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Car;

public class WeylandYutaniCarRepairShopPortal
{
    public static void DisplayMenu()
    {
        Console.WriteLine("        .\r\n       ,O,\r\n      ,OOO,\r\n'oooooOOOOOooooo'\r\n  `OOOOOOOOOOO`\r\n    `OOOOOOO`\r\n    OOOO'OOOO\r\n   OOO'   'OOO\r\n  O'         'O\n\u2606☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\nWE PROUD TO WELCOME YOU IN WEYLAND-YUTANI CAR REPAIR SHOP!!!\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆");

        WYCDepot depo = InitializeDepot();
        BrandModelsNamesDataSheet data = InitializeData();
        PatternInitializator patternInit = InitializePatternInitializator();
        BrandRecord[] brandRecords = InitializeBrandRecords(patternInit, data);
        
    }

    static public BrandRecord[] InitializeBrandRecords(PatternInitializator patternInitializator, BrandModelsNamesDataSheet data)
    {
        return patternInitializator.InitializeBrandRecords(data);
    }

    static public PatternInitializator InitializePatternInitializator()
    {
        return new PatternInitializator();
    }

    static public BrandModelsNamesDataSheet InitializeData()
    {
        return new BrandModelsNamesDataSheet();
    }

    static public WYCDepot InitializeDepot()
    {
        return new CarRental.Models.Car.WYCDepot();
    }

    public static void Initialize()
    {
        //WYCDepot depot = new CarRental.Models.Car.WYCDepot();
        // /**/
        // CarServiceManager serviceManager = new CarServiceManager();

        // DATA INITIALIZATION

        //BrandModelsNamesDataSheet dataSheet = new BrandModelsNamesDataSheet();

        /**/

        /*internal void SetBrandRecords(BrandModelsNamesDataSheet brandModelsNamesDataSheet)*/

        //Console.WriteLine(depot.GetNewCar());

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
