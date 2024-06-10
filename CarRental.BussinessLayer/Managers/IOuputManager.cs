namespace CarRental.BussinessLayer.Interfaces
{
    public interface IOutputManager
    {
        public void PrintMessage(string message);
        public string GetUserPrompt();
    }
}
