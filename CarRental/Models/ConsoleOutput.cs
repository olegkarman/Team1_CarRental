using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CarRental.BussinessLayer.Interfaces;

namespace CarRental.Presentation.Models;
public class ConsoleOutput : IOutputManager
{
    public void PrintMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintMessage(string format, params object?[]? args)
    {
        Console.WriteLine(format, args);
    }

    // I THINK THIS METHOD SHOULD BE HERE, DUE TO IT WORKS DIRECTLY WITH THE CONSOLE.
    // AND ALSO WE NO NEED TO LEFT LOGIC ABOUT STRING FORMAT IN THE SO-CALLED 'BUSSINESS-LAYER'.

    public void PrintCarsInfoOfCustomerInTable
    (
        string carsInfoInput,
        string delimiterToSplit,
        string patternInitialTrim,
        string textToDeleteFirst,
        string textToDeleteSecond,
        string brandMatch,
        string modelMatch,
        string numberPlateMatch,
        string colourMatch,
        string yearMatch,
        string statusMainMatch,
        string statusSecondaryMatch
    )
    {
        Regex regex = new Regex(delimiterToSplit);

        int counter = regex.Count(carsInfoInput);

        string[] carsInfo = carsInfoInput.Split(delimiterToSplit);

        string tempInfo;
        string brand;
        string model;
        string numberPlate;
        string year;
        string isFitForUse;
        string colour;
        string status;

        // HOW TO SEND ON THE PLACE OF NUMBER 17 PARAMETER SOME VARIABLE???
        Console.WriteLine("{0, -13}|{1, -15}|{2, -15}|{3, -15}|{4, -10}|{5, -10}|{6,-5}", "BRAND", "MODEL", "NUMBERPLATE", "COLOUR", "YEAR", "STATUS", "IS READY");
        Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————————————————");

        foreach (string carInfo in carsInfo)
        {
            if (string.IsNullOrEmpty(carInfo))
            {
                continue;
            }
            else
            {
                tempInfo = carInfo;     // STRING-INSTANCE HAVE CLONEABLE BEHAVIOR, NOT JUST TO REASSIGN THE REFERENCE.

                tempInfo = Regex.Match(carInfo, patternInitialTrim).Value;  // STATIC, NO GC ADDITIONAL WORK.

                carsInfoInput = tempInfo.Replace(textToDeleteFirst, string.Empty); // TRIM WILL NOT WORK.

                tempInfo = tempInfo.Replace(textToDeleteSecond, string.Empty);

                // BRIEF EXPLANATION:
                // (?<=Brand) — SO-CALLED POSITIVE LOOKBEHIND, MAKE START POINT AFTER FIRST OCCURENCE OF 'Brand'
                // (.*?) — MATCHING EVERYTHING INCLUDE THE FIRST OCCURENT OF THE NEXT EXPRESSION.
                // (?=\|) — SO-CALLED POSITIVE LOOKAHEAD, MAKE START POINT RIGHT BEFORE '|' CHARACTER.

                brand = Regex.Match(tempInfo, brandMatch).Value;

                model = Regex.Match(tempInfo, modelMatch).Value;

                numberPlate = Regex.Match(tempInfo, numberPlateMatch).Value;

                colour = Regex.Match(tempInfo, colourMatch).Value;

                year = Regex.Match(tempInfo, yearMatch).Value;

                status = Regex.Match(tempInfo, statusMainMatch).Value;

                isFitForUse = Regex.Match(tempInfo, statusSecondaryMatch).Value;

                Console.WriteLine("{0, -13}|{1, -15}|{2, -15}|{3, -15}|{4, -10}|{5, -10}|{6,-5}", brand, model, numberPlate, colour, year, status, isFitForUse);
                Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————————————————");
            }
        }
    }

    public string GetUserPrompt()
    {
        return Console.ReadLine();
    }

    public void ClearUserUI()
    {
        Console.Clear();
    }
    public void PrintList<T>(List<T> list)
    {
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }
}
