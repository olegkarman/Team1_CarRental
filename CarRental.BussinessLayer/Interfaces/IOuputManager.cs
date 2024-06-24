namespace CarRental.BussinessLayer.Interfaces
{
    public interface IOutputManager
    {
        public void PrintMessage(string message);
        public void PrintMessage(string format, params object?[]? args);
        public string GetUserPrompt();
        public void ClearUserUI();
        public void PrintList<T>(List<T> list);
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
        );
    }
}
