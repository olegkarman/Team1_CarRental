using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Managers
{
    public class BrandManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        public List<Brand> Brands { get; set; }

        // CONSTRUCTORS

        public BrandManager()
        {
            Brands = new List<Brand>();
        }

        // METHODS

        // CREATE

        public Brand GetNewBrand(Guid id, string name, string[] models)
        {
            Brand brand = new Brand
            {
                Id = id,
                BrandName = name,
                Models = models
            };

            return brand;
        }

        // RETRIVE

        public Brand GetBrandFromList(List<Brand> brands, int index)
        {
            Brand brand = brands[index];

            return brand;
        }

        public Brand GetBrandFromList(List<Brand> brands, Guid id)
        {
            Brand brand = brands.Find(x => x.Id.CompareTo(id) == 0);

            return brand;
        }

        public string ShowBrandInfo(Brand brand)
        {
            StringBuilder modelsBuilder = new StringBuilder();

            foreach(string model in brand.Models)
            {
                modelsBuilder.Append(model);
                modelsBuilder.Append(" | ");
            }

            return brand.ToString() + " " + modelsBuilder.ToString();
        }

        // UPDATE

        public void AddBrandInToList(List<Brand> brands, Brand brand)
        {
            brands.Add(brand);
        }

        // DELETE
    }
}
