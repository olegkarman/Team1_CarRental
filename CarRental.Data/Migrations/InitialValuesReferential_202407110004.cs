using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407110004)]

    public class InitialValuesReferential_202407110004 : Migration
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
		                    WHERE CONSTR_COLUMN.TABLE_NAME = 'Deals'
			                    AND CONSTR_COLUMN.COLUMN_NAME = 'CustomerId')
				                    BEGIN
					                    ALTER TABLE Deals
						                    ADD CONSTRAINT FK_Deals_Users_CustomerId__IdNumber
							                    FOREIGN KEY (CustomerId)
								                    REFERENCES Users (IdNumber);

					                    PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Deals COLUMN CustomerId CREATED FOREIGN KEY';
				                    END
                    ELSE
	                    PRINT 'MRIGRATION FAILED: IN TABLE Deals COLUMN CustomerId SOME FOREIGN KEY ALREADY EXISTS';
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
							WHERE TABLE_NAME = 'Deals'
								AND CONSTRAINT_NAME = 'FK_Deals_Users_CustomerId__IdNumber')
									BEGIN
										ALTER TABLE Deals
											DROP CONSTRAINT FK_Deals_Users_CustomerId__IdNumber;
					
										PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Deals COLUMN CustomerId DROPPED FOREIGN KEY';
									END
					ELSE
						PRINT 'MRIGRATION FAILED: FOR TABLE Deals COLUMN CustomerId FOREIGN KEY FK_Deals_Users_CustomerId__IdNumber IS NOT EXIST';
                "
            );
        }
    }
}