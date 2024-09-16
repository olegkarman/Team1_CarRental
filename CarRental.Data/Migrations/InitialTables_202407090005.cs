using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407090005)]

    public class InitialTables_202407090005 : Migration
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
                            WHERE TABLE_NAME = 'InspectionReports'
                    )
                        BEGIN
                            CREATE TABLE InspectionReports
                            (
                                Id UNIQUEIDENTIFIER NOT NULL,
                                CONSTRAINT PK_InspectionReports_Id
                                    PRIMARY KEY (Id),
                                InspectionId UNIQUEIDENTIFIER NOT NULL,
                                InspectionDate DATETIME NULL,
                                InspectorName NVARCHAR(255) NULL,
                                CarId UNIQUEIDENTIFIER NOT NULL,
                                Result INT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE InspectionReports CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE InspectionReports IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'InspectionReports'
                    )
                        BEGIN
                            DROP TABLE InspectionReports;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE InspectionReports DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE InspectionReports IS NOT EXIST';     
                "
            );
        }
    }
}