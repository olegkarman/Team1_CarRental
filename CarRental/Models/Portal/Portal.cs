namespace CarRental.Models.Portal;
public class Portal
{
    public User UserData { get; set; }
    public bool IsCustomer { get; set; }
    private DealManager _dealManager;

    public Portal(User userData, bool isCustomer) {
        UserData = userData;
        IsCustomer = isCustomer;
        _dealManager = new DealManager();
    }

    public void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine($"Welcome {UserData.FirstName}");
            Console.WriteLine();
            Console.WriteLine("Select your next move");
            Console.WriteLine();
            Console.WriteLine("1. Show the list of cars");
            if (IsCustomer)
            {
                Console.WriteLine("2. Buy a car");
                Console.WriteLine("3. Rent a car");
                Console.WriteLine("4. Check your deals");
                Console.WriteLine("5. Exit");
            } else
            {
                Console.WriteLine("2. Inspect a car");
                Console.WriteLine("3. Check your inspections");
                Console.WriteLine("4. Exit");
            }
            Console.WriteLine();
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();
            Console.WriteLine();

            break;
        }
    }
}
