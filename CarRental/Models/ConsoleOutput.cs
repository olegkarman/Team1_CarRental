using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
