using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface IAgeValidation
    {
        public bool ValidateEmployeeYear(int year);
        public bool ValidateMonth(int month);
        public bool ValidateDay(int day);
    }
}
