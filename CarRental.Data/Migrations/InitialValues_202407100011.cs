using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407100011)]

    public class InitialTables_202407100011 : Migration
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
                        SELECT InspectionId
                            FROM Inspections
                            WHERE InspectionId = '6AFF009B-200B-462F-AD97-41F127CF7075'
                                OR InspectionId = '73879350-ECA4-4027-9A00-BC626BD53F2F'
                                OR InspectionId = '8B412B47-80BB-4DA3-9883-6952E68D8F15'
                                OR InspectionId = 'D3C048F0-6752-4F0A-8CD9-B15F5D9CC730'
                                OR InspectionId = '5A51AF19-605D-4172-B8A1-A29181A5FFB8'
                    )
                        BEGIN
                            INSERT INTO Inspections
                            (
                                InspectionId,
                                CarId,
                                VinCode,
                                InspectorId,
                                InspectionDate,
                                StatusId
                            )
                                VALUES
	                            (
                                    '6AFF009B-200B-462F-AD97-41F127CF7075',
                                    'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
                                    'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
                                    '67F84A48-B96B-4A16-BB38-6C641F8504CC',
                                    CAST('2024-10-03' AS Date),
                                    2
	                            ),
	                            (
                                    '73879350-ECA4-4027-9A00-BC626BD53F2F',
                                    'C01BD220-FE99-4E74-87AF-E3F6672A096E',
                                    'UG7KNG1SBAFEXORSVVMJIXRBOYBD3HK38', 
                                    '67F84A48-B96B-4A16-BB38-6C641F8504CC',
                                    CAST('1985-11-03' AS Date),
                                    2
	                            ),
	                            (
                                    '8B412B47-80BB-4DA3-9883-6952E68D8F15',
                                    '57BED521-BE12-447B-AF3F-54466A9E8CEF',
                                    'JUGKHGQCOFTXQKZVK2TZBJ9DE5UGEHTWE',
                                    '67F84A48-B96B-4A16-BB38-6C641F8504CC',
                                    CAST('2024-11-04' AS Date),
                                    2
	                            ),
	                            (
                                    'D3C048F0-6752-4F0A-8CD9-B15F5D9CC730',
                                    '9B09A4A5-0B13-4239-9E94-C3535E661566',
                                    'X5JT7H0AXI3AAUQJ0524N2KQS9433RGUC',
                                    '67F84A48-B96B-4A16-BB38-6C641F8504CC',
                                    CAST('1984-11-03' AS Date),
                                    2
	                            ),
                                (
                                    '5A51AF19-605D-4172-B8A1-A29181A5FFB8',
                                    '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
                                    'CQGF7RQL2PK7GTX6DRI3HCBPNIYHKZGEK',
                                    '67F84A48-B96B-4A16-BB38-6C641F8504CC',
                                    CAST('2024-10-08' AS Date),
                                    2
                                );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE Inspections';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN Inspections';
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
						FROM Inspections
                            WHERE InspectionId = '6AFF009B-200B-462F-AD97-41F127CF7075'
                                OR InspectionId = '73879350-ECA4-4027-9A00-BC626BD53F2F'
                                OR InspectionId = '8B412B47-80BB-4DA3-9883-6952E68D8F15'
                                OR InspectionId = 'D3C048F0-6752-4F0A-8CD9-B15F5D9CC730'
                                OR InspectionId = '5A51AF19-605D-4172-B8A1-A29181A5FFB8';
                "
            );
        }
    }
}