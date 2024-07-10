using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100006)]

    public class InitialTables_202407100006 : Migration
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
                            WHERE TABLE_NAME = 'Mechanicists'
                    )
                        BEGIN
                            CREATE TABLE Mechanicists
                            (
                                Id NVARCHAR(100) NOT NULL,
                                CONSTRAINT PK_Mechanicists_Id
                                    PRIMARY KEY (Id),
                                Year INT NOT NULL,
                                Name NVARCHAR(150) NOT NULL,
                                Surename NVARCHAR(150) NOT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Mechanicists CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Mechanicists IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Mechanicists'
                    )
                        BEGIN
                            DROP TABLE Mechanicists;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Mechanicists DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Mechanicists IS NOT EXIST';     
                "
            );
        }
    }
}