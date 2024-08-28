using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BussinessLayer.DTOs
{
    public class SimpleCarDto
    {
        // PROPERTIES

        public string CarId { get; set; }
        public string VinCode { get; set; }
        public string NumberPlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
    }
}
