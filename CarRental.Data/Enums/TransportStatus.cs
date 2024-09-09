namespace CarRental.Data.Enums;

public enum TransportStatus : byte
{
    Unknown = 0,
    Available = 1,
    Rented = 2,
    Sold = 3,
    InRepair = 4,
    Unavailable = 200
}
