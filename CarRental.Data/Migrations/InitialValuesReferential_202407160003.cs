using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407160003)]

    public class InitialValuesReferential_202407160003 : Migration
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
                            WHERE ROUTINE_NAME = 'CheckIfCarEntryExist';
                    )
                        BEGIN
                            CREATE PROCEDURE CheckIfCarEntryExist 
                            (
	                            @Id NVARCHAR(100)
                            )
	                            AS
		                            SELECT COUNT(CarId)
			                            FROM Cars
			                            WHERE CarId = @Id;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCarEntryExist CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCarEntryExist ALREADY EXISTS';
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
                            WHERE ROUTINE_NAME = 'CheckIfCarEntryExist';
					)
						BEGIN
							DROP PRUCEDURE CheckIfCarEntryExist;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCarEntryExist DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCarEntryExist IS NOT EXIST';
						END
                "
            );
        }
    }
}