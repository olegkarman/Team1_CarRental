using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100004)]

    public class InitialTables_202407100004 : Migration
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
                            WHERE TABLE_NAME = 'Inspections'
                    )
                        BEGIN
                            CREATE TABLE Inspections
                            (
                                InspectionId NVARCHAR(100) NOT NULL,
                                CONSTRAINT PK_Inspections_InspectionId
                                    PRIMARY KEY (InspectionId),
                                CarId NVARCHAR(100) NOT NULL,
                                VinCode NVARCHAR(100) NOT NULL,
                                InspectorId NVARCHAR(100) NOT NULL,
                                InspectionDate DATETIME NULL,
                                StatusId INT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Inspections CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Inspections IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Inspections'
                    )
                        BEGIN
                            DROP TABLE Inspections;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Inspections DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Inspections IS NOT EXIST';     
                "
            );
        }
    }
}