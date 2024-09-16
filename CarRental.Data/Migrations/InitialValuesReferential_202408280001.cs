using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202408280001)]

    public class InitialValuesReferential_202408280001 : Migration
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
							WHERE ROUTINE_NAME = 'GetSimpleCar'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetSimpleCar (@carId NVARCHAR(100))
									AS
										SELECT CarId,
												VinCode,
												NumberPlate,
												Brand,
												Model,
												Price
											FROM Cars
											WHERE CarId = @carId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetSimpleCar CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetSimpleCar ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetSimpleCar'
					)
						BEGIN
							DROP PROCEDURE GetSimpleCar;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetSimpleCar DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetSimpleCar IS NOT EXIST';
						END
                "
            );
        }
    }
}