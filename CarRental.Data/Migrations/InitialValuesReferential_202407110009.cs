using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace CarRentalData.Migrations
{
    [Migration(202407110009)]

    public class InitialValuesReferential_202407110009 : Migration
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
		                    WHERE CONSTR_COLUMN.TABLE_NAME = 'Repairs'
			                    AND CONSTR_COLUMN.COLUMN_NAME = 'MechanicId')
				                    BEGIN
					                    ALTER TABLE Repairs
						                    ADD CONSTRAINT FK_Repairs_Mechanicists_MechanicId_Id
							                    FOREIGN KEY (MechanicId)
								                    REFERENCES Mechanicists (Id);

					                    PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Repairs COLUMN MechanicId CREATED FOREIGN KEY';
				                    END
                    ELSE
	                    PRINT 'MRIGRATION FAILED: IN TABLE Repairs COLUMN MechanicId SOME FOREIGN KEY ALREADY EXISTS';
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
							WHERE TABLE_NAME = 'Repairs'
								AND CONSTRAINT_NAME = 'FK_Repairs_Mechanicists_MechanicId_Id')
									BEGIN
										ALTER TABLE Repairs
											DROP CONSTRAINT FK_Repairs_Mechanicists_MechanicId_Id;
					
										PRINT 'MRIGRATION IS SUCCESSFULL: FOR TABLE Repairs COLUMN MechanicId DROPPED FOREIGN KEY';
									END
					ELSE
						PRINT 'MRIGRATION FAILED: FOR TABLE Repairs COLUMN MechanicId FOREIGN KEY FK_Repairs_Mechanicists_MechanicId_Id IS NOT EXIST';
                "
            );
        }
    }
}