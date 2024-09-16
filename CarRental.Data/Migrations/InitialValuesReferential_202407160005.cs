using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407160005)]

    public class InitialValuesReferential_202407160005 : Migration
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
                            WHERE ROUTINE_NAME = 'CheckIfCustomerEntryExist'
                    )
                        BEGIN
                            EXECUTE
                            ('
                                CREATE PROCEDURE CheckIfCustomerEntryExist 
                                (
	                                @Id NVARCHAR(100)
                                )
	                                AS
		                                SELECT COUNT(IdNumber)
			                                FROM Users
			                                WHERE IdNumber = @Id;
                            ');

                          PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCustomerEntryExist CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCustomerEntryExist ALREADY EXISTS';
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
                            WHERE ROUTINE_NAME = 'CheckIfCustomerEntryExist'
					)
						BEGIN
							DROP PROCEDURE CheckIfCustomerEntryExist;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCustomerEntryExist DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCustomerEntryExist IS NOT EXIST';
						END
                "
            );
        }
    }
}