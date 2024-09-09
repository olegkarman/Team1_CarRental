using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407110010)]

    public class InitialValuesReferential_202407110010 : Migration
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
                            FROM InspectionReports
                            WHERE Id = '21769fb7-13f5-4a9b-83e9-19ce0319e518'
                                OR Id = 'fc682ea0-fa0d-4351-9bbd-2a4b5d07215b'
                                OR Id = '1882fd26-246d-4ad6-afdc-3a0092996265'
                                OR Id = '8a9592f3-883d-40e4-b96e-465ebda630cc'
                                OR Id = 'b57449d2-1878-4bc5-9e77-4f5308479e28'
                    )
                        BEGIN
                            INSERT INTO InspectionReports
                            (
                                Id,
                                InspectionId,
                                InspectionDate,
                                InspectorName,
                                CarId,
                                Result
                            )
                                VALUES
	                            (
                                    '21769fb7-13f5-4a9b-83e9-19ce0319e518',
                                    'a7909e3f-9ad6-4681-b4a0-bc9bd45e267b',
                                    CAST('2023-04-05T16:20:00.000' AS DateTime),
                                    'Chris Brown',
                                    'e4c27d91-b869-4c4c-8a35-343531298c3d',
                                    2
	                            ),
	                            (
                                    'fc682ea0-fa0d-4351-9bbd-2a4b5d07215b',
                                    '90340bdd-1e0b-4475-b428-a9fc13251b53',
                                    CAST('2023-04-04T14:45:00.000' AS DateTime),
                                    'Emily Davis',
                                    'ac153b0a-396b-4926-a193-ab8cbad27fcc',
                                    1
	                            ),
	                            (
                                    '1882fd26-246d-4ad6-afdc-3a0092996265',
                                    '5c438a70-dead-44f7-a6fa-56f43219b2f4',
                                    CAST('2023-04-02T11:00:00.000' AS DateTime),
                                    'Jane Smith',
                                    '22dd79da-b2c4-4914-9e61-261875c290b5',
                                    2
	                            ),
	                            (
                                    '8a9592f3-883d-40e4-b96e-465ebda630cc',
                                    '89a6c337-c7c9-41d8-9374-ea63d8121173',
                                    CAST('2023-04-03T09:30:00.000' AS DateTime),
                                    'Mike Johnson',
                                    '60b93e5a-05d6-4d38-8b71-a836cc91c313',
                                    0
	                            ),
	                            (
                                    'b57449d2-1878-4bc5-9e77-4f5308479e28',
                                    '1f87d147-6472-4c6d-a613-bd27a9e7e20a',
                                    CAST('2023-04-01T10:00:00.000' AS DateTime),
                                    'John Doe',
                                    '8016660a-518a-4ca1-bf3d-f0098fd188b5',
                                    1
	                            );

                            PRINT 'MIGRATION APPLIED SUCCESSFULLY: DATA INSCRIBED INTO TABLE InspectionReports';
                        END
                    ELSE
                        PRINT 'MIGRATION FAILED: SOME OF THE DATA IS ALREADY EXIST IN InspectionReports';
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
						FROM InspectionReports
                            WHERE Id = '21769fb7-13f5-4a9b-83e9-19ce0319e518'
                                OR Id = 'fc682ea0-fa0d-4351-9bbd-2a4b5d07215b'
                                OR Id = '1882fd26-246d-4ad6-afdc-3a0092996265'
                                OR Id = '8a9592f3-883d-40e4-b96e-465ebda630cc'
                                OR Id = 'b57449d2-1878-4bc5-9e77-4f5308479e28';
                "
            );
        }
    }
}