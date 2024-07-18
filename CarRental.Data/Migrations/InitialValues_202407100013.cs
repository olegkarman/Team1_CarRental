using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100013)]

    public class InitialValues_202407100013 : Migration
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
                            FROM TransportStatuses
                            WHERE Id = 1
                                OR Id = 2
                                OR Id = 3
                                OR Id = 4
                                OR Id = 5
                                OR Id = 6
                    )
                        BEGIN
                            SET IDENTITY_INSERT TransportStatuses ON;

                            INSERT INTO TransportStatuses
                            (
                                Number,
                                Status,
                                Id
                            )
                                VALUES
	                            (
                                    1,
                                    'Available',
                                    1
	                            ),
	                            (
                                    4,
                                    'InRepair',
                                    2
	                            ),
	                            (
                                    2,
                                    'Rented',
                                    3
	                            ),
                                (
                                    3,
                                    'Sold',
                                    4
                                ),
                                (
                                    200,
                                    'Unavailable',
                                    5
                                ),
                                (
                                    0,
                                    'Unknown',
                                    6
                                );

                                SET IDENTITY_INSERT TransportStatuses OFF;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE TransportStatuses';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN TransportStatuses';
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
						FROM TransportStatuses
                            WHERE Id = 1
                                OR Id = 2
                                OR Id = 3
                                OR Id = 4
                                OR Id = 5
                                OR Id = 6;
                "
            );
        }
    }
}