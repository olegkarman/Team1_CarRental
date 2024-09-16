using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407110001)]

    public class InitialValuesReferential_202407110001 : Migration
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
		                    WHERE CONSTR_COLUMN.TABLE_NAME = 'Cars'
			                    AND CONSTR_COLUMN.COLUMN_NAME = 'DealId')
				                    BEGIN
					                    ALTER TABLE Cars
						                    ADD CONSTRAINT FK_Cars_Deals_DealId_Id
							                    FOREIGN KEY (DealId)
								                    REFERENCES Deals (Id);

					                    PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Cars COLUMN DealId CREATED FOREIGN KEY';
				                    END
                    ELSE
	                    PRINT 'MRIGRATION FAILED: IN TABLE Cars COLUMN DealId SOME FOREIGN KEY ALREADY EXISTS';
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
							WHERE TABLE_NAME = 'Cars'
								AND CONSTRAINT_NAME = 'FK_Cars_Deals_DealId_Id')
									BEGIN
										ALTER TABLE Cars
											DROP CONSTRAINT FK_Cars_Deals_DealId_Id;
					
										PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Cars COLUMN DealId DROPPED FOREIGN KEY';
									END
					ELSE
						PRINT 'MRIGRATION FAILED: FOR TABLE Cars COLUMN DealId FOREIGN KEY FK_Cars_Deals_DealId_Id IS NOT EXIST';
                "
            );
        }
    }
}