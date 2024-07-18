using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100012)]

    public class InitialValues_202407100012 : Migration
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
                        SELECT Id
                            FROM Inspector
                            WHERE Id = 1
                                OR Id = 2
                                OR Id = 3
                    )
                        BEGIN
                            INSERT INTO Inspector
                            (
                                Id,
                                FirstName,
                                LastName,
                                DateOfBirth
                            )
                                VALUES
	                            (
                                    1,
                                    'Adam',
                                    'Smith',
                                    CAST('1990-01-01' AS Date)
	                            ),
	                            (
                                    2,
                                    'Eva',
                                    'Smith',
                                    CAST('1991-01-02' AS Date)
	                            ),
	                            (
                                    3,
                                    'Mike',
                                    'Smith',
                                    CAST('1992-01-03' AS Date)
	                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Inspector';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Inspector';
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
					DELETE
						FROM Inspector
                            WHERE Id = 1
                                OR Id = 2
                                OR Id = 3;
                "
            );
        }
    }
}