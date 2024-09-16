using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407090001)]

    public class InitialTables_202407090001 : Migration
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
                            WHERE TABLE_NAME = 'Users'
                    )
                        BEGIN
                            CREATE TABLE Users
                            (
                                IdNumber NVARCHAR(100) NOT NULL,
                                CONSTRAINT PK_Users_IdNumber
                                    PRIMARY KEY (IdNumber),
                                FirstName NVARCHAR(150) NOT NULL,
                                LastName NVARCHAR(150) NOT NULL,
                                DateOfBirth DATE NOT NULL,
                                UserName NVARCHAR(150) NOT NULL,
                                Password NVARCHAR(250) NOT NULL,
                                PassportNumber NVARCHAR(100) NULL,
                                DrivingLicenseNumber NVARCHAR(100) NULL,
                                EmployementDate DATETIME NULL,
                                BasicDiscount FLOAT NULL,
                                Category NVARCHAR(250) NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Users CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Users IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Users'
                    )
                        BEGIN
                            DROP TABLE Users;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Users DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Users IS NOT EXIST';     
                "
            );
        }
    }
}
