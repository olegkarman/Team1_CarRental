using CarHubTest;
using CarRental.Models.Car;

namespace CarRental.Models.Portal;
public class Portal
{
    public User UserData { get; set; }
    public bool IsCustomer { get; set; }
    public ServiceManager CarServiceManager;
    public InspectorCars InspectorCars;

    public Portal(User userData, bool isCustomer)
    {
        UserData = userData;
        IsCustomer = isCustomer;
        CarServiceManager = new ServiceManager();
        InspectorCars = new InspectorCars();
    }
}
