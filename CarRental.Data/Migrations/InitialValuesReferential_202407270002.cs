using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407270002)]

    public class InitialValuesReferential_202407270002 : Migration
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
							WHERE ROUTINE_NAME = 'CreateRepair'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE CreateRepair
								(
									@id NVARCHAR(500),
									@date DATETIME,
									@carId NVARCHAR(100),
									@vinCode NVARCHAR(100),
									@mechanicId NVARCHAR(100),
									@isSuccessfull BIT,
									@totalCost INT,
									@technicalInfo TEXT
								)
									AS
										BEGIN
											INSERT INTO Repairs
											(
												Id,
												Date,
												CarId,
												VinCode,
												MechanicId,
												IsSuccessfull,
												TotalCost,
												TechnicalInfo
											)
												VALUES
												(
													@id,
													@date,
													@carId,
													@vinCode,
													@mechanicId,
													@isSuccessfull,
													@totalCost,
													@technicalInfo
												);

											SELECT Id,
													Date,
													CarId,
													VinCode,
													MechanicId,
													IsSuccessfull,
													TotalCost,
													TechnicalInfo
												FROM Repairs
												WHERE Id = @id;
										END
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateRepair CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateRepair ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'CreateRepair'
					)
						BEGIN
							DROP PROCEDURE CreateRepair;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateRepair DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateRepair IS NOT EXIST';
						END
                "
            );
        }
    }
}