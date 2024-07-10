using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100008)]

    public class InitialValues_202407100008 : Migration
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
                            FROM Mechanicists
                            WHERE Id = '0BBEF7B3-CE96-4DC6-AF5D-899106C9BFD5'
                                OR Id = '4B445309-CBC5-4895-8E02-4BAA0001238A'
                                OR Id = '5FC4F1FD-396A-42B2-B4D4-8832091108AD'
                                OR Id = '685F0F5D-2328-40B5-A32D-6E9233D55B96'
                                OR Id = '6ECCC761-9A37-46CD-BC24-C326D8BE544E'
                    )
                        BEGIN
                            INSERT INTO Mechanicists
                            (
                                Id,
                                Year,
                                Name,
                                Surename
                            )
                                VALUES
	                            (
                                    '0BBEF7B3-CE96-4DC6-AF5D-899106C9BFD5',
                                    1991,
                                    'Yaroslav',
                                    'Durak'
	                            ),
	                            (
                                    '4B445309-CBC5-4895-8E02-4BAA0001238A',
                                    1999,
                                    'Soldier',
                                    'Mother'
	                            ),
	                            (
                                    '5FC4F1FD-396A-42B2-B4D4-8832091108AD',
                                    1986,
                                    'TheSummoner',
                                    'Overpowered'
	                            ),
	                            (
                                    '685F0F5D-2328-40B5-A32D-6E9233D55B96',
                                    1991,
                                    'Roxy',
                                    'Undefeatable'
	                            ),
	                            (
                                    '6ECCC761-9A37-46CD-BC24-C326D8BE544E',
                                    1986,
                                    'TheMaster',
                                    'Dreadful'
	                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Mechanicists';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Mechanicists';
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
						FROM Mechanicists
                           WHERE Id = '0BBEF7B3-CE96-4DC6-AF5D-899106C9BFD5'
                                OR Id = '4B445309-CBC5-4895-8E02-4BAA0001238A'
                                OR Id = '5FC4F1FD-396A-42B2-B4D4-8832091108AD'
                                OR Id = '685F0F5D-2328-40B5-A32D-6E9233D55B96'
                                OR Id = '6ECCC761-9A37-46CD-BC24-C326D8BE544E';
                "
            );
        }
    }
}