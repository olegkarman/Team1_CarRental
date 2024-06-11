namespace CarRental.BussinessLayer.Managers
{
    public interface IOutputManager
    {
        public void PrintMessage(string message);
        public string GetUserPrompt();
        public void ClearUserUI();
    }
}
