﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Models.Automobile.RecordTypes;
using CarRental.BussinessLayer.Validators;
using System.Xml.Linq;

namespace CarRental.BussinessLayer.Managers
{
    public class BrandManager
    {
        // FIELDS

        private const string _noInfo = "NO INFORMATION";

        // PROPERTIES

        internal BrandValidation Validator { get; init; }
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
            Validator.CheckNull(name);
            Validator.CheckNull(id);
            Validator.CheckNull(models);

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
            Validator.CheckNull(brands);
            IndexValidator.ValidateIndexOfList(brands, index);

            Brand brand = brands[index];

            Validator.CheckNull(brand);

            return brand;
        }

        public Brand GetBrandFromList(List<Brand> brands, Guid id)
        {
            Validator.CheckNull(brands);

            Brand brand = brands.Find(x => x.Id.CompareTo(id) == 0);

            Validator.CheckNull(brand);

            return brand;
        }

        public string ShowBrandInfo(Brand brand)
        {
            Validator.CheckNull(brand);
            Validator.CheckNull(brand.Models);

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
            Validator.CheckNull(brands);
            Validator.CheckNull(brand);

            brands.Add(brand);
        }

        // DELETE

        public void DeleteBrandFromList(List<Brand> brands, int index)
        {
            Validator.CheckNull(brands);
            IndexValidator.ValidateIndexOfList(brands, index);

            brands.RemoveAt(index);
        }

        public void DeleteBrandFromList(List<Brand> brands, Guid guid)
        {
            Validator.CheckNull(brands);
            Validator.CheckNull(guid);

            brands.RemoveAt(brands.IndexOf(brands.Find(x => x.Id.CompareTo(guid) == 0)));
        }
    }
}
