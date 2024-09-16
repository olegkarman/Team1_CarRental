using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100007)]

    public class InitialValues_202407100007 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
                     IF NOT EXISTS
                    (
                        SELECT IdNumber
                            FROM Users
                            WHERE IdNumber = '3B8BE39A-0738-4B15-93C9-3AA1620CBC5A'
                                OR IdNumber = '615A5A48-5C4B-49F9-900B-0241134D640C'
                                OR IdNumber = '67F84A48-B96B-4A16-BB38-6C641F8504CC'
                                OR IdNumber = '7D8752F4-E040-4B2D-9422-32A4C0C10789'
                                OR IdNumber = 'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2'
                                OR IdNumber = 'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A'
                    )
                        BEGIN
                            INSERT INTO Users
                            (
                                IdNumber,
                                FirstName,
                                LastName,
                                DateOfBirth, 
                                Password,
                                UserName,
                                BasicDiscount,
                                PassportNumber,
                                DrivingLicenseNumber,
                                EmployementDate,
                                Category
                            )
                                VALUES
	                        (
		                        '3B8BE39A-0738-4B15-93C9-3AA1620CBC5A',
                                    'Maria',
                                    'Sidorova',
                                    CAST('1981-12-05' AS Date),
                                    '123BB38487BB3865C6533DC7CF4A',
                                    'Maria',
                                    0.2,
                                    'MG225941',
                                    '172860',
                                    NULL,
                                    'Customer'
	                        ),
	                        (
		                        '615A5A48-5C4B-49F9-900B-0241134D640C',
                                    'Olga',
                                    'Ivanenko',
                                    CAST('1987-12-03' AS Date),
                                    '1234BB385678C6533DC7CF4A',
                                    'Olga',
                                    0.5,
                                    'RW293589',
                                    '895609',
                                    NULL,
                                    'Customer'
	                        ),
	                        (
		                        '67F84A48-B96B-4A16-BB38-6C641F8504CC',
                                    'Alex',
                                    'Petrov',
                                    CAST('1984-11-03' AS Date),
                                    '87654BB38321C6533DCBB387CF4A',
                                    'Alex',
                                    NULL,
                                    NULL,
                                    NULL,
                                    CAST('1984-11-03T00:00:00.000' AS DateTime),
                                    'Inspector'
	                        ),
	                        (
		                        '7D8752F4-E040-4B2D-9422-32A4C0C10789',
                                    'Hurricane',
                                    'Olena',
                                    CAST('1991-11-04' AS Date),
                                    'C653BB383DCBB387CF4A',
                                    'Armageddon',
                                    0.4,
                                    'MG394001',
                                    '733087',
                                    NULL,
                                    'Customer'
	                        ),
	                        (
		                        'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2',
                                    'Igor',
                                    'Kuznetsov',
                                    CAST('1999-11-03' AS Date),
                                    '567BB388123BB384C6533DC7CF4A',
                                    'Igor',
                                    0.5,
                                    'SL882705',
                                    '242445',
                                    NULL,
                                    'Customer'
	                        ),
	                        (
		                        'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A',
                                    'Elena',
                                    'Nikolaeva',
                                    CAST('1987-10-03' AS Date),
                                    'C653BB383DCBB387CF4A',
                                    'Elena',
                                    0.5,
                                    'UX764750',
                                    '488237',
                                    NULL,
                                    'Customer'
	                        );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Users';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Users';
                "
            );
        }

        public override void Down()
        {
            Execute.Sql
            (
                @"
					DELETE
						FROM Users
					        WHERE IdNumber = '3B8BE39A-0738-4B15-93C9-3AA1620CBC5A'
                                OR IdNumber = '615A5A48-5C4B-49F9-900B-0241134D640C'
                                OR IdNumber = '67F84A48-B96B-4A16-BB38-6C641F8504CC'
                                OR IdNumber = '7D8752F4-E040-4B2D-9422-32A4C0C10789'
                                OR IdNumber = 'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2'
                                OR IdNumber = 'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A';
                "
            );
        }
    }
}