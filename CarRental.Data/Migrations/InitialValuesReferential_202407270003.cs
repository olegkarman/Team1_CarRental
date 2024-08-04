using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407270003)]

    public class InitialValuesReferential_202407270003 : Migration
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
							WHERE ROUTINE_NAME = 'UpdateCarIsFitForUse'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE UpdateCarIsFitForUse (@isFitForUse BIT, @carId NVARCHAR(100))
									AS
										UPDATE Cars
											SET IsFitForUse = @isFitForUse
											WHERE CarId = @carId;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE UpdateCarIsFitForUse CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME UpdateCarIsFitForUse ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'UpdateCarIsFitForUse'
					)
						BEGIN
							DROP PROCEDURE UpdateCarIsFitForUse;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE UpdateCarIsFitForUse DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME UpdateCarIsFitForUse IS NOT EXIST';
						END
                "
            );
        }
    }
}