﻿namespace CarRental.Data.Models.Gateway;
public class Portal
{
    public User UserData { get; set; }
    public bool IsCustomer { get; set; }

    public Portal(User userData, bool isCustomer)
    {
        UserData = userData;
        IsCustomer = isCustomer;
    }
}
