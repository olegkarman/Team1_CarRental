using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409160001)]

    public class InitialValuesReferential_202409160001 : Migration
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
							WHERE ROUTINE_NAME = 'GetCredentialsOfCustomer'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetCredentialsOfCustomer (@customerId NVARCHAR(100))
								AS
									SELECT UserName, Password
										FROM Users
										WHERE IdNumber = @customerId
											AND Category = 'Customer';
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetCredentialsOfCustomer CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetCredentialsOfCustomer ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetCredentialsOfCustomer'
					)
						BEGIN
							DROP PROCEDURE GetCredentialsOfCustomer;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetCredentialsOfCustomer DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetCredentialsOfCustomer IS NOT EXIST';
						END
                "
            );
        }
    }
}