using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407180001)]

    public class InitialValuesReferential_202407180001 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
					IF NOT EXISTS
					(
						SELECT name
						FROM SYS.VIEWS
						WHERE name = 'CarsBulk'
					)
						BEGIN
							EXECUTE
							('
								CREATE VIEW CarsBulk
									AS
										SELECT Brand,
											Model,
											Year,
											Engine,
											Transmission,
											Wheels,
											Interior,
											Lights,
											Signal,
											NumberOfDoors,
											NumberOfSeats,
											Color,
											VinCode,
											Price,
											IsFitForUse,
											StatusId,
											CarId,
											NumberPlate
										FROM Cars;
								');

								PRINT 'MIRGRATION IS SUCCESSFULL: VIEW CarsBulk CREATED';
							END
					ELSE
						PRINT 'MIGRATION FAILED: VIEW WITH NAME CarsBulk IS ALREADY EXIST';
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
						SELECT name
						FROM SYS.VIEWS
						WHERE name = 'CarsBulk'
					)
						BEGIN
							DROP VIEW CarsBulk;

							PRINT 'MIRGRATION IS SUCCESSFULL: VIEW CarsBulk DELETED';
						END
					ELSE
						PRINT 'MIGRATION FAILED: VIEW WITH NAME CarsBulk IS NOT EXIST';
                "
            );
        }
    }
}