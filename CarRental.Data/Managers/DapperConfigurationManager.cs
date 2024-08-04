using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data.Dapper;
using CarRental.Data.Models.Automobile;
using CarRental.Data.Models.Checkup;
using CarRental.Data.Models.RecordTypes;
using CarRental.Data.Models;
using Dapper;
using CarRental.Data.Models.Automobile.RecordTypes;

namespace CarRental.Data.Managers
{
    public class DapperConfigurationManager
    {
        // METHODS

        public void ConfigureGuidToStringMapping()
        {
            SqlMapper.AddTypeHandler(new GuidToStringTypeHandler());

            SqlMapper.RemoveTypeMap(typeof(Guid));
        }

        public void SetCustomMappingForEntities()
        {
            CustomPropertyTypeMap carMap = new CustomPropertyTypeMap(typeof(Car), PropertyInformation);
            CustomPropertyTypeMap customerMap = new CustomPropertyTypeMap(typeof(CustomerTemp), PropertyInformation);
            CustomPropertyTypeMap dealMap = new CustomPropertyTypeMap(typeof(Deal), PropertyInformation);
            CustomPropertyTypeMap inspectionMap = new CustomPropertyTypeMap(typeof(Inspection), PropertyInformation);
            CustomPropertyTypeMap repairMap = new CustomPropertyTypeMap(typeof(Repair), PropertyInformation);
            CustomPropertyTypeMap mechanicMap = new CustomPropertyTypeMap(typeof(Mechanic), PropertyInformation);

            SqlMapper.SetTypeMap(typeof(Car), carMap);
            SqlMapper.SetTypeMap(typeof(CustomerTemp), customerMap);
            SqlMapper.SetTypeMap(typeof(Deal), dealMap);
            SqlMapper.SetTypeMap(typeof(Inspection), inspectionMap);
            SqlMapper.SetTypeMap(typeof(Repair), repairMap);
            SqlMapper.SetTypeMap(typeof(Mechanic), mechanicMap);
        }

        public static PropertyInfo PropertyInformation(Type type, string attribName)
        {
            // BECAUSE THE METHOD IS STRONGLY TYPED, I CANNOT MOVE IT IN FROM THE OUTSIDE.
            Dictionary<string, string> columnProperties = new Dictionary<string, string>
        {
            { "carCarId", "CarId" },
            { "carVinCode", "VinCode" },
            { "carNumberPlate", "NumberPlate" },
            { "carBrand", "Brand" },
            { "carModel", "Model" },
            { "carPrice", "Price" },
            { "carNumberOfSeats", "NumberOfSeats" },
            { "carNumberOfDoors", "NumberOfDoors" },
            { "carMileage", "Mileage" },
            { "carMaxFuelCapacity", "MaxFuelCapacity" },
            { "carCurrentFuel", "CurrentFuel" },
            { "carYear", "Year" },
            { "carIsFitForUse", "IsFitForUse" },
            { "carEngine", "Engine" },
            { "carTransmission", "Transmission" },
            { "carInterior", "Interior" },
            { "carWheels", "Wheels" },
            { "carLights", "Lights" },
            { "carSignal", "Signal" },
            { "carColor", "Color" },
            { "carStatusId", "Status" },
            { "userIdNumber", "IdNumber" },
            { "userFirstName", "FirstName" },
            { "userLastName", "LastName" },
            { "userDateOfBirth", "DateOfBirth" },
            { "userUserName", "UserName" },
            { "userPassword", "Password" },
            { "userPassportNumber", "PassportNumber" },
            { "userDrivingLicenseNumber", "DrivingLicenseNumber" },
            { "userBasicDiscount", "BasicDiscount" },
            { "userCategory", "Category" },
            { "dealId", "Id" },
            { "dealCarId", "CarId" },
            { "dealVinCode", "VinCode" },
            { "dealCustomerId", "CustomerId" },
            { "dealPrice", "Price" },
            { "dealDealType", "DealType" },
            { "dealName", "Name" },
            { "inspectionInspectionId", "InspectionId" },
            { "inspectionCarId", "CarId" },
            { "inspectionInspectorId", "InspectorId" },
            { "inspectionInspectionDate", "InspectionDate" },
            { "inspectionStatusId", "Result" },
            { "repairId", "Id" },
            { "repairDate", "Date" },
            { "repairCarId", "CarId" },
            { "repairMechanicId", "MechanicId" },
            { "repairIsSuccessfull", "IsSuccessfull" },
            { "repairTotalCost", "TotalCost" },
            { "repairTechnicalInfo", "TechnicalInfo" },
            { "mechanId", "Id" },
            { "mechanName", "Name" },
            { "mechanSurename", "Surename" },
            { "mechanYear", "Year" }
        };

            if (columnProperties.ContainsKey(attribName))
            {
                return type.GetProperty(columnProperties[attribName]);
            }

            return type.GetProperty(attribName);
        }
    }
}
