using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100014)]

    public class InitialValues_202407100014 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
                    IF NOT EXISTS
                    (
                        SELECT Number
                            FROM InspectionStatuses
                            WHERE Number = 0
                                OR Number = 1
                                OR Number = 2
                                OR Number = 3
                    )
                        BEGIN
                            INSERT INTO InspectionStatuses
                            (
                                Number,
                                Status
                                --Id
                            )
                                VALUES
	                            (
                                    2,
                                    'Repair'
	                            ),
	                            (
                                    1,
                                    'Successfully'
	                            ),
	                            (
                                    0,
                                    'Unknown'
	                            ),
                                (
                                    3,
                                    'Unusable'
                                );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE InspectionStatuses';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN InspectionStatuses';
                "
            );
        }

        public override void Down()
        {
            Execute.Sql
            (
                @"
					DELETE
						FROM InspectionStatuses
                            WHERE Number = 0
                                OR Number = 1
                                OR Number = 2
                                OR Number = 3;
                "
            );

            //       Execute.Sql
            //       (
            //           @"
            //DELETE
            //	FROM InspectionStatuses
            //                       WHERE Id = 1
            //                           OR Id = 2
            //                           OR Id = 3
            //                           OR Id = 4;
            //           "
            //       );
        }
    }
}