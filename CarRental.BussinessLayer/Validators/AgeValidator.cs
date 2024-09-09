namespace CarRental.BussinessLayer.Validators
{
    public class AgeValidator
    {
        // METHODS

        public bool ValidateEmployeeYear(int year)
        {
            if ((year < 6) || (year > 105))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // // ADD VALIDATE BIRTH MONTH, BIRTH DATE.
    }
}
