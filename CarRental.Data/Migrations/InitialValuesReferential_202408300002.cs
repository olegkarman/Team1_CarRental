using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202408300002)]

    public class InitialValuesReferential_202408300002 : Migration
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
							WHERE ROUTINE_NAME = 'DeleteSimpleCar'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE DeleteSimpleCar (@carId NVARCHAR(100))
									AS
										BEGIN
											DELETE
												FROM Repairs
												WHERE CarId = @carId;

											DELETE
												FROM Inspections
												WHERE CarId = @carId;
			
											DELETE
												FROM Cars
												WHERE CarId = @carId;
										END
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE DeleteSimpleCar CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME DeleteSimpleCar ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'DeleteSimpleCar'
					)
						BEGIN
							DROP PROCEDURE DeleteSimpleCar;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE DeleteSimpleCar DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME DeleteSimpleCar IS NOT EXIST';
						END
                "
            );
        }
    }
}