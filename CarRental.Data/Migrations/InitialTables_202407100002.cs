using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                                Year INT NOT NULL,
                                Name NVARCHAR(150) NOT NULL,
                                Surename NVARCHAR(150) NOT NULL
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