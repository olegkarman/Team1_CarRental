using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407090002)]

    public class InitialTables_202407090002 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
                    IF NOT EXISTS
                    (
                        SELECT TABLE_NAME
                            FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_NAME = 'TransportStatuses'
                    )
                        BEGIN
                            CREATE TABLE TransportStatuses
                            (
                                Number INT NOT NULL,
                                CONSTRAINT PK_TransportStatuses_Number
                                    PRIMARY KEY (Number),
                                Status NVARCHAR(50) NOT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE TransportStatuses CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE TransportStatuses IS ALREADY EXIST';
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
                        SELECT TABLE_NAME
                            FROM INFORMATION_SCHEMA.TABLES
                            WHERE TABLE_NAME = 'TransportStatuses'
                    )
                        BEGIN
                            DROP TABLE TransportStatuses;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE TransportStatuses DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE TransportStatuses IS NOT EXIST';     
                "
            );
        }
    }
}
