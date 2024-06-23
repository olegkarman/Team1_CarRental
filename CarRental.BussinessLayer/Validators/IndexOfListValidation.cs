﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models;
using CarRental.Data.Models.Car;

namespace CarRental.BussinessLayer.Validators
{
    public class IndexOfListValidation
    {
        // METHODS

        public void ValidateIndexOfList(List<Mechanic> mechanics, int index)
        {
            if ((index < 0) || (index >= mechanics.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void ValidateIndexOfList(List<Car> cars, int index)
        {
            if ((index < 0) || (index >= cars.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void ValidateIndexOfList(List<Repair> repairs, int index)
        {
            if ((index < 0) || (index >= repairs.Count))
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}