using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407110006)]

    public class InitialValuesReferential_202407110006 : Migration
    {
        public override void Up()
        {
            Execute.Sql
            (
                @"
                    IF NOT EXISTS
	                    (SELECT REF_CONSTRAINT.CONSTRAINT_NAME AS FK_NAME, CONSTR_COLUMN.TABLE_NAME AS SOURCE_TABLE,
		                    REF_CONSTRAINT.UNIQUE_CONSTRAINT_NAME AS TARGET_PK, TARGET_DATA.TABLE_NAME AS TARGET_TABLE
		                    FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS CONSTR_COLUMN
			                    RIGHT JOIN INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS REF_CONSTRAINT
				                    ON CONSTR_COLUMN.CONSTRAINT_NAME = REF_CONSTRAINT.CONSTRAINT_NAME
			                    LEFT JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS TARGET_DATA
				                    ON TARGET_DATA.CONSTRAINT_NAME = REF_CONSTRAINT.UNIQUE_CONSTRAINT_NAME
		                    WHERE CONSTR_COLUMN.TABLE_NAME = 'Inspections'
			                    AND CONSTR_COLUMN.COLUMN_NAME = 'StatusId')
				                    BEGIN
					                    ALTER TABLE Inspections
						                    ADD CONSTRAINT FK_Inspections_InspectionStatuses_StatusId_Number
							                    FOREIGN KEY (StatusId)
								                    REFERENCES InspectionStatuses (Number);

					                    PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Inspections COLUMN StatusId CREATED FOREIGN KEY';
				                    END
                    ELSE
	                    PRINT 'MRIGRATION FAILED: IN TABLE Inspections COLUMN StatusId SOME FOREIGN KEY ALREADY EXISTS';
                "
            );
        }

        public override void Down()
        {
            Execute.Sql
            (
                @"
					IF EXISTS
						(SELECT TABLE_NAME, CONSTRAINT_NAME
							FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
							WHERE TABLE_NAME = 'Inspections'
								AND CONSTRAINT_NAME = 'FK_Inspections_InspectionStatuses_StatusId_Number')
									BEGIN
										ALTER TABLE Inspections
											DROP CONSTRAINT FK_Inspections_InspectionStatuses_StatusId_Number;

										PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Inspections COLUMN StatusId DROPPED FOREIGN KEY';
									END
					ELSE
						PRINT 'MRIGRATION FAILED: FOR TABLE Inspections COLUMN StatusId FOREIGN KEY FK_Inspections_InspectionStatuses_StatusId_Number IS NOT EXIST';
			             "
            );

            //Execute.Sql
            //(
            //	@"
            //		IF EXISTS
            //			(SELECT TABLE_NAME, CONSTRAINT_NAME
            //				FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
            //				WHERE TABLE_NAME = 'Inspections'
            //					AND CONSTRAINT_NAME = 'FK_Inspections_InspectionStatuses_StatusId_Id')
            //						BEGIN
            //							ALTER TABLE Inspections
            //								DROP CONSTRAINT FK_Inspections_InspectionStatuses_StatusId_Id;

            //							PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Inspections COLUMN StatusId DROPPED FOREIGN KEY';
            //						END
            //		ELSE
            //			PRINT 'MRIGRATION FAILED: FOR TABLE Inspections COLUMN StatusId FOREIGN KEY FK_Inspections_InspectionStatuses_StatusId_Id IS NOT EXIST';
            //             "
            //);
        }
    }
}