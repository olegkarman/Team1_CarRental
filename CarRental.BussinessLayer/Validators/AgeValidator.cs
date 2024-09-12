using CarRental.BussinessLayer.Interfaces;

namespace CarRental.BussinessLayer.Validators
{
    public class AgeValidator : IAgeValidation
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

        public bool ValidateMonth(int month)
        {
            // VALIDATION LOGIC.

            throw new NotImplementedException();
        }

        public bool ValidateDay(int day)
        {
            // VALIDATION LOGIC.

            throw new NotImplementedException();
        }
    }
}
