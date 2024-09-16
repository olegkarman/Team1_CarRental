using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202409150001)]

    public class InitialValuesReferential_202409150001 : Migration
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
							WHERE ROUTINE_NAME = 'GetRepair'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetRepair (@repairId NVARCHAR(500))
								AS
									SELECT Id,
											Date,
											CarId,
											VinCode,
											MechanicId,
											TechnicalInfo,
											IsSuccessfull,
											TotalCost
									FROM Repairs
									WHERE Id = @repairId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetRepair CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetRepair ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetRepair'
					)
						BEGIN
							DROP PROCEDURE GetRepair;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetRepair DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetRepair IS NOT EXIST';
						END
                "
            );
        }
    }
}