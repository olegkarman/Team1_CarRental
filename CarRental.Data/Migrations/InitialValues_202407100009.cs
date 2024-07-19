using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100009)]

    public class InitialValues_202407100009 : Migration
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
                            FROM Repairs
                            WHERE Id = '2643C170-65F3-4E8E-800D-35A93BD97A30'
                                OR Id = 'A528B82E-E369-4888-9363-35275C27656B'
                                OR Id = 'A6E435E7-44A5-4B40-8256-1A937B32A241'
                                OR Id = 'E9046A8D-F100-4ACA-9B7C-D8680C7A81DD'
                                OR Id = 'F5F60FA4-CCA6-4101-88B1-E8E8DF035C86'
                    )
                        BEGIN
                            INSERT INTO Repairs
                            (
                                Id,
                                Date,
                                CarId,
                                VinCode,
                                MechanicId,
                                TechnicalInfo,
                                IsSuccessfull,
                                TotalCost
                            )
                                VALUES
	                            (
                                    'A528B82E-E369-4888-9363-35275C27656B',
                                    CAST('2024-10-06T05:32:00.000' AS DateTime),
                                    'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
                                    'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
                                    '6ECCC761-9A37-46CD-BC24-C326D8BE544E',
                                    'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut,',
                                    1,
                                    20000
	                            ),
	                            (
                                    '2643C170-65F3-4E8E-800D-35A93BD97A30',
                                    CAST('2024-12-21T05:32:00.000' AS DateTime),
                                    'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
                                    'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
                                    '5FC4F1FD-396A-42B2-B4D4-8832091108AD',
                                    'onsequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper u',
                                    1,
                                    24000
	                            ),
	                            (
                                    'A6E435E7-44A5-4B40-8256-1A937B32A241',
                                    CAST('2024-11-05T05:30:00.000' AS DateTime),
                                    'C01BD220-FE99-4E74-87AF-E3F6672A096E',
                                    'UG7KNG1SBAFEXORSVVMJIXRBOYBD3HK38',
                                    '685F0F5D-2328-40B5-A32D-6E9233D55B96',
                                    'icies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nulla',
                                    1,
                                    30000
	                            ),
	                            (
                                    'E9046A8D-F100-4ACA-9B7C-D8680C7A81DD',
                                    CAST('1996-11-04T00:00:00.000' AS DateTime),
                                    '9B09A4A5-0B13-4239-9E94-C3535E661566',
                                    'X5JT7H0AXI3AAUQJ0524N2KQS9433RGUC',
                                    '0BBEF7B3-CE96-4DC6-AF5D-899106C9BFD5',
                                    'm quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,',
                                    1,
                                    15000
	                            ),
	                            (
                                    'F5F60FA4-CCA6-4101-88B1-E8E8DF035C86',
                                    CAST('2022-11-22T05:10:00.000' AS DateTime),
                                    '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
                                    'CQGF7RQL2PK7GTX6DRI3HCBPNIYHKZGEK',
                                    '4B445309-CBC5-4895-8E02-4BAA0001238A',
                                    'utrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipis',
                                    1,
                                    24000
	                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Repairs';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Repairs';
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
						FROM Repairs
                            WHERE Id = '2643C170-65F3-4E8E-800D-35A93BD97A30'
                                OR Id = 'A528B82E-E369-4888-9363-35275C27656B'
                                OR Id = 'A6E435E7-44A5-4B40-8256-1A937B32A241'
                                OR Id = 'E9046A8D-F100-4ACA-9B7C-D8680C7A81DD'
                                OR Id = 'F5F60FA4-CCA6-4101-88B1-E8E8DF035C86';
                "
            );
        }
    }
}