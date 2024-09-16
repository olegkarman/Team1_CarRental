using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100002)]

    public class InitialTables_202407100002 : Migration
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
                            WHERE TABLE_NAME = 'Cars'
                    )
                        BEGIN
                            CREATE TABLE Cars
                            (
                                CarId NVARCHAR(100) NOT NULL,
                                VinCode NVARCHAR(100) NOT NULL,
                                CONSTRAINT PK_Cars_CarId_VinCode
                                    PRIMARY KEY (CarId, VinCode),
                                CustomerId NVARCHAR(100) NULL,
                                NumberPlate NVARCHAR(50) NOT NULL,
                                Brand NVARCHAR(500) NOT NULL,
                                Model NVARCHAR(500) NOT NULL,
                                Price INT NOT NULL,
                                NumberOfSeats INT NULL,
                                NumberOfDoors INT NULL,
                                Mileage FLOAT NULL,
                                MaxFuelCapacity INT NULL,
                                CurrentFuel FLOAT NULL,
                                Year INT NULL,
                                IsFitForUse BIT NULL,
                                Engine NVARCHAR(500) NULL,
                                Transmission NVARCHAR(500) NULL,
                                Interior NVARCHAR(500) NULL,
                                Wheels NVARCHAR(500) NULL,
                                Lights NVARCHAR(500) NULL,
                                Signal NVARCHAR(500) NULL,
                                Color NVARCHAR(500) NULL,
                                DealId NVARCHAR(100),
                                StatusId INT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Cars CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Cars IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Cars'
                    )
                        BEGIN
                            DROP TABLE Cars;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Cars DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Cars IS NOT EXIST';     
                "
            );
        }
    }
}