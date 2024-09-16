using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100006)]

    public class InitialValues_202407100006 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
                    IF NOT EXISTS
                    (
                        SELECT CarId
                            FROM Cars
                            WHERE CarId = '48167DBF-AA16-4BDF-B72E-CC64737C9641'
                                OR CarId = '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB'
                                OR CarId = '57BED521-BE12-447B-AF3F-54466A9E8CEF'
                                OR CarId = '9B09A4A5-0B13-4239-9E94-C3535E661566'
                                OR CarId = 'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE'
                                OR CarId = 'C01BD220-FE99-4E74-87AF-E3F6672A096E'
                    )
                        BEGIN
                            INSERT INTO Cars
                            (
                                CarId,
                                VinCode,
                                CustomerId,
                                NumberPlate,
                                Brand,
                                Model,
                                Price,
                                NumberOfSeats,
                                NumberOfDoors,
                                Mileage,
                                MaxFuelCapacity,
                                CurrentFuel,
                                Year,
                                IsFitForUse,
                                Engine,
                                Transmission,
                                Interior,
                                Wheels,
                                Lights,
                                Signal,
                                Color,
                                DealId,
                                StatusId
                            )
                                VALUES
		                        (
			                        '48167DBF-AA16-4BDF-B72E-CC64737C9641',
                                    'ONYWMBYQ5NWE72G1HE9CVGW5YAMTH4DG7',
                                    '7D8752F4-E040-4B2D-9422-32A4C0C10789',
                                    '7Y-E9N7K-IU',
                                    'Jeep',
                                    'ZAZ-968',
                                    243999,
                                    5,
                                    4,
                                    11000,
                                    500,
                                    500,
                                    2021,
                                    1,
                                    'Flat',
                                    'Manual',
                                    'Plastic',
                                    'CompositeAlloy',
                                    'Extreme',
                                    'Hight',
                                    'LightSlateGray',
                                    '4074E448-C826-406B-FBD1-40B9BD43809D',
                                    3
		                        ),
		                        (
			                        '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
                                    'CQGF7RQL2PK7GTX6DRI3HCBPNIYHKZGEK',
                                    '7D8752F4-E040-4B2D-9422-32A4C0C10789',
                                    'YE-SU542-GV',
                                    'Volkswagen',
                                    'Freedom',
                                    113900,
                                    7,
                                    4,
                                    9000,
                                    340,
                                    340,
                                    2019,
                                    1,
                                    'ThreeCircleCylinders',
                                    'Unknown',
                                    'Leather',
                                    'Forged',
                                    'Moderate',
                                    'Low',
                                    'DarkOrchid ',
                                    'A9FEA928-1EB9-4657-51F8-C687CAB0C2B8',
                                    3
		                        ),
		                        (
			                        '57BED521-BE12-447B-AF3F-54466A9E8CEF',
                                    'JUGKHGQCOFTXQKZVK2TZBJ9DE5UGEHTWE',
                                    'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A',
                                    'RD-O2SDQ-9J',
                                    'Peugeot',
                                    'Touager',
                                    96700,
                                    4,
                                    2,
                                    10000,
                                    170,
                                    170,
                                    2004,
                                    1,
                                    'EightCylinders',
                                    'Unknown',
                                    'Unknown',
                                    'Steel',
                                    'Powerful',
                                    'Unknown',
                                    'DarkOrchid',
                                    'F0EB4C90-94F9-44C2-4A9C-C7ECBE902EA6',
                                    3
		                        ),
		                        (
			                        '9B09A4A5-0B13-4239-9E94-C3535E661566',
                                    'X5JT7H0AXI3AAUQJ0524N2KQS9433RGUC',
                                    '615A5A48-5C4B-49F9-900B-0241134D640C',
                                    '2S-M9WSQ-4L',
                                    'Zporozhets',
                                    'Bora',
                                    55000,
                                    NULL,
                                    NULL,
                                    NULL,
                                    NULL,
                                    NULL,
                                    NULL,
                                    NULL,
                                    'Flat',
                                    'ContinuouslyVariable',
                                    'Unknown',
                                    'PressedMetal',
                                    'Weak',
                                    'Hight',
                                    'OrangeRed',
                                    '99AC3D72-D132-4F4B-6C96-B3B58249FF2D',
                                    3
		                        ),
		                        (
			                        'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
                                    'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
                                    'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2',
                                    '0E-9OHNA-4Z',
                                    'Gyguli',
                                    'Golf',
                                    68810,
                                    5,
                                    4,
                                    500000,
                                    100,
                                    100,
                                    1964,
                                    1,
                                    'WingForm',
                                    'Manual',
                                    'Metal',
                                    'Unknown',
                                    'Powerful',
                                    'Moderate',
                                    'OldLace ',
                                    'E7A8AFDF-C117-46AB-57B3-86AB19E07C0A',
                                    3
		                        ),
		                        (
			                        'C01BD220-FE99-4E74-87AF-E3F6672A096E',
                                    'UG7KNG1SBAFEXORSVVMJIXRBOYBD3HK38',
                                    '3B8BE39A-0738-4B15-93C9-3AA1620CBC5A',
                                    '8U-AGEV0-WI',
                                    'Nissan',
                                    'Dakar',
                                    245000,
                                    5,
                                    4,
                                    15000,
                                    200,
                                    200,
                                    1986,
                                    1,
                                    'Unknown',
                                    'Manual',
                                    'Unknown',
                                    'Chrome',
                                    'Extreme',
                                    'Low',
                                    'RosyBrown',
                                    'BCBAE3B2-581B-4E50-6590-F0F02E0F96A5',
                                    3
		                        );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Cars';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Cars';
                "
            );
        }

        public override void Down()
        {
            Execute.Sql
            (
                @"
					DELETE
						FROM Cars
					        WHERE CarId = '48167DBF-AA16-4BDF-B72E-CC64737C9641'
                                OR CarId = '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB'
                                OR CarId = '57BED521-BE12-447B-AF3F-54466A9E8CEF'
                                OR CarId = '9B09A4A5-0B13-4239-9E94-C3535E661566'
                                OR CarId = 'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE'
                                OR CarId = 'C01BD220-FE99-4E74-87AF-E3F6672A096E';
                "
            );
        }
    }
}