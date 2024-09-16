using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409160003)]

    public class InitialValuesReferential_202409160003 : Migration
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
							WHERE ROUTINE_NAME = 'GetBuyCar'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetBuyCar (@carId NVARCHAR(100))
								AS
									SELECT CarId,
											VinCode,
											CustomerId,
											NumberPlate,
											Brand,
											Model,
											Price,
											NumberOfSeats,
											NumberOfDoors,
											Mileage,
											MaxFuelCapacity,
											CurrentFuel,
											Year,
											IsFitForUse,
											Engine,
											Transmission,
											Interior,
											Wheels,
											Lights,
											Signal,
											Color,
											DealId,
											StatusId
										FROM Cars
										WHERE CarId = @carId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetBuyCar CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetBuyCar ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetBuyCar'
					)
						BEGIN
							DROP PROCEDURE GetBuyCar;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetBuyCar DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetBuyCar IS NOT EXIST';
						END
                "
            );
        }
    }
}