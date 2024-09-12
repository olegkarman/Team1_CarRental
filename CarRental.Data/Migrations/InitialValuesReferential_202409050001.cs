using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409050001)]

    public class InitialValuesReferential_202409050001 : Migration
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
							WHERE ROUTINE_NAME = 'GetSimpleCustomer'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetSimpleCustomer (@idNumber NVARCHAR(100), @category NVARCHAR(50))
								AS
									SELECT IdNumber,
											FirstName,
											LastName,
											DateOfBirth,
											Password,
											UserName,
											BasicDiscount,
											PassportNumber,
											DrivingLicenseNumber,
											Category
									FROM Users
									WHERE IdNumber = @idNumber
										AND Category = @category;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetSimpleCustomer CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetSimpleCustomer ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetSimpleCustomer'
					)
						BEGIN
							DROP PROCEDURE GetSimpleCustomer;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetSimpleCustomer DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetSimpleCustomer IS NOT EXIST';
						END
                "
            );
        }
    }
}