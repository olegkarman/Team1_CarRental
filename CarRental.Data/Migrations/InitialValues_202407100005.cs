using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarRentalData.Migrations
{
    [Migration(202407100005)]

    public class InitialTables_202407100005 : Migration
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
                        SELECT Model
                            FROM Brands
                            WHERE Model = 'Dakar'
                                OR Model = 'Golf'
                                OR Model = 'Patrol'
                                OR Model = 'Peugeot-204'
                                OR Model = 'Peugeot-J7'
                                OR Model = 'Peugeot-J7'
                                OR Model = 'VAZ-2101'
                                OR Model = 'ZAZ-965'
                                OR Model = 'ZAZ-966V'
                                OR Model = 'ZAZ-968'
                    )
                        BEGIN
                            INSERT INTO Brands (Model, Id, BrandName)
                                VALUES
		                        (
			                        'ZAZ-966V',
			                        '9A57673E-786D-4435-9F78-EC97DD7AB096',
			                        'Zaporozhets'
		                        ),
		                        (
			                        'ZAZ-965',
			                        '9A57673E-786D-4435-9F78-EC97DD7AB096',
			                        'Zaporozhets'
		                        ),
		                        (
			                        'ZAZ-968',
			                        '9A57673E-786D-4435-9F78-EC97DD7AB096',
			                        'Zaporozhets'
		                        ),
		                        (
			                        'Peugeot-204',
			                        '8F9E48D4-D5DD-48CD-8347-FC407472CAEB',
			                        'Peugeot'
		                        ),
		                        (
			                        'Peugeot-J7',
			                        '8F9E48D4-D5DD-48CD-8347-FC407472CAEB',
			                        'Peugeot'
		                        ),
		                        (
			                        'Golf',
			                        '075D6573-6BD4-4B61-4411-AED32C3A5460',
			                        'Voklswagen'
		                        ),
		                        (
			                        'Patrol',
			                        '625F0634-3711-4351-7A29-67588339CE1D',
			                        'Nissan'
		                        ),
		                        (
			                        'VAZ-2101',
			                        '96B549B7-E746-4BD9-4FC6-54A300C99E4B',
			                        'Gyguli'
		                        ),
		                        (
			                        'Dakar',
			                        'E63E30F1-772F-4DC6-F1D8-9BDEEA53E605',
			                        'Jeep'
		                        );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Brands';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Brands';
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
						FROM Brands
					        WHERE Model = 'Dakar'
                                OR Model = 'Golf'
                                OR Model = 'Patrol'
                                OR Model = 'Peugeot-204'
                                OR Model = 'Peugeot-J7'
                                OR Model = 'Peugeot-J7'
                                OR Model = 'VAZ-2101'
                                OR Model = 'ZAZ-965'
                                OR Model = 'ZAZ-966V'
                                OR Model = 'ZAZ-968';
                "
            );
        }
    }
}