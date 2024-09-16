using System.Text;
using CarRental.BussinessLayer.Validators;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.BussinessLayer.Managers
{
    public class BrandManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        internal NullValidation NullValidator { get; init; }
        internal IndexOfListValidation IndexValidator { get; init; }

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
            NullValidator.CheckNull(name);
            NullValidator.CheckNull(id);
            NullValidator.CheckNull(models);

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
            NullValidator.CheckNull(brands);
            IndexValidator.ValidateIndexOfList(brands, index);

            Brand brand = brands[index];

            NullValidator.CheckNull(brand);

            return brand;
        }

        public Brand GetBrandFromList(List<Brand> brands, Guid id)
        {
            NullValidator.CheckNull(brands);

            Brand brand = brands.Find(x => x.Id.CompareTo(id) == 0);

            NullValidator.CheckNull(brand);

            return brand;
        }

        public string ShowBrandInfo(Brand brand)
        {
            NullValidator.CheckNull(brand);
            NullValidator.CheckNull(brand.Models);

            StringBuilder modelsBuilder = new StringBuilder();

            foreach (string model in brand.Models)
            {
                modelsBuilder.Append(model);
                modelsBuilder.Append(" | ");
            }

            return brand.ToString() + " " + modelsBuilder.ToString();
        }

        // UPDATE

        public void AddBrandInToList(List<Brand> brands, Brand brand)
        {
            NullValidator.CheckNull(brands);
            NullValidator.CheckNull(brand);

            brands.Add(brand);
        }

        // DELETE

        public void DeleteBrandFromList(List<Brand> brands, int index)
        {
            NullValidator.CheckNull(brands);
            IndexValidator.ValidateIndexOfList(brands, index);

            brands.RemoveAt(index);
        }

        public void DeleteBrandFromList(List<Brand> brands, Guid guid)
        {
            NullValidator.CheckNull(brands);
            NullValidator.CheckNull(guid);

            brands.RemoveAt(brands.IndexOf(brands.Find(x => x.Id.CompareTo(guid) == 0)));
        }
    }
}
