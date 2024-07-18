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
            Execute.Sql
            (
                @"
                     IF NOT EXISTS
                    (
                        SELECT ROUTINE_NAME
                            FROM INFORMATION_SCHEMA.ROUTINES
                            WHERE ROUTINE_NAME = 'CheckIfCarEntryExist'
                    )
                        BEGIN
                            EXECUTE
                            ('
                                CREATE PROCEDURE CheckIfCarEntryExist 
                                (
	                                @Id NVARCHAR(100)
                                )
	                                AS
		                                SELECT COUNT(CarId)
			                                FROM Cars
			                                WHERE CarId = @Id;
                            ');

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CheckIfCarEntryExist CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CheckIfCarEntryExist ALREADY EXISTS';
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
                            WHERE ROUTINE_NAME = 'CheckIfCarEntryExist'
					)
						BEGIN
							DROP PROCEDURE CheckIfCarEntryExist;

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