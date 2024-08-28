using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202408280002)]

    public class InitialValuesReferential_202408280002 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
					IF NOT EXISTS 
					(
						SELECT ROUTINE_NAME
							FROM INFORMATION_SCHEMA.ROUTINES
							WHERE ROUTINE_NAME = 'CreateSimpleCar'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE CreateSimpleCar
								(
									@carId NVARCHAR(100),
									@vinCode NVARCHAR(100),
									@numberPlate NVARCHAR(50),
									@brand NVARCHAR(500),
									@model NVARCHAR(500),
									@price INT
								)
									AS
										BEGIN
											INSERT INTO Cars
											(
												CarId,
												VinCode,
												NumberPlate,
												Brand,
												Model,
												Price
											)
											VALUES
											(
												@carId,
												@vinCode,
												@numberPlate,
												@brand,
												@model,
												@price
											);
										END
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateSimpleCar CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateSimpleCar ALREADY EXISTS';
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
						SELECT ROUTINE_NAME
							FROM INFORMATION_SCHEMA.ROUTINES
							WHERE ROUTINE_NAME = 'CreateSimpleCar'
					)
						BEGIN
							DROP PROCEDURE CreateSimpleCar;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateSimpleCar DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateSimpleCar IS NOT EXIST';
						END
                "
            );
        }
    }
}