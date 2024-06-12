namespace CarRental.BussinessLayer.Interfaces
{
    public interface IOutputManager
    {
        public void PrintMessage(string message);
        public void PrintMessage(string format, params object?[]? args);
        public string GetUserPrompt();
        public void ClearUserUI();
        public void PrintList<T>(List<T> list);
    }
}
