﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407160002)]

    public class InitialValuesReferential_202407160002 : Migration
    {
        public override void Up()
        {
            //IF AT LEAST SOME OF DATA EXIST, WILL BE NO ANY INSERT.
            //NEED DELETE ALL DATA FIRST.
            Execute.Sql
            (
                @"
                     IF NOT EXISTS
                    (
                        SELECT ROUTINE_NAME
                            FROM INFORMATION_SCHEMA.ROUTINES
                            WHERE ROUTINE_NAME = 'CreateCar';
                    )
                        BEGIN
                            CREATE PROCEDURE CreateCar
							(
								@carId NVARCHAR(100),
								@vinCode NVARCHAR(100),
								@numberPlate NVARCHAR(50),
								@brand NVARCHAR(500),
								@model NVARCHAR(500),
								@price INT,
								@numberOfSeats INT,
								@numberOfDoors INT,
								@mileage FLOAT,
								@maxFuelCapacity INT,
								@currentFuel FLOAT,
								@year INT,
								@isFitForUse BIT,
								@engine NVARCHAR(500),
								@transmission NVARCHAR(500),
								@interior NVARCHAR(500),
								@wheels NVARCHAR(500),
								@lights NVARCHAR(500),
								@signal NVARCHAR(500),
								@color NVARCHAR(500),
								@statusId INT
							)
								AS
									INSERT INTO Cars
									(
										CarId,
										VinCode,
						--				CustomerId,
										NumberPlate,
										Brand,
										Model,
										Price,
										NumberOfSeats,
										NumberOfDoors,
										Mileage,
										MaxFuelCapacity,
										CurrentFuel,
										Year,
										IsFitForUse,
										Engine,
										Transmission,
										Interior,
										Wheels,
										Lights,
										Signal,
										Color,
										StatusId
									)
										VALUES
										(
											@carId,
											@vinCode,
											@numberPlate,
											@brand,
											@model,
											@price,
											@numberOfSeats,
											@numberOfDoors,
											@mileage,
											@maxFuelCapacity,
											@currentFuel,
											@year,
											@isFitForUse,
											@engine,
											@transmission,
											@interior,
											@wheels,
											@lights,
											@signal,
											@color,
											@statusId
										);

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateCar CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateCar ALREADY EXISTS';
                "
            );
        }

        public override void Down()
        {
            // FOR DELETE STATEMENT IS NOT NEED CKECK OF EXISTANCE OF DATA,
            // IT IS SCALAR WHICH RETURNS 0, OR NUMBER OF ROWS AFFECTED.
            Execute.Sql
            (
                @"
					IF EXISTS
					(
						SELECT ROUTINE_NAME
                            FROM INFORMATION_SCHEMA.ROUTINES
                            WHERE ROUTINE_NAME = 'CreateCar';
					)
						BEGIN
							DROP PRUCEDURE CreateCar;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateCar DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateCar IS NOT EXIST';
						END
                "
            );
        }
    }
}