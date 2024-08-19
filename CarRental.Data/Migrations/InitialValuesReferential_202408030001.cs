using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202408030001)]

    public class InitialValuesReferential_202408030001 : Migration
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
							WHERE ROUTINE_NAME = 'BuyRentCar'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE BuyRentCar
								(
									@dealId NVARCHAR(100),
									@carId NVARCHAR(100),
									@vinCode NVARCHAR(100),
									@customerId NVARCHAR(100),
									@price FLOAT,
									@dealType NVARCHAR(50),
									@name NVARCHAR(250),
									@isSuccessful BIT = 0 OUTPUT
								)
									AS
										BEGIN
											EXECUTE CreateDeal
												@Id = @dealId,
												@CarId = @carId,
												@VinCode = @vinCode,
												@CustomerId = @customerId,
												@Price = @price,
												@DealType = @dealType,
												@Name = @name;

											UPDATE Cars
												SET CustomerId = @customerId,
													DealId = @dealId,
													StatusId = 3
												WHERE CarId = @carId;
										END
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE BuyRentCar CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME BuyRentCar ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'BuyRentCar'
					)
						BEGIN
							DROP PROCEDURE BuyRentCar;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE BuyRentCar DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME BuyRentCar IS NOT EXIST';
						END
                "
            );
        }
    }
}