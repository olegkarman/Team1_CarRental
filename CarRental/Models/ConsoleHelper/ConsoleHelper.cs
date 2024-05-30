namespace CarRental.Models.ConsoleHelper;
public static class ConsoleHelper
{
    public static void ApplyConsoleStyles()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Title = "Car portal";
    }

    public static void ClearConsoleWithDelay(int delay)
    {
        Task.Delay(TimeSpan.FromSeconds(delay)).Wait();
        Console.Clear();
    }
}
