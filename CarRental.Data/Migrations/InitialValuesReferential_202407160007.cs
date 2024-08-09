using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407160007)]

    public class InitialValuesReferential_202407160007 : Migration
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
                            WHERE ROUTINE_NAME = 'CreateDeal'
                    )
                        BEGIN
							EXECUTE
							('
								CREATE PROCEDURE CreateDeal
								(
									@Id NVARCHAR(100),
									@CarId NVARCHAR(100),
									@VinCode NVARCHAR(100),
									@CustomerId NVARCHAR(100),
									@Price FLOAT,
									@DealType NVARCHAR(50),
									@Name NVARCHAR(250)
								)
									AS
										BEGIN
											INSERT INTO Deals
											(
												Id,
												CarId,
												VinCode,
												CustomerId,
												Price,
												DealType,
												Name
											)
												VALUES
												(
													@Id,
													@CarId,
													@VinCode,
													@CustomerId,
													@Price,
													@DealType,
													@Name
												);

											SELECT Id,
												CarId,
												VinCode,
												CustomerId,
												Price,
												DealType,
												Name
											FROM Deals
											WHERE Id = @Id;
										END
								');

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateDeal CREATED';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateDeal ALREADY EXISTS';
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
                            WHERE ROUTINE_NAME = 'CreateDeal'
					)
						BEGIN
							DROP PROCEDURE CreateDeal;

							PRINT 'MIGRATION APPLIED SUCCESSFULLY: STORED PROCEDURE CreateDeal DROPPED';
						END
					ELSE
						BEGIN
							PRINT 'MIGRATION FAILED: STORED PROCEDURE WITH NAME CreateDeal IS NOT EXIST';
						END
                "
            );
        }
    }
}