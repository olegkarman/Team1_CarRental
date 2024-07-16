using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407160006)]

    public class InitialValuesReferential_202407160006 : Migration
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
                            WHERE ROUTINE_NAME = 'CreateCustomer';
                    )
                        BEGIN
							CREATE PROCEDURE CreateCustomer
							(
								@IdNumber NVARCHAR(100),
								@FirstName NVARCHAR(150),
								@LastName NVARCHAR(150),
								@DateOfBirth DATE,
								@UserName NVARCHAR(150),
								@Password NVARCHAR(250),
								@PassportNumber NVARCHAR(100),
								@DrivingLicenseNumber NVARCHAR(100),
								@BasicDiscount FLOAT,
								@Category NVARCHAR(250) = 'Customer'
							)
								AS
									INSERT INTO Users
									(
										IdNumber,
										FirstName,
										LastName,
										DateOfBirth,
										UserName,
										Password,
										PassportNumber,
										DrivingLicenseNumber,
										BasicDiscount,
										Category
									)
										VALUES
										(
											@IdNumber,
											@FirstName,
											@LastName,
											@DateOfBirth,
											@UserName,
											@Password,
											@PassportNumber,
											@DrivingLicenseNumber,
											@BasicDiscount,
											@Category
										);

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateCustomer CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateCustomer ALREADY EXISTS';
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
                            WHERE ROUTINE_NAME = 'CreateCustomer';
					)
						BEGIN
							DROP PRUCEDURE CreateCustomer;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateCustomer DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateCustomer IS NOT EXIST';
						END
                "
            );
        }
    }
}