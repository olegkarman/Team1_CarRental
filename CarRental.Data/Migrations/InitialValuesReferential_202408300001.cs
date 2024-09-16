using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202408300001)]

    public class InitialValuesReferential_202408300001 : Migration
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
							WHERE ROUTINE_NAME = 'CheckIfCarExist'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE CheckIfCarExist (@carId NVARCHAR(100))
									AS
										BEGIN
											DECLARE @isExist BIT

											IF EXISTS
											(
												SELECT CarId
													FROM Cars
													WHERE CarId = @carId
											)
												BEGIN
													SET @isExist = 1;
												END
											ELSE
												BEGIN
													SET @isExist = 0;
												END

											SELECT @isExist AS isExist;
										END
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCarExist CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCarExist ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'CheckIfCarExist'
					)
						BEGIN
							DROP PROCEDURE CheckIfCarExist;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCarExist DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCarExist IS NOT EXIST';
						END
                "
            );
        }
    }
}