using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409160004)]

    public class InitialValuesReferential_202409160004 : Migration
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
							WHERE ROUTINE_NAME = 'GetDeal'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetDeal (@dealId NVARCHAR(100))
								AS
									SELECT Id,
											CarId,
											VinCode,
											CustomerId,
											Price,
											DealType,
											Name
										FROM Deals
										WHERE Id = @dealId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetDeal CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetDeal ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetDeal'
					)
						BEGIN
							DROP PROCEDURE GetDeal;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetDeal DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetDeal IS NOT EXIST';
						END
                "
            );
        }
    }
}