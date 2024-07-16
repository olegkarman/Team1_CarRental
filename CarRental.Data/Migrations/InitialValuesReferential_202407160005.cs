using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407160005)]

    public class InitialValuesReferential_202407160005 : Migration
    {
        public override void Up()
        {
            //IF AT LEAST SOME OF DATA EXIST, WILL BE NO ANY INSERT.
            //NEED DELETE ALL DATA FIRST.
            Execute.Sql
            (
                @"
                     IF NOT EXISTS
                    (
                        SELECT ROUTINE_NAME
                            FROM INFORMATION_SCHEMA.ROUTINES
                            WHERE ROUTINE_NAME = 'CheckIfCustomerEntryExist';
                    )
                        BEGIN
                            CREATE PROCEDURE CheckIfCustomerEntryExist 
                            (
	                            @Id NVARCHAR(100)
                            )
	                            AS
		                            SELECT COUNT(IdNumber)
			                            FROM Users
			                            WHERE IdNumber = @Id;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCustomerEntryExist CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCustomerEntryExist ALREADY EXISTS';
                "
            );
        }

        public override void Down()
        {
            // FOR DELETE STATEMENT IS NOT NEED CKECK OF EXISTANCE OF DATA,
            // IT IS SCALAR WHICH RETURNS 0, OR NUMBER OF ROWS AFFECTED.
            Execute.Sql
            (
                @"
					IF EXISTS
					(
						SELECT ROUTINE_NAME
                            FROM INFORMATION_SCHEMA.ROUTINES
                            WHERE ROUTINE_NAME = 'CheckIfCustomerEntryExist';
					)
						BEGIN
							DROP PRUCEDURE CheckIfCustomerEntryExist;

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