using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409050002)]

    public class InitialValuesReferential_202409050002 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
					IF NOT EXISTS 
					(
						SELECT ROUTINE_NAME
							FROM INFORMATION_SCHEMA.ROUTINES
							WHERE ROUTINE_NAME = 'GetCustomer'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetCustomer (@customerId NVARCHAR(100))
									AS
										SELECT Cars.CarId AS carCarId,
											  Cars.VinCode AS carVinCode,
											  Cars.NumberPlate AS carNumberPlate,
											  Cars.Brand AS carBrand,
											  Cars.Model AS carModel,
											  Cars.Price AS carPrice,
											  Cars.NumberOfSeats AS carNumberOfSeats,
											  Cars.NumberOfDoors AS carNumberOfDoors,
											  Cars.Mileage AS carMileage,
											  Cars.MaxFuelCapacity AS carMaxFuelCapacity,
											  Cars.CurrentFuel AS carCurrentFuel,
											  Cars.Year AS carYear,
											  Cars.IsFitForUse AS carIsFitForUse,
											  Cars.Engine AS carEngine,
											  Cars.Transmission AS carTransmission,
											  Cars.Interior AS carInterior,
											  Cars.Wheels AS carWheels,
											  Cars.Lights AS carLights,
											  Cars.Signal AS carSignal,
											  Cars.Color AS carColor,
											  TransportStatuses.Number AS carStatusId,
											  Users.IdNumber AS userIdNumber,
											  Users.FirstName AS userFirstName,
											  Users.LastName AS userLastName,
											  Users.DateOfBirth AS userDateOfBirth,
											  Users.UserName AS userUserName,
											  Users.Password AS userPassword,
											  Users.PassportNumber AS userPassportNumber,
											  Users.DrivingLicenseNumber AS userDrivingLicenseNumber,
											  Users.BasicDiscount AS userBasicDiscount,
											  Users.Category AS userCategory,
											  Deals.Id AS dealId,
											  Deals.CarId AS dealCarId,
											  Deals.VinCode AS dealVinCode,
											  Deals.CustomerId AS dealCustomerId,
											  Deals.Price AS dealPrice,
											  Deals.DealType dealDealType,
											  Deals.Name AS dealName,
											  Inspections.InspectionId AS inspectionInspectionId,
											  Inspections.CarId AS inspectionCarId,
											  Inspections.VinCode AS inspectionVinCode,
											  Inspections.InspectorId AS inspectionInspectorId,
											  Inspections.InspectionDate AS inspectionInspectionDate,
											  Inspections.StatusId AS inspectionStatusId,
											  Repairs.Id AS repairId,
											  Repairs.Date AS repairDate,
											  Repairs.CarId repairCarId,
											  Repairs.VinCode AS repairVinCode,
											  Repairs.MechanicId AS repairMechanicId,
											  Repairs.IsSuccessfull AS repairIsSuccessfull,
											  Repairs.TotalCost AS repairTotalCost,
											  Repairs.TechnicalInfo AS repairTechnicalInfo
										FROM Cars
										LEFT JOIN Users
											ON Cars.CustomerId = Users.IdNumber
										LEFT JOIN Deals
											ON Deals.CarId = Cars.CarId
										LEFT JOIN Inspections
											ON Inspections.CarId = Cars.CarId
										LEFT JOIN Repairs
											ON Repairs.CarId = Cars.CarId
										LEFT JOIN TransportStatuses
											ON Cars.StatusId = TransportStatuses.Number
										WHERE Cars.CustomerId = @customerId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetCustomer CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetCustomer ALREADY EXISTS';
                "
            );
        }

        public override void Down()
        {
            Execute.Sql
            (
                @"
					IF EXISTS
					(
						SELECT ROUTINE_NAME
							FROM INFORMATION_SCHEMA.ROUTINES
							WHERE ROUTINE_NAME = 'GetCustomer'
					)
						BEGIN
							DROP PROCEDURE GetCustomer;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetCustomer DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetCustomer IS NOT EXIST';
						END
                "
            );
        }
    }
}