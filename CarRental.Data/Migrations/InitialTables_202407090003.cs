using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407090003)]
    
    public class InitialTables_202407090003 : Migration
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
                            WHERE TABLE_NAME = 'InspectionStatuses'
                    )
                        BEGIN
                            CREATE TABLE InspectionStatuses
                            (
                                Number INT NOT NULL,
                                CONSTRAINT PK_InspectionStatuses_Number
                                    PRIMARY KEY (Number),
                                Status NVARCHAR(50) NOT NULL
                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE InspectionStatuses CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE InspectionStatuses IS ALREADY EXIST';
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
                            WHERE TABLE_NAME = 'InspectionStatuses'
                    )
                        BEGIN
                            DROP TABLE InspectionStatuses;

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: TABLE InspectionStatuses DELETED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: TABLE InspectionStatuses IS NOT EXIST';     
                "
            );
        }
    }
}
