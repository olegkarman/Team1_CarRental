using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407080002)]

    public class InitialTables_202407080002 : Migration
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
                            WHERE TABLE_NAME = 'TransportStatuses'
                    )
                        BEGIN
                            CREATE TABLE TransportStatuses
                            (
                                Id INT IDENTITY(1, 1) NOT NULL,
                                CONSTRAINT PK_TransportStatuses_Id
                                    PRIMARY KEY (Id),
                                Number INT NOT NULL,
                                Status NVARCHAR(50) NOT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE TransportStatuses CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE TransportStatuses IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'TransportStatuses'
                    )
                        BEGIN
                            DROP TABLE TransportStatuses;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE TransportStatuses DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE TransportStatuses IS NOT EXIST';     
                "
            );
        }
    }
}
