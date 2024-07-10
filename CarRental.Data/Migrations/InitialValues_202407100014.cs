using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100014)]

    public class InitialTables_202407100014 : Migration
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
                            FROM InspectionStatuses
                            WHERE Id = 1
                                OR Id = 2
                                OR Id = 3
                                OR Id = 4
                    )
                        BEGIN
                            SET IDENTITY_INSERT InspectionStatuses ON;

                            INSERT INTO InspectionStatuses
                            (
                                Number,
                                Status,
                                Id
                            )
                                VALUES
	                            (
                                    2,
                                    'Repair',
                                    1
	                            ),
	                            (
                                    1,
                                    'Successfully',
                                    2
	                            ),
	                            (
                                    0,
                                    'Unknown',
                                    3
	                            ),
                                (
                                    3,
                                    'Unusable',
                                    4
                                );

                                SET IDENTITY_INSERT InspectionStatuses OFF;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE InspectionStatuses';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN InspectionStatuses';
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
						FROM InspectionStatuses
                            WHERE Id = 1
                                OR Id = 2
                                OR Id = 3
                                OR Id = 4;
                "
            );
        }
    }
}