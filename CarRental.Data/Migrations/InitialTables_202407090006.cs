using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407090006)]

    public class InitialTables_202407090006 : Migration
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
                        WHERE TABLE_NAME = 'Deals'
                )
                    BEGIN
                        CREATE TABLE Deals
                        (
                            Id NVARCHAR(100) NOT NULL,
                            CONSTRAINT PK_Deals_Id
                                PRIMARY KEY (Id),
                            CarId NVARCHAR(100) NOT NULL,
                            VinCode NVARCHAR(100) NULL,
                            CustomerId NVARCHAR(100) NOT NULL,
                            DealType NVARCHAR(50) NULL,
			                Name NVARCHAR(250) NULL
                        );

                        PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Deals CREATED';
                    END
                ELSE
                    PRINT 'MIGRATION FAILED: TABLE Deals IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Deals'
                    )
                        BEGIN
                            DROP TABLE Deals;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Deals DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Deals IS NOT EXIST';     
                "
            );
        }
    }
}