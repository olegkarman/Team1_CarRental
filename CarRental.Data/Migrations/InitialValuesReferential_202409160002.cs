using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409160002)]

    public class InitialValuesReferential_202409160002 : Migration
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
							WHERE ROUTINE_NAME = 'UpdateCarCustomerDealStatus'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE UpdateCarCustomerDealStatus
								(
									@carId NVARCHAR(100),
									@customerId NVARCHAR(100),
									@dealId NVARCHAR(100),
									@statusId INT
								)
								AS
									UPDATE Cars
										SET CustomerId = @customerId,
											DealId = @dealId,
											StatusId = @StatusId
										WHERE CarId = @carId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE UpdateCarCustomerDealStatus CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME UpdateCarCustomerDealStatus ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'UpdateCarCustomerDealStatus'
					)
						BEGIN
							DROP PROCEDURE UpdateCarCustomerDealStatus;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE UpdateCarCustomerDealStatus DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME UpdateCarCustomerDealStatus IS NOT EXIST';
						END
                "
            );
        }
    }
}