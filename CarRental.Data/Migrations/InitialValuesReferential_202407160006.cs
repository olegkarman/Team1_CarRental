using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407160006)]

    public class InitialValuesReferential_202407160006 : Migration
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
                            WHERE ROUTINE_NAME = 'CreateCustomer'
                    )
                        BEGIN
							EXECUTE
							('
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
									@Category NVARCHAR(250) = ''Customer''
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
								');

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateCustomer CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateCustomer ALREADY EXISTS';
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
                            WHERE ROUTINE_NAME = 'CreateCustomer'
					)
						BEGIN
							DROP PROCEDURE CreateCustomer;

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