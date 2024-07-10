using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100003)]

    public class InitialTables_202407100003 : Migration
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
                            WHERE TABLE_NAME = 'Repairs'
                    )
                        BEGIN
                            CREATE TABLE Repairs
                            (
                                Id NVARCHAR(500) NOT NULL,
                                CONSTRAINT PK_Repairs_Id
                                    PRIMARY KEY (Id),
                                Date DATETIME NOT NULL,
                                CarId NVARCHAR(100) NOT NULL,
                                VinCode NVARCHAR(100) NOT NULL,
                                MechanicId NVARCHAR(100) NOT NULL,
                                IsSuccessfull BIT NOT NULL,
                                TotalCost INT NOT NULL,
                                TechnicalInfo TEXT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Repairs CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Repairs IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Repairs'
                    )
                        BEGIN
                            DROP TABLE Repairs;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Repairs DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Repairs IS NOT EXIST';     
                "
            );
        }
    }
}