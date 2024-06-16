using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Services
{
    public class TextProcessingService
    {
        // FIELDS

        // PROPERTIES

        // CONSTRUCTORS

        // METHODS

        public string ReplaceSpacesByEmpty(string inputString)
        {
            return Regex.Replace(inputString, @"\s+", string.Empty);
        }
    }
}
