using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRental.Data.Migrations
{
    [Migration(202407080001)]

    public class InitialTables_202407080001 : Migration
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
                            WHERE TABLE_NAME = 'Brands'
                    )
                        BEGIN
                            CREATE TABLE Brands
                            (
                                Model NVARCHAR(200) NOT NULL,
                                CONSTRAINT PK_Brands_Model
                                    PRIMARY KEY (Model),
                                Id NVARCHAR(100) NOT NULL,
                                BrandName NVARCHAR(200) NOT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Brands CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Brands IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'Brands'
                    )
                        BEGIN
                            DROP TABLE Brands;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE Brands DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE Brands IS NOT EXIST';     
                "
            );
        }
    }
}
