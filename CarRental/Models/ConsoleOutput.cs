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

    public string GetUserPrompt()
    {
        return Console.ReadLine();
    }
}
