using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407090004)]

    public class InitialTables_202407090004 : Migration
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
                            WHERE TABLE_NAME = 'Inspector'
                    )
                        BEGIN
                            CREATE TABLE Inspector
                            (
                                Id INT NOT NULL,
                                CONSTRAINT PK_Inspector_Id
                                    PRIMARY KEY (Id),
                                FirstName NVARCHAR(50) NOT NULL,
                                LastName NVARCHAR(50) NOT NULL,
                                DateOfBirth DATE NOT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Inspector CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Inspector IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Inspector'
                    )
                        BEGIN
                            DROP TABLE Inspector;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Inspector DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Inspector IS NOT EXIST';     
                "
            );
        }
    }
}