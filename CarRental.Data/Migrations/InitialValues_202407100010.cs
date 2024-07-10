using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100010)]

    public class InitialTables_202407100010 : Migration
    {
        public override void Up()
        {
            //IF AT LEAST SOME OF DATA EXIST, WILL BE NO ANY INSERT.
            //NEED DELETE ALL DATA FIRST.
            Execute.Sql
            (
                @"
                     IF NOT EXISTS
                    (
                        SELECT Id
                            FROM Deals
                            WHERE Id = '4074E448-C826-406B-FBD1-40B9BD43809D'
                                OR Id = '99AC3D72-D132-4F4B-6C96-B3B58249FF2D'
                                OR Id = 'A9FEA928-1EB9-4657-51F8-C687CAB0C2B8'
                                OR Id = 'BCBAE3B2-581B-4E50-6590-F0F02E0F96A5'
                                OR Id = 'E7A8AFDF-C117-46AB-57B3-86AB19E07C0A'
                    )
                        BEGIN
                            INSERT INTO Deals
                            (
                                Name,
                                CustomerId,
                                CarId,
                                Price,
                                VinCode,
                                DealType,
                                Id
                            )
                                VALUES
	                            (
                                    'Arisaka-Bones',
                                    '7D8752F4-E040-4B2D-9422-32A4C0C10789',
                                    '48167DBF-AA16-4BDF-B72E-CC64737C9641',
                                    243999,
                                    'ONYWMBYQ5NWE72G1HE9CVGW5YAMTH4DG7',
                                    'rental',
                                    '4074E448-C826-406B-FBD1-40B9BD43809D'
	                            ),
	                            (
                                    'Alabama',
                                    '615A5A48-5C4B-49F9-900B-0241134D640C',
                                    '9B09A4A5-0B13-4239-9E94-C3535E661566',
                                    55000,
                                    '1H9M2KZD6JL0GTITA5XRQ2MWFN8HYESCO',
                                    'purchase',
                                    '99AC3D72-D132-4F4B-6C96-B3B58249FF2D'
	                            ),
	                            (
                                    'Amarilo-Sydney',
                                    'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A',
                                    '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
                                    113900,
                                    'FHDBXV8DS0X7IQJ63FE30CUCBY25XM6D9',
                                    'purchase',
                                    'A9FEA928-1EB9-4657-51F8-C687CAB0C2B8'
	                            ),
	                            (
                                    'Tihuana',
                                    '3B8BE39A-0738-4B15-93C9-3AA1620CBC5A',
                                    'C01BD220-FE99-4E74-87AF-E3F6672A096E',
                                    245000,
                                    'J9IG6QPP4LRA8CVQCDA7X4A7FY3YYCPDW',
                                    'purchase',
                                    'BCBAE3B2-581B-4E50-6590-F0F02E0F96A5'
	                            ),
	                            (
                                    'Mahuna-Lou',
                                    'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2',
                                    'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
                                    68810,
                                    'OOA660S9FTS69AULA1CVNB2A1NJO57WSS',
                                    'purchase',
                                    'E7A8AFDF-C117-46AB-57B3-86AB19E07C0A'
	                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Deals';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Deals';
                "
            );
        }

        public override void Down()
        {
            // FOR DELETE STATEMENT IS NOT NEED CKECK OF EXISTANCE OF DATA,
            // IT IS SCALAR WHICH RETURNS 0, OR NUMBER OF ROWS AFFECTED.
            Execute.Sql
            (
                @"
					DELETE
						FROM Deals
                            WHERE Id = '4074E448-C826-406B-FBD1-40B9BD43809D'
                                OR Id = '99AC3D72-D132-4F4B-6C96-B3B58249FF2D'
                                OR Id = 'A9FEA928-1EB9-4657-51F8-C687CAB0C2B8'
                                OR Id = 'BCBAE3B2-581B-4E50-6590-F0F02E0F96A5'
                                OR Id = 'E7A8AFDF-C117-46AB-57B3-86AB19E07C0A';
                "
            );
        }
    }
}