using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.BussinessLayer.DTOs;

namespace CarRental.BussinessLayer.Interfaces
{
    public interface ICharMaps
    {
        internal List<char[]> CharMaps { get; init; }

        public void InitializeCharMap(List<char[]> charMap);

        public List<char[]> CreateCustomeCharMap(char[] chars);
    }
}
