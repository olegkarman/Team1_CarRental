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

    public void PrintCarsInfoOfCustomerInTable
    (
        string carsInfoInput,
        string delimiterToSplit,
        string patternInitialTrim,
        string textToDeleteFirst,
        string textToDeleteSecond,
        string brandMatch,
        string modelMatch,
        string colourMatch,
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
        string isFitForUse;
        string colour;
        string status;

        // HOW TO SEND ON THE PLACE OF NUMBER 17 PARAMETER SOME VARIABLE???
        Console.WriteLine("{0, 17}|{1, 17}|{2, 17}|{3, 17}|{4, 17}", "BRAND", "MODEL", "COLOUR", "STATUS", "IS READY");

        foreach (string carInfo in carsInfo)
        {
            tempInfo = carInfo;     // STRING-INSTANCE HAVE CLONEABLE BEHAVIOR, NOT JUST TO REASSIGN THE REFERENCE.

            tempInfo = Regex.Match(carInfo, patternInitialTrim).Value;

            carsInfoInput = tempInfo.Replace(textToDeleteFirst, string.Empty); // TRIM WILL NOT WORK.

            tempInfo = tempInfo.Replace(textToDeleteSecond, string.Empty);

            // BRIEF EXPLANATION:
            // (?<=Brand) — SO-CALLED POSITIVE LOOKBEHIND, MAKE START POINT AFTER FIRST OCCURENCE OF 'Brand'
            // (.*?) — MATCHING EVERYTHING INCLUDE THE FIRST OCCURENT OF THE NEXT EXPRESSION.
            // (?=\|) — SO-CALLED POSITIVE LOOKAHEAD, MAKE START POINT RIGHT BEFORE '|' CHARACTER.

            brand = Regex.Match(tempInfo, brandMatch).Value;

            model = Regex.Match(tempInfo, modelMatch).Value;

            colour = Regex.Match(tempInfo, colourMatch).Value;

            status = Regex.Match(tempInfo, statusMainMatch).Value;

            isFitForUse = Regex.Match(tempInfo, statusSecondaryMatch).Value;

            Console.WriteLine("{0, 17}|{1, 17}|{2, 17}|{3, 17}|{4, 17}", brand, model, colour, status, isFitForUse);

            Console.WriteLine("—————————————————————————————————————————————————————————————————————————————————————");
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
