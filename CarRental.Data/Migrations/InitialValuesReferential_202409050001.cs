using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409050001)]

    public class InitialValuesReferential_202409050001 : Migration
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
							WHERE ROUTINE_NAME = 'GetCustomer'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetSimpleCustomer (@id NVARCHAR(100))
								AS
									SELECT IdNumber,
											FirstName,
											LastName,
											DateOfBirth,
											Password,
											UserName,
											BasicDiscount,
											PassportNumber,
											DrivingLicenseNumber,
											Category
									FROM Users
									WHERE IdNumber = @id
										AND Category = 'Customer';
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetCustomer CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetCustomer ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetCustomer'
					)
						BEGIN
							DROP PROCEDURE GetCustomer;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetCustomer DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetCustomer IS NOT EXIST';
						END
                "
            );
        }
    }
}