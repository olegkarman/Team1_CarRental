using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407270001)]

    public class InitialValuesReferential_202407270001 : Migration
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
							WHERE ROUTINE_NAME = 'GetMechanic'
					)
						BEGIN
							EXECUTE
							('
								CREATE PROCEDURE GetMechanic (@Id NVARCHAR(100))
									AS
										SELECT Mechanicists.Id AS mechanId,
											Mechanicists.Name AS mechanName,
											Mechanicists.Surename AS mechanSurename,
											Mechanicists.Year AS mechanYear,
											Repairs.Id AS repairId,
											Repairs.Date AS repairDate,
											Repairs.CarId AS repairCarId,
											Repairs.VinCode AS repairVinCode,
											Repairs.MechanicId repairMechanicId,
											Repairs.IsSuccessfull AS repairIsSuccessfull,
											Repairs.TotalCost repairTotalCost,
											Repairs.TechnicalInfo AS repairTechnicalInfo
										FROM Mechanicists
										LEFT JOIN
											Repairs ON Mechanicists.Id = Repairs.MechanicId
										WHERE Mechanicists.Id = @Id;
							');

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetMechanic CREATED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetMechanic ALREADY EXISTS';
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
							WHERE ROUTINE_NAME = 'GetMechanic'
					)
						BEGIN
							DROP PROCEDURE GetMechanic;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE GetMechanic DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME GetMechanic IS NOT EXIST';
						END
                "
            );
        }
    }
}