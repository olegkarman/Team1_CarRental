using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.Services
{
    public class TextProcessingService
    {
        // THE FIELDS, NOT PROPERTIES. NOT PROPERTIES... MICROSOFT NAMING CONVENCTION USED.

        private readonly string _carInfoBulkPattern;
        private readonly string _carInfoBulkPatternAdditional;
        private readonly string _patternGuid;
        private readonly string _patternIsFitForUse;
        private readonly string _patternStatus;

        // PROPERTIES

        private Regex Regular { get; set; }

        // CONSTRUCTORS

        public TextProcessingService()
        {
            _carInfoBulkPattern = @"Brand|Model|Year|Engine|Transmission|Wheels|Interior|Lights|Signal|NumberOfDoors|NumberOfSeats|Color|VinCode|Price|CarId|NumberPlate|Owner|Engagement|\s|=|{";
            _carInfoBulkPatternAdditional = @"IsFitForUse|Status";
            _patternGuid = @"\w{8}-\w{4}-\w{4}-\w{4}-\w{12}";
            _patternIsFitForUse = @"(?<=IsFitForUse)(.*?)(?=\|)";
            _patternStatus = @"(?<=Status)(.*?)(?=\|)";
            Regular = new Regex(_carInfoBulkPattern);
        }

        // CONSTRUCTORS

        // METHODS

        public string ReplaceSpacesByEmpty(string inputString)
        {
            return Regex.Replace(inputString, @"\s+", string.Empty);
        }

        public string ParseOutputCarsInfo(string carsInfo)
        {
            StringBuilder builder = new StringBuilder();
            
            carsInfo = Regular.Replace(carsInfo, String.Empty);
            carsInfo = Regex.Replace(carsInfo, @"\|\|\|", String.Empty);

            string[] infoCars = carsInfo.Split(@"}");

            for (int index = 0; index < infoCars.Length; index = index + 1)
            {
                if (String.IsNullOrEmpty(infoCars[index]))
                {
                    continue;
                }
                else
                {
                    infoCars[index] = ParseOutputCarInfo(infoCars[index]);
                    
                    builder.Append(infoCars[index]);
                    builder.Append(@"}");
                }
            }

            return builder.ToString();
        }

        public string ParseOutputCarInfo(string carInfo)
        {
            string isFitForUse;
            string status;

            isFitForUse = Regex.Match(carInfo, _patternIsFitForUse).Value;

            if (isFitForUse == "True")
            {
                carInfo = Regex.Replace(carInfo, isFitForUse, "1");
            }
            else if (isFitForUse == "False")
            {
                carInfo = Regex.Replace(carInfo, isFitForUse, "0");
            }
            else
            {
                carInfo = Regex.Replace(carInfo, isFitForUse, String.Empty);
            }

            status = Regex.Match(carInfo, _patternStatus).Value;

            switch (status)
            {
                case "Available":
                    carInfo = Regex.Replace(carInfo, status, "1");
                    break;
                case "InRepair":
                    carInfo = Regex.Replace(carInfo, status, "4");
                    break;
                case "Rented":
                    carInfo = Regex.Replace(carInfo, status, "2");
                    break;
                case "Sold":
                    carInfo = Regex.Replace(carInfo, status, "3");
                    break;
                case "Unavailable":
                    carInfo = Regex.Replace(carInfo, status, "200");
                    break;
                case "Unknown":
                    carInfo = Regex.Replace(carInfo, status, "0");
                    break;
            }
            carInfo = Regex.Replace(carInfo, _carInfoBulkPatternAdditional, String.Empty);

            string guidUp = Regex.Match(carInfo, _patternGuid).Value.ToUpper();

            carInfo = Regex.Replace(carInfo, _patternGuid, guidUp);

            return carInfo;
        }
    }
}
