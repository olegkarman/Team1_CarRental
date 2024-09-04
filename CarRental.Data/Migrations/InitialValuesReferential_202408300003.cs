using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202408300003)]

    public class InitialValuesReferential_202408300003 : Migration
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
							WHERE ROUTINE_NAME = 'UpdateNumberPlatePriceCar'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE UpdateNumberPlatePriceCar
								(
									@carId NVARCHAR(100),
									@numberPlate NVARCHAR(50),
									@price INT
								)
								AS
									UPDATE Cars
										SET NumberPlate = @numberPlate,
											Price = @price
										WHERE CarId = @carId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE UpdateNumberPlatePriceCar CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME UpdateNumberPlatePriceCar ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'UpdateNumberPlatePriceCar'
					)
						BEGIN
							DROP PROCEDURE UpdateNumberPlatePriceCar;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE UpdateNumberPlatePriceCar DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME UpdateNumberPlatePriceCar IS NOT EXIST';
						END
                "
            );
        }
    }
}