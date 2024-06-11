using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Car;
using CarRental.BussinessLayer.Managers;


// HILLEL, C# PRO COURSE, TEACHER: MARIIA DZIVINSKA
// HOMEWORK: "ДЗ 4. Extension methods & Record type."
// STUDENT: PARKHOMENKO YAROSLAV
// DATE: 03-JUN-2024

namespace CarRental.Presentation.Models;

public class WeylandYutaniCarRepairShopPortal
{
    // THE PURPOSE OF THE CLASS:
    // // A PROJECT OF AN ADDITIONAL MENU (NOT IMPLEMENTED).

    public static void DisplayMenu()
    {
        Console.WriteLine("        .\r\n       ,O,\r\n      ,OOO,\r\n'oooooOOOOOooooo'\r\n  `OOOOOOOOOOO`\r\n    `OOOOOOO`\r\n    OOOO'OOOO\r\n   OOO'   'OOO\r\n  O'         'O\n\u2606☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\nWE PROUD TO WELCOME YOU IN WEYLAND-YUTANI CAR REPAIR SHOP!!!\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆\n☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆☆");

        // INITIALIZATION

        //BrandModelsNamesDataSheet data = InitializeData();
        //Depot depo = InitializeDepot();
        //PatternInitializator patternInit = InitializePatternInitializator();
        //BrandRecord[] brandRecords = InitializeBrandRecords(patternInit, data);
        //CarServiceManager manager = InitializeManager();
        //Dictionary<string, CarSelectPattern> patterns = InitializeDictionaryModelPattern(patternInit, brandRecords, data);

        ServiceManager serviceManager = new ServiceManager();

        serviceManager.InitializeManagment();

        // TEST
        // \\ // \\ // \\ // \\// \\ // \\ // \\ // \\ // \\ // \\
        Car car = serviceManager.GetNewCar();
        serviceManager.MakeNewListOfCurrentCars(15);
        //serviceManager.TrySelectCar(5);
        //serviceManager.DisplayCurrentCar();
        serviceManager.DisplayCurrentCars();
        //Console.WriteLine(serviceManager.CheckFuelSelectedCar());
        //serviceManager.RefillSelectedCar();
        //Console.WriteLine(serviceManager.ShowMileageSelected());
        //Console.WriteLine(serviceManager.CheckFuelSelectedCar());
        //Console.WriteLine(serviceManager.DisplayCurrentCars());
        //Console.WriteLine(serviceManager.DisplayAllModels());
        //Console.WriteLine(serviceManager.CheckSignal());
        // \\ // \\ // \\ // \\ // \\ // \\ // \\ // \\ // \\ // \\

        //Console.WriteLine("I WANTED TO SELECT: JEEP DAKAR\nI SELECTED:");
        //Console.WriteLine(car);
        //Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        //Console.WriteLine(car.Record);
    }

    //static public ServiceManager InitializeManager()
    //{
    //    return new ServiceManager();
    //}

    //static public Dictionary<string, SelectPattern> InitializeDictionaryModelPattern(PatternInitializator patternInit, BrandRecord[] brandRecords, BrandModelsNamesDataSheet dataWarehouse)
    //{
    //    return patternInit.ChoosePatternForModel(brandRecords, dataWarehouse);
    //}

    //static public BrandRecord[] InitializeBrandRecords(PatternInitializator patternInitializator, BrandModelsNamesDataSheet data)
    //{
    //    return patternInitializator.InitializeBrandRecords(data);
    //}

    //static public PatternInitializator InitializePatternInitializator()
    //{
    //    return new PatternInitializator();
    //}

    //static public BrandModelsNamesDataSheet InitializeData()
    //{
    //    return new BrandModelsNamesDataSheet();
    //}

    //static public Depot InitializeDepot()
    //{
    //    return new CarRental.Models.Car.Depot();
    //}

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
