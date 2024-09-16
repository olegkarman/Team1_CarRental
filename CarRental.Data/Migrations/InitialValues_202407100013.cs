using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100013)]

    public class InitialValues_202407100013 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
                    IF NOT EXISTS
                    (
                        SELECT Number
                            FROM TransportStatuses
                            WHERE Number = 0
                                OR Number = 1
                                OR Number = 2
                                OR Number = 3
                                OR Number = 4
                                OR Number = 200
                    )
                        BEGIN
                            INSERT INTO TransportStatuses
                            (
                                Number,
                                Status
                                --Id
                            )
                                VALUES
	                            (
                                    1,
                                    'Available'
	                            ),
	                            (
                                    4,
                                    'InRepair'
	                            ),
	                            (
                                    2,
                                    'Rented'
	                            ),
                                (
                                    3,
                                    'Sold'
                                ),
                                (
                                    200,
                                    'Unavailable'
                                ),
                                (
                                    0,
                                    'Unknown'
                                );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE TransportStatuses';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN TransportStatuses';
                "
            );
        }

        public override void Down()
        {
            Execute.Sql
            (
                @"
					DELETE
						FROM TransportStatuses
                            WHERE Number = 0
                                OR Number = 1
                                OR Number = 2
                                OR Number = 3
                                OR Number = 4
                                OR Number = 200;
                "
            );

            //       Execute.Sql
            //       (
            //           @"
            //DELETE
            //	FROM TransportStatuses
            //                       WHERE Id = 1
            //                           OR Id = 2
            //                           OR Id = 3
            //                           OR Id = 4
            //                           OR Id = 5
            //                           OR Id = 6;
            //           "
            //       );
        }
    }
}