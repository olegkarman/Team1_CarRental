--CREATE DATABASE CarRentalDB;
--GO

------------------------------------------------ T-SQL ALREADY EXECUTED START ------------------------------------------------

-- THE IMPLEMENTATION OF ENUMS ON THE DATABASE... O_o

CREATE TABLE TransportStatuses
(
	Id INT NOT NULL,
	-- DUE TO ENUM-INDEX CAN DUPLICATE BUT NOT STRING-VALUE.
	Status NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_TransportStatuses_Status_TEST
		PRIMARY KEY (Status)
);

CREATE TABLE InspectionStatuses
(
	Id INT NOT NULL,
	Status NVARCHAR(50) NOT NULL,
	CONSTRAINT PK_InspectionStatuses_Status_TEST
		PRIMARY KEY (Status)
);

-- END OF ENUMS

-- TABLES OF THE MAIN ENTITIES

CREATE TABLE Users
(
	-- ABSTRACT USER
	IdNumber NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Users_IdNumber
		PRIMARY KEY (IdNumber),
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	DateOfBirth Date NOT NULL,
	Password NVARCHAR(250) NOT NULL,
	UserName NVARCHAR(150) NOT NULL,
	-- CUSTOMER
	BasicDiscount FLOAT NULL,
	PassportNumber NVARCHAR(100) NULL,
	DrivingLicenseNumber NVARCHAR(100) NULL,
	-- INSPECTOR
	EmployementDate DATETIME NULL

	-- CONNECTIONS TO: [Cars] (1 — MANY), [Deals] (1 — MANY), [Inspections] (1 — MANY).
);

CREATE TABLE Deals
(
	Name NVARCHAR(250) NOT NULL,
	CustomerId NVARCHAR(100) NOT NULL, -- IT IS NOT IdNumber FROM User,
	-- IT IS A PassportNumber (CustomerManager.cs)... O_o
	-- SO NO COMPROMISE OF FIRST NROMAL-FORM, Я ДУМЯЮ... о_О
	CONSTRAINT PK_Deals_Name_CustomerId_TEST
		PRIMARY KEY (Name, CustomerId),
	IdNumber NVARCHAR(100) NOT NULL,
	CONSTRAINT FK_Deals_Users_CustomerId_IdNumber
		FOREIGN KEY (IdNumber)
			REFERENCES Users (IdNumber),
	CarId NVARCHAR(100) NOT NULL,
	Price FLOAT NOT NULL

	-- ENTITY CONNECTIONS: [Users] (MANY - 1), [Cars] (MANY - 1), THROUGH PROPERTIES.
);

CREATE TABLE Mechanicists
(
	Id NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Mechanicists_Id
		PRIMARY KEY (Id),
	Year INT NOT NULL,
	Name NVARCHAR(150) NOT NULL,
	Surename NVARCHAR(150) NOT NULL

	-- ENTITY CONNECTED TO [Repairs] (1 - MANY), DIRECTLY.
);

CREATE TABLE Cars
(
	CarId NVARCHAR(100) NOT NULL,
	VinCode NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_CarId_VinCode
		PRIMARY KEY (CarId, VinCode),
	Status NVARCHAR(50) NULL,
	-- AN ATTEMPT TO IMPLEMENT ENUMS.
	-- CHECK(Status IN ('Unknown', 'Available', 'Rented', 'Sold', 'InRepair', 'Unavailable'))
	-- DEFAULT 'Unknown'
	CONSTRAINT FK_Cars_TransportStatuses_Status_TEST
		FOREIGN KEY (Status)
			REFERENCES TransportStatuses (Status),
	-- DEAL CONNECTION (Car HAS ONE DEAL)
	Name NVARCHAR(250) NOT NULL,
	CustomerId NVARCHAR(100) NOT NULL,
	CONSTRAINT UQ_Cars_CustomerId_TEST
		UNIQUE(CustomerID),
	CONSTRAINT FK_Cars_Deals_Name_CustomerId_TEST
		FOREIGN KEY (Name, CustomerId)
			REFERENCES Deals (Name, CustomerId),
	NumberPlate NVARCHAR(50) NOT NULL,
	Brand NVARCHAR(500) NOT NULL,
	Model NVARCHAR(500) NOT NULL,
	Price INT NOT NULL,
	NumberOfSeats INT NULL,
	NumberOfDoors INT NULL,
	Mileage FLOAT NULL,
	MaxFuelCapacity INT NULL,
	CurrentFuel FLOAT NULL,
	Year INT NULL,
	IsFitForUse BIT NULL

	-- ENTITY CONNECTIONS: [Deals] (1 — 1) V, [Inspections] (1 — MANY) V,
	-- [Customer] (MANY - 1) V, [Repairs] (1 - MANY).
	-- DIRECTLY BY TYPES AND COLLECTIONS OF TYPE.
);

CREATE TABLE Inspections
(
	InspectionId NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Inspections_InspectionId
		PRIMARY KEY (InspectionId),
	-- INSPECTION CONNECTION TO Car, (MANY - 1).
	CarId NVARCHAR(100) NOT NULL,
	VinCode NVARCHAR(100) NOT NULL,
	CONSTRAINT FK_Inspection_Cars_CarId_VinCode_CarId_VinCode
		FOREIGN KEY (CarId, VinCode)
			REFERENCES Cars (CarId, VinCode),
	-- INSPECTION CONNECTION TO STATUS ENUM.
	Result NVARCHAR(50) NULL,
	CONSTRAINT FK_Inspections_InspectionStatuses_Result_Status_TEST
		FOREIGN KEY (Result)
			REFERENCES InspectionStatuses (Status),
	-- CONNECTION INSPECTOR
	IdNumber NVARCHAR(100) NOT NULL,
	CONSTRAINT FK_Inspections_Users_IdNumber_IdNumber_TEST
		FOREIGN KEY (IdNumber)
			REFERENCES Users (IdNumber),
	InspectionDate DATE NULL
	--InspectorName NVARCHAR(250) NULL, TRANSITIVE DEPENDANCY???


	-- ENTITY CONNECTIONS: [Cars] (MANY - 1) V, [Inspectors] (MANY — 1) V THROUGH PROPERTIES.
);

CREATE TABLE Repairs
(
	Id NVARCHAR(500) NOT NULL,
	CONSTRAINT PK_Repairs_Id
		PRIMARY KEY (Id),
	Date DATETIME NOT NULL,
	-- CONNECTION TO CARS (REPAIR HAS ONE CAR, CAR HAS MANY REPAIRS)
	CarId NVARCHAR(100) NOT NULL,
	VinCode NVARCHAR(100) NOT NULL,
	CONSTRAINT FK_Repairs_Cars_CarId_VinCode_CarId_VinCode
		FOREIGN KEY (CarId, VinCode)
			REFERENCES Cars (CarId, VinCode),
	MechanicName NVARCHAR(250) NULL,
	MechanicId NVARCHAR(100) NOT NULL,
	-- CONNECTION TO MECHANICISTS (ONE MECHANIC HAS MANY REPAIRS)
	CONSTRAINT FK_Repairs_Mechanicists_MechanicId_Id
		FOREIGN KEY (MechanicId)
			REFERENCES Mechanicists (Id),
	CarBrand NVARCHAR(500) NULL,
	CarModel NVARCHAR(500) NULL,
	-- TECHNICAL INFORMATION CAN CONSIST OF MUCH OF DATA.
	TechnicalInfo TEXT NULL,
	-- MAYBE MAKE IT CHECK IN? RATHER THAN BOOL?
	IsSuccessfull BIT NOT NULL,
	TotalCost INT NOT NULL

	-- CONNECTED TO: [Mechanics] (MANY - 1) V, [Cars] (MANY - 1) V DIRECTLY.
);

-- END OF MAIN ENTITIES

-- ALTERATION SECTION

	--ALTER TABLE Customers
	--ADD Constraint FK_Customers_Users_UserId FOREIGN KEY (UserId)
	--REFERENCES Users(ID)

	-- THIS IS NOT GOING TO WORK. (YPARKHOMENKO 28/06/24)

-- END OF ALTERATIONS

-- INSERT VALUE SECTION

INSERT INTO TransportStatuses
	VALUES
	   (0, 'Unknown'),
	   (1, 'Available'),
	   (2, 'Rented'),
	   (3, 'Sold'),
	   (4, 'InRepair'),
	   (200, 'Unavailable');

INSERT INTO InspectionStatuses
	VALUES
	   (0, 'Unknown'),
       (1, 'Successfully'),
       (2, 'Repair'),
       (3, 'Unusable');

-- SOME DATA TAKEN FROM MR. D. IBRAHIMOV'S BRANCH, AND O. KARMANSKYI CODE.
-- SOME TUPLES MUST BE NULL TO REPRESENT CUSTOMER, INSPECTOR.
INSERT INTO Users
	VALUES
		(
			-- CUSTOMER-1 / DEAL-1 RELATION.
			'615A5A48-5C4B-49F9-900B-0241134D640C',
			'Olga',
			'Ivanenko',
			'1987-12-03T00:00:00',
			'1234BB385678C6533DC7CF4A',
			'Olga',
			0.5,
			'RW293589',
			'895609',
			NULL
		),
		(
			-- INSPECTOR
			-- INSPECTOR-1, INSPECTION-1 RELATION
			'67F84A48-B96B-4A16-BB38-6C641F8504CC',
			'Alex',
			'Petrov',
			'1984-11-03T00:00:00',
			'87654BB38321C6533DCBB387CF4A',
			'Alex',
			NULL,
			NULL,
			NULL,
			'1984-11-03T00:00:00'
		),
		(
			-- CUSTOMER-2
			'3B8BE39A-0738-4B15-93C9-3AA1620CBC5A',
			'Maria',
			'Sidorova',
			'1981-12-05T00:00:00',
			'123BB38487BB3865C6533DC7CF4A',
			'Maria',
			0.2,
			'MG225941',
			'172860',
			NULL
		),
		(
			-- CUSTOMER-3
			'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2',
			'Igor',
			'Kuznetsov',
			'1999-11-03T00:00:00',
			'567BB388123BB384C6533DC7CF4A',
			'Igor',
			0.5,
			'SL882705',
			'242445',
			NULL
		),
		(
			-- CUSTOMER-4
			'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A',
			'Elena',
			'Nikolaeva',
			'1987-10-03T00:00:00',
			'C653BB383DCBB387CF4A',
			'Elena',
			0.5,
			'UX764750',
			'488237',
			NULL
		);

INSERT INTO DEALS
	VALUES
		(
			'Alabama',
			'RW293589',
			'615A5A48-5C4B-49F9-900B-0241134D640C',
			-- CAR-1 CarId
			'9B09A4A5-0B13-4239-9E94-C3535E661566',
			-- CAR-1 Price
			55000
		);

INSERT INTO Cars
	VALUES
		(
			-- CAR-1 / DEAL-1 RELATION.
			'9B09A4A5-0B13-4239-9E94-C3535E661566',
			'X5JT7H0AXI3AAUQJ0524N2KQS9433RGUC',
			'Available',
			-- DEAL-1 Name
			'Alabama',
			-- DEAL-1 CustomerId
			'RW293589',
			'2S-M9WSQ-4L',
			'Zporozhets',
			'Bora',
			55000,
			-- NO TIME
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL,
			NULL
		);

INSERT INTO Mechanicists
	VALUES
	(
		'0BBEF7B3-CE96-4DC6-AF5D-899106C9BFD5',
		1991,
		'Yaroslav',
		'Durak'
	);

INSERT INTO Repairs
	VALUES
	(
		'E9046A8D-F100-4ACA-9B7C-D8680C7A81DD',
		'1996-11-04T00:00:00',
		-- REPAIR-1, CAR-1 RELATION
		'9B09A4A5-0B13-4239-9E94-C3535E661566',
		'X5JT7H0AXI3AAUQJ0524N2KQS9433RGUC',
		'Yaroslav',
		-- REPAIR-1, MECHANIC-1 RELATION
		'0BBEF7B3-CE96-4DC6-AF5D-899106C9BFD5',
		'Zporozhets',
		'Bora',
		-- TechnicalInfo
		'{ Brand = Zporozhets | Model = ZAZ-965 | Year = 2018 |
		Engine = FourStandardCylinders | Transmission = SemiAutomatic |
		Wheels = Elastomer | Interior = Metal | Color = DarkGray |
		VinCode = J5HOUCO2VPV86C6BDI2EGBHHXB5WODD15 | Price = 192966 |
		IsFitForUse = True | Status = Sold | CarId = a3ff4598-6fc6-4e28-a8f5-fce59f68d1dd |
		NumberPlate = WZ-509ZM-79 | Owner =  |} | IsSuccessfull = True | TotalCost = 64322 }',
		1,
		15000
	);

INSERT INTO Inspections
	VALUES
	(
		'D3C048F0-6752-4F0A-8CD9-B15F5D9CC730',
		-- INSPECTION-1, CAR-1 RELATION
		'9B09A4A5-0B13-4239-9E94-C3535E661566',
		'X5JT7H0AXI3AAUQJ0524N2KQS9433RGUC',
		'Successfully',
		-- INSPECTION-1, INSPECTOR-1 RELATION
		'67F84A48-B96B-4A16-BB38-6C641F8504CC',
		'1984-11-03T00:00:00'
	);

-- END OF INSER VALUES SECTION

-- COPY OF DANIIL IBRAHIMOV SCRIPT

CREATE TABLE Customers
(
	Id int IDENTITY not null PRIMARY KEY,
	PassportNumber NVARCHAR(100) not null,
	DrivingLicenseNumber NVARCHAR(100) not null,
	BasicDiscount FLOAT NOT NULL,
	UserId INT NOT NULL UNIQUE
);

INSERT INTO Customers
VALUES ('19990623O', '19990623DL',0.5, 1),
('19851214A', '19851214DL',0.5, 2),
('19920330M', '19920330DL',0.5, 3),
 ('19780722I', '19780722DL',0.5, 4),
('19951105E', '19951105DL',0.5, 5)

-- END OF COPY OF DANIIL IBRAHIMOV SCRIPT

------------------------------------------------ T-SQL ALREADY EXECUTED END ------------------------------------------------

------------------------------------------------ T-SQL ALREADY EXECUTED SECOND START ------------------------------------------------

-- INSERT SECTION --
-- 26-JUN-24
-- ADD MORE DATA

INSERT INTO Users
	VALUES
	(
		-- CUSTOMER-5
		'7D8752F4-E040-4B2D-9422-32A4C0C10789',
		'Hurricane',
		'Olena',
		'1991-11-04T02:01:00',
		'C653BB383DCBB387CF4A',
		'Armageddon',
		0.4,
		'MG394001',
		'733087',
		NULL
	);

INSERT INTO Deals
	VALUES
		(
			-- DEAL-2
			'Tihuana',
			-- DEAL-2, CUSTOMER-2 RELATION
			'MG225941',
			-- CUSTOMER-2 IdNumber
			'3B8BE39A-0738-4B15-93C9-3AA1620CBC5A',
			-- CAR-2 CarId
			'C01BD220-FE99-4E74-87AF-E3F6672A096E',
			-- CAR-2 Price
			245000
		),
		(
			-- DEAL-3
			'Mahuna-Lou',
			-- DEAL-3, CUSTOMER-3 RELATION
			'SL882705',
			-- CUSTOMER-3 IdNumber
			'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2',
			-- CAR-3 CarId
			'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
			-- CAR-3 Price
			68810
		),
		(
			-- DEAL-4
			'Hawai-October',
			-- DEAL-4, CUSTOMER-4 RELATION
			'UX764750',
			-- CUSTOMER-4 IdNumber
			'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A',
			-- CAR-4 CarId
			'57BED521-BE12-447B-AF3F-54466A9E8CEF',
			-- CAR-4 Price
			96700
		),
		(
			-- DEAL-5
			'Amarilo-Sydney',
			-- DEAL-5, CUSTOMER-5 RELATION
			'MG394001',
			-- CUSTOMER-5 IdNumber
			'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A',
			-- CAR-5 CarId
			'56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
			-- CAR-5 Price
			113900
		);

INSERT INTO Cars
	VALUES
	(
		-- CAR-2
		'C01BD220-FE99-4E74-87AF-E3F6672A096E',
		'UG7KNG1SBAFEXORSVVMJIXRBOYBD3HK38',
		'Sold',
		-- DEAL-2 Name
		'Tihuana',
		-- DEAL-2 CustomerId
		'MG225941',
		'8U-AGEV0-WI',
		'Nissan',
		'Dakar',
		245000,
		-- I HAVE SOME TIME ;O
		5,
		4,
		15000,
		200,
		200,
		'1986',
		1
	),
	(
		-- CAR-3
		'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
		'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
		'Sold',
		-- DEAL-3 Name
		'Mahuna-Lou',
		-- DEAL-3 CustomerId
		'SL882705',
		'0E-9OHNA-4Z',
		'Gyguli',
		'Golf',
		68810,
		5,
		4,
		500000,
		100,
		100,
		'1964',
		1
	),
	(
		-- CAR-4
		'57BED521-BE12-447B-AF3F-54466A9E8CEF',
		'JUGKHGQCOFTXQKZVK2TZBJ9DE5UGEHTWE',
		'Sold',
		-- DEAL-4 Name
		'Hawai-October',
		-- DEAL-4 CustomerId
		'UX764750',
		'RD-O2SDQ-9J',
		'Peugeot',
		'Touager',
		96700,
		4,
		2,
		10000,
		170,
		170,
		'2004',
		1
	),
	(
		-- CAR-5
		'56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
		'CQGF7RQL2PK7GTX6DRI3HCBPNIYHKZGEK',
		'Sold',
		-- DEAL-5 Name
		'Amarilo-Sydney',
		-- DEAL-5 CustomerId (Passport)
		'MG394001',
		'YE-SU542-GV',
		'Volkswagen',
		'Freedom',
		113900,
		7,
		4,
		9000,
		340,
		340,
		'2019',
		1
	);

INSERT INTO Mechanicists
	VALUES
	(
		-- MECHANIC-2
		'685F0F5D-2328-40B5-A32D-6E9233D55B96',
		1991,
		'Roxy',
		'Undefeatable'
	),
	(
		-- MECHANIC-3
		'6ECCC761-9A37-46CD-BC24-C326D8BE544E',
		1986,
		'TheMaster',
		'Dreadful'
	),
	(
		-- MECHANIC-4
		'5FC4F1FD-396A-42B2-B4D4-8832091108AD',
		1986,
		'TheSummoner',
		'Overpowered'
	),
	(
		-- MECHANIC-5
		'4B445309-CBC5-4895-8E02-4BAA0001238A',
		1999,
		'Soldier',
		'Mother'
	);

INSERT INTO Repairs
	VALUES
	(
		-- REPAIR-2
		'A6E435E7-44A5-4B40-8256-1A937B32A241',
		'2024-11-05T05:30:00',
		-- REPAIR-2, CAR-2 RELATION
		'C01BD220-FE99-4E74-87AF-E3F6672A096E',
		'UG7KNG1SBAFEXORSVVMJIXRBOYBD3HK38',
		-- REPAIR-2, MECHANIC-2 RELATION
		'Roxy',
		'685F0F5D-2328-40B5-A32D-6E9233D55B96',
		'Nissan',
		'Dakar',
		-- TechnicalInfo
		'{ Brand = Nissan | Model = Dakar | Year = 1986 |
		Engine = FourStandardCylinders | Transmission = SemiAutomatic |
		Wheels = Elastomer | Interior = Metal | Color = DarkGray |
		VinCode = UG7KNG1SBAFEXORSVVMJIXRBOYBD3HK38 | Price = 192966 |
		IsFitForUse = True | Status = Sold | CarId = C01BD220-FE99-4E74-87AF-E3F6672A096E |
		NumberPlate = WZ-509ZM-79 | Owner =  |} | IsSuccessfull = True | TotalCost = 64322 }',
		1,
		30000
	),
	(
		-- REPAIR-3
		'A528B82E-E369-4888-9363-35275C27656B',
		'2024-10-06T05:32:00',
		-- REPAIR-3, CAR-3 RELATION
		'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
		'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
		-- REPAIR-3, MECHANIC-3 RELATION
		'TheMaster',
		'6ECCC761-9A37-46CD-BC24-C326D8BE544E',
		'Gyguli',
		'Golf',
		-- TechnicalInfo
		'{ Brand = Gyguli | Model = Golf | Year = 1964 |
		Engine = FourStandardCylinders | Transmission = SemiAutomatic |
		Wheels = Elastomer | Interior = Metal | Color = DarkGray |
		VinCode = AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9 | Price = 68810 |
		IsFitForUse = True | Status = Sold | CarId = A783A6FA-3C35-4CE1-ABC0-12F9D69636BE |
		NumberPlate = WZ-509ZM-79 | Owner =  |} | IsSuccessfull = True | TotalCost = 64322 }',
		1,
		20000
	),
	(
		-- REPAIR-4
		'2643C170-65F3-4E8E-800D-35A93BD97A30',
		'2024-12-21T05:32:00',
		-- REPAIR-4, CAR-4 RELATION
		'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
		'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
		-- REPAIR-4, MECHANIC-4 RELATION
		'TheSummoner',
		'5FC4F1FD-396A-42B2-B4D4-8832091108AD',
		'Peugeot',
		'Touager',
		-- TechnicalInfo
		'{ Brand = Peugeot | Model = Touager | Year = 2011 | Engine = WingForm |
		Transmission = Unknown | Wheels = Alloy | Interior = Leather | Color = ButtonHighlight |
		VinCode = QYCO78LA07FPZE9QYCDAWZ3MG2H4VJHM2 | Price = 96700 | IsFitForUse = True |
		Status = Sold | CarId = 2fe9a8f6-a116-4841-94c9-755e1087159c |
		NumberPlate = RD-O2SDQ-9J | Owner =  |}',
		1,
		24000
	),
	(
		-- REPAIR-5
		'F5F60FA4-CCA6-4101-88B1-E8E8DF035C86',
		'2022-11-22T05:10:00',
		-- REPAIR-5, CAR-5 RELATION
		'56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
		'CQGF7RQL2PK7GTX6DRI3HCBPNIYHKZGEK',
		-- REPAIR-5, MECHANIC-5 RELATION
		'Soldier',
		'4B445309-CBC5-4895-8E02-4BAA0001238A',
		'Volkswagen',
		'Freedom',
		-- TechnicalInfo
		'{ Brand = Volkswagen | Model = Freedom | Year = 2019 | Engine = WingForm |
		Transmission = Unknown | Wheels = Alloy | Interior = Leather | Color = ButtonHighlight |
		VinCode = CQGF7RQL2PK7GTX6DRI3HCBPNIYHKZGEK | Price = 113900 | IsFitForUse = True |
		Status = Sold | CarId = 56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB |
		NumberPlate = YE-SU542-GV | Owner =  |}',
		1,
		24000
	);

INSERT INTO Inspections
	VALUES
	(
		-- INSPECTION-2
		'73879350-ECA4-4027-9A00-BC626BD53F2F',
		-- INSPECTION-2, CAR-2 RELATION
		'C01BD220-FE99-4E74-87AF-E3F6672A096E',
		'UG7KNG1SBAFEXORSVVMJIXRBOYBD3HK38',
		'Successfully',
		-- INSPECTION-2, INSPECTOR-1 RELATION
		'67F84A48-B96B-4A16-BB38-6C641F8504CC',
		'1985-11-03T11:20:13'
	),
	(
		-- INSPECTION-3
		'6AFF009B-200B-462F-AD97-41F127CF7075',
		-- INSPECTION-3, CAR-3 RELATION
		'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE',
		'AL2IH1QPF9F2SLGQ601FEB09M6NGZLFO9',
		'Successfully',
		-- INSPECTION-3, INSPECTOR-1 RELATION
		'67F84A48-B96B-4A16-BB38-6C641F8504CC',
		'2024-10-03T10:09:13'
	),
	(
		-- INSPECTION-4
		'8B412B47-80BB-4DA3-9883-6952E68D8F15',
		-- INSPECTION-4, CAR-4 RELATION
		'57BED521-BE12-447B-AF3F-54466A9E8CEF',
		'JUGKHGQCOFTXQKZVK2TZBJ9DE5UGEHTWE',
		'Successfully',
		-- INSPECTION-4, INSPECTOR-1 RELATION
		'67F84A48-B96B-4A16-BB38-6C641F8504CC',
		'2024-11-04T10:10:25'
	),
	(
		-- INSPECTION-5
		'5A51AF19-605D-4172-B8A1-A29181A5FFB8',
		-- INSPECTION-5, CAR-5 RELATION
		'56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB',
		'CQGF7RQL2PK7GTX6DRI3HCBPNIYHKZGEK',
		'Successfully',
		-- INSPECTION-5, INSPECTOR-1 RELATION
		'67F84A48-B96B-4A16-BB38-6C641F8504CC',
		'2024-10-08T14:12:33'
	);

-- END OF INSERT SECTION

-- ALTER SECTION
-- 27-JUN-24
-- ADD ATTRIBUTES TO CORRESPOND SOURCE CODE

ALTER TABLE Cars
	ADD
		Engine NVARCHAR(500) NULL,
		Transmission NVARCHAR(500) NULL,
		Interior NVARCHAR(500) NULL,
		Wheels NVARCHAR(500) NULL,
		Lights NVARCHAR(500) NULL,
		Signal NVARCHAR(500) NULL,
		Color NVARCHAR(500) NULL;
GO -- SOMEHOW WITHOUT 'GO' THE STATEMENT 'UPDATE' EXECTURED BEFORE 'ADD'.

-- END OF ALTER SECTION

-- UPDATE SECTION
-- 27-JUN-24
-- TO UPDATE SOME NULL-ATTRIBUTES

UPDATE Cars
	SET 
		Engine = 'ThreeCircleCylinders',
		Transmission = ' Unknown',
		Interior = 'Leather',
		Wheels = 'Forged',
		Lights = 'Moderate',
		Signal = 'Low',
		Color = 'DarkOrchid '
	WHERE "CarId" = '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB';

UPDATE Cars	
	SET 
		Engine = 'EightCylinders',
		Transmission = ' Unknown',
		Interior = 'Unknown',
		Wheels = 'Steel',
		Lights = 'Powerful',
		Signal = 'Unknown',
		Color = 'DarkOrchid'
	WHERE "CarId" = '57BED521-BE12-447B-AF3F-54466A9E8CEF';

UPDATE Cars	
	SET 
		Engine = 'Flat',
		Transmission = 'ContinuouslyVariable',
		Interior = 'Unknown',
		Wheels = 'PressedMetal',
		Lights = 'Weak',
		Signal = 'Hight',
		Color = 'OrangeRed'
	WHERE "CarId" = '9B09A4A5-0B13-4239-9E94-C3535E661566';

UPDATE Cars	
	SET 
	    Engine = 'WingForm',
		Transmission = 'Manual',
		Interior = 'Metal',
		Wheels = 'Unknown',
		Lights = 'Powerful',
		Signal = 'Moderate',
		Color = 'OldLace '
	WHERE "CarId" = 'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE';

UPDATE Cars	
	SET 
		Engine = 'Unknown',
		Transmission = 'Manual',
		Interior = 'Unknown',
		Wheels = 'Chrome',
		Lights = 'Extreme',
		Signal = 'Low',
		Color = 'RosyBrown'
	WHERE "CarId" = 'C01BD220-FE99-4E74-87AF-E3F6672A096E';

-- END OF UPDATE SECTION

-- DROP SECTION
-- 27-JUN-24
-- DANIIL IBRAHIMOV

DROP TABLE Customers
--fixing for future changes

-- END OF DROP SECTION

-- CREATE SECTION
-- 28-JUN-24
-- TO CREATE BRANDS TABLE

CREATE TABLE Brands
(
	Model NVARCHAR(200) NOT NULL,
	CONSTRAINT PK_Brands_Model
		PRIMARY KEY (Model),
	Id NVARCHAR(100) NOT NULL,
	BrandName NVARCHAR(200) NOT NULL
	
);

-- END OF CREATE SECTION

-- INSERT SECTION
-- 28-JUN-24

INSERT INTO Brands
	VALUES
		(
			'ZAZ-966V',
			'9A57673E-786D-4435-9F78-EC97DD7AB096',
			'Zaporozhets'
		),
		(
			'ZAZ-965',
			'9A57673E-786D-4435-9F78-EC97DD7AB096',
			'Zaporozhets'
		),
		(
			'ZAZ-968',
			'9A57673E-786D-4435-9F78-EC97DD7AB096',
			'Zaporozhets'
		),
		(
			'Peugeot-204',
			'8F9E48D4-D5DD-48CD-8347-FC407472CAEB',
			'Peugeot'
		),
		(
			'Peugeot-J7',
			'8F9E48D4-D5DD-48CD-8347-FC407472CAEB',
			'Peugeot'
		),
		(
			'Golf',
			'075D6573-6BD4-4B61-4411-AED32C3A5460',
			'Voklswagen'
		),
		(
			'Patrol',
			'625F0634-3711-4351-7A29-67588339CE1D',
			'Nissan'
		),
		(
			'VAZ-2101',
			'96B549B7-E746-4BD9-4FC6-54A300C99E4B',
			'Gyguli'
		),
		(
			'Dakar',
			'E63E30F1-772F-4DC6-F1D8-9BDEEA53E605',
			'Jeep'
		);

-- END OF INSERT SECTION

-- ALTER SECTION
-- 28-JUN-24

ALTER TABLE Deals
	ADD
		VinCode NVARCHAR(100) NULL,
		DealType NVARCHAR(50) NULL;
GO

-- THERE WAS A 'HARDCORE'

ALTER TABLE Cars
	DROP CONSTRAINT UQ_Cars_CustomerId_TEST;
GO

-- END OF ALTER SECTION

-- UPDATE SECTION
-- 28-JUN-24

UPDATE Deals
	SET
		VinCode = '1H9M2KZD6JL0GTITA5XRQ2MWFN8HYESCO',
		DealType = 'purchase'
	WHERE CarId = '9B09A4A5-0B13-4239-9E94-C3535E661566';

UPDATE Deals
	SET
		VinCode = 'J9IG6QPP4LRA8CVQCDA7X4A7FY3YYCPDW',
		DealType = 'purchase'
	WHERE CarId = 'C01BD220-FE99-4E74-87AF-E3F6672A096E';

UPDATE Deals
	SET
		VinCode = 'OOA660S9FTS69AULA1CVNB2A1NJO57WSS',
		DealType = 'purchase'
	WHERE CarId = 'A783A6FA-3C35-4CE1-ABC0-12F9D69636BE';

UPDATE Deals
	SET
		VinCode = 'QOF1LCRL0JAVSNE71W3WYYM6EMLIK693D',
		DealType = 'purchase'
	WHERE CarId = '57BED521-BE12-447B-AF3F-54466A9E8CEF';

UPDATE Deals
	SET
		VinCode = 'FHDBXV8DS0X7IQJ63FE30CUCBY25XM6D9',
		DealType = 'purchase'
	WHERE CarId = '56FF595B-17B7-4BA9-B9A9-D2242A4E5FDB';

-- END OF UPDATE SECTION

-- INSERT SECTION
-- 28-JUN-24

INSERT INTO Deals
	VALUES
		(
			-- DEAL-6
			'Arisaka-Bones',
			-- DEAL-6, CUSTOMER-5 RELATION
			'MG394001',
			-- CUSTOMER-5 IdNumber
			'7D8752F4-E040-4B2D-9422-32A4C0C10789', --
			-- CAR-6 CarId
			'48167DBF-AA16-4BDF-B72E-CC64737C9641',
			-- CAR-6 Price
			243999,
			'ONYWMBYQ5NWE72G1HE9CVGW5YAMTH4DG7',
			'rental'
		);

INSERT INTO Cars
	VALUES
	(
		-- CAR-6
		'48167DBF-AA16-4BDF-B72E-CC64737C9641',
		'ONYWMBYQ5NWE72G1HE9CVGW5YAMTH4DG7',
		'Rented',
		-- DEAL-6 Name
		'Arisaka-Bones',
		-- DEAL-6 CustomerId (Passport)
		'MG394001',
		'7Y-E9N7K-IU',
		'Jeep',
		'ZAZ-968',
		243999,
		5,
		4,
		11000,
		500,
		500,
		'2021',
		1,
		'Flat',
		'Manual',
		'Plastic',
		'CompositeAlloy',
		'Extreme',
		'Hight',
		'LightSlateGray'
	);

-- END OF INSERT SECTION

------------------------------------------------ T-SQL ALREADY EXECUTED SECOND END ------------------------------------------------

------------------------------------------------ T-SQL ALREADY EXECUTED THIRD ------------------------------------------------


-- ALTER TABLE SECTION
-- 02-JUL-24

ALTER TABLE Cars
	DROP CONSTRAINT FK_Cars_Deals_Name_CustomerId_TEST;
GO

ALTER TABLE Deals
	DROP CONSTRAINT PK_Deals_Name_CustomerId_TEST;
GO

ALTER TABLE Deals
	ADD
		Id NVARCHAR(100) NULL;
GO

-- END OF ALTER TABLE SECTION

-- UPDATE SECTION
-- 02-JUL-24

UPDATE Deals
	SET
		Id = '99AC3D72-D132-4F4B-6C96-B3B58249FF2D'
	WHERE Name = 'Alabama';

UPDATE Deals
	SET
		Id = '4074E448-C826-406B-FBD1-40B9BD43809D'
	WHERE Name = 'Arisaka-Bones';

UPDATE Deals
	SET
		Id = 'A9FEA928-1EB9-4657-51F8-C687CAB0C2B8'
	WHERE Name = 'Amarilo-Sydney';

UPDATE Deals
	SET
		Id = 'F0EB4C90-94F9-44C2-4A9C-C7ECBE902EA6'
	WHERE Name = 'Hawai-October';

UPDATE Deals
	SET
		Id = 'E7A8AFDF-C117-46AB-57B3-86AB19E07C0A'
	WHERE Name = 'Mahuna-Lou';

UPDATE Deals
	SET
		Id = 'BCBAE3B2-581B-4E50-6590-F0F02E0F96A5'
	WHERE Name = 'Tihuana';

-- END OF UPDATE SECTION

-- ALTER TABLE SECTION
-- 02-JUL-24

ALTER TABLE Deals
	ALTER COLUMN Id
		NVARCHAR(100) NOT NULL;
GO

ALTER TABLE Deals
	ADD CONSTRAINT PK_Deals_Id
		PRIMARY KEY (Id);
GO

ALTER TABLE Cars
	ADD
		DealId NVARCHAR(100) NULL;
GO

-- END OF ALTER SECTION

-- UPDATE SECTION
-- 02-JUL-24

UPDATE Cars
	SET DealId = '4074E448-C826-406B-FBD1-40B9BD43809D'
	WHERE Name = 'Arisaka-Bones';

UPDATE Cars
	SET DealId = '99AC3D72-D132-4F4B-6C96-B3B58249FF2D'
	WHERE Name = 'Alabama';

UPDATE Cars
	SET DealId = 'A9FEA928-1EB9-4657-51F8-C687CAB0C2B8'
	WHERE Name = 'Amarilo-Sydney';

UPDATE Cars
	SET DealId = 'F0EB4C90-94F9-44C2-4A9C-C7ECBE902EA6'
	WHERE Name = 'Hawai-October';

UPDATE Cars
	SET DealId = 'E7A8AFDF-C117-46AB-57B3-86AB19E07C0A'
	WHERE Name = 'Mahuna-Lou';

UPDATE Cars
	SET DealId = 'BCBAE3B2-581B-4E50-6590-F0F02E0F96A5'
	WHERE Name = 'Tihuana';

-- END OF UPDATE SECTION

-- ALTER SECTION
-- 02-JUL-24

ALTER TABLE Cars
	ADD CONSTRAINT FK_Cars_Deals_DealId_Id
		FOREIGN KEY (DealId)
			REFERENCES Deals (Id);
GO

ALTER TABLE Cars
	DROP COLUMN Name;
GO

-- END OF ALTER SECTION

-- UPDATE SECTION
-- 02-JUL-24

UPDATE Cars
	SET
		CustomerId = '3B8BE39A-0738-4B15-93C9-3AA1620CBC5A'
	WHERE DealId = 'BCBAE3B2-581B-4E50-6590-F0F02E0F96A5';

UPDATE Cars
	SET
		CustomerId = '615A5A48-5C4B-49F9-900B-0241134D640C'
	WHERE DealId = '99AC3D72-D132-4F4B-6C96-B3B58249FF2D';

UPDATE Cars
	SET
		CustomerId = '7D8752F4-E040-4B2D-9422-32A4C0C10789'
	WHERE DealId = 'A9FEA928-1EB9-4657-51F8-C687CAB0C2B8';

UPDATE Cars
	SET
		CustomerId = '7D8752F4-E040-4B2D-9422-32A4C0C10789'
	WHERE DealId = '4074E448-C826-406B-FBD1-40B9BD43809D';

UPDATE Cars
	SET
		CustomerId = 'BEC62BF5-35AB-45B0-A3AA-BA6A5F3EEBB2'
	WHERE DealId = 'E7A8AFDF-C117-46AB-57B3-86AB19E07C0A';

UPDATE Cars
	SET
		CustomerId = 'BF016BBD-0AF3-412A-B8CD-C6533DC7CF4A'
	WHERE DealId = 'F0EB4C90-94F9-44C2-4A9C-C7ECBE902EA6';

-- END OF UPDATE SECTION

-- ALTER SECTION
-- 02-JUL-24

ALTER TABLE Cars
	ADD CONSTRAINT FK_Cars_Users_CustomerId_IdNumber
		FOREIGN KEY (CustomerId)
			REFERENCES Users (IdNumber);
GO

-- END OF ALTER SECTION

-- ALTER SECTION
-- 02-JUL-24

ALTER TABLE Cars
	DROP CONSTRAINT FK_Cars_TransportStatuses_Status_TEST;
GO

ALTER TABLE TransportStatuses
	DROP CONSTRAINT	PK_TransportStatuses_Status_TEST;
GO

EXEC sp_rename 'TransportStatuses.Id',
	'Number', 'COLUMN';

ALTER TABLE TransportStatuses
	ADD
		Id INT IDENTITY;
GO

ALTER TABLE Cars
	ADD
		StatusId INT NULL;
GO

-- END OF ALTER SECTION

-- UPDATE SECTION
-- 02-JUL-24

UPDATE Cars
	SET
		StatusId = 1
	WHERE Status = 'Available';

UPDATE Cars
	SET
		StatusId = 4
	WHERE Status = 'Sold';

UPDATE Cars
	SET
		StatusId = 3
	WHERE Status = 'Rented';

-- END OF UPDATE SECTION

-- ALTER SECTION
-- 02-JUL-24

ALTER TABLE Cars
	DROP COLUMN Status;
GO

ALTER TABLE TransportStatuses
	ADD CONSTRAINT PK_TransportStatuses_Id
		PRIMARY KEY (Id);
GO

ALTER TABLE Cars
	ADD CONSTRAINT FK_Cars_TransportStatuses_StatusId_Id
		FOREIGN KEY (StatusId)
			REFERENCES TransportStatuses (Id);
GO

-- END OF ALTER SECTION

-- ALTER SECTION
-- 02-JUL-24

ALTER TABLE Inspections
	DROP CONSTRAINT FK_Inspections_InspectionStatuses_Result_Status_TEST;
GO

ALTER TABLE InspectionStatuses
	DROP CONSTRAINT	PK_InspectionStatuses_Status_TEST;
GO

EXEC sp_rename 'InspectionStatuses.Id',
	'Number', 'COLUMN';
GO

ALTER TABLE InspectionStatuses
	ADD
		Id INT IDENTITY;
GO

ALTER TABLE Inspections
	ADD
		StatusId INT NULL;
GO

-- END OF ALTER SECTION

-- UPDATE SECTION
-- 02-JUL-24

UPDATE Inspections
	SET
		StatusId = 2
	WHERE Result = 'Successfully';

-- END OF UPDATE SECTION

-- ALTER SECTION
-- 02-JUL-24

ALTER TABLE Inspections
	DROP COLUMN Result;
GO

ALTER TABLE InspectionStatuses
	ADD CONSTRAINT PK_InspectionStatuses_Id
		PRIMARY KEY (Id);
GO

ALTER TABLE Inspections
	ADD CONSTRAINT FK_Inspections_InspectionStatuses_StatusId_Id
		FOREIGN KEY (StatusId)
			REFERENCES InspectionStatuses (Id);
GO

ALTER TABLE Inspections
	DROP CONSTRAINT FK_Inspections_Users_IdNumber_IdNumber_TEST;
GO

EXEC sp_rename 'Inspections.IdNumber',
	'InspectorId', 'COLUMN';
GO

ALTER TABLE Inspections
	ADD CONSTRAINT FK_Inspections_Users_InspectorId_IdNumber
		FOREIGN KEY (InspectorId)
			REFERENCES Users (IdNumber);
GO

-- END OF ALTER SECTION

-- ALTER SECTION
-- 02-JUL-24

ALTER TABLE Users
	ADD
		Category NVARCHAR(50) NULL;
GO

-- END OF ALTER SECTION

-- UPDATE SECTION
-- 02-JUL-24

UPDATE Users
	SET
		Category = 'Customer'
	WHERE NOT UserName IN ('Alex');

UPDATE Users
	SET
		Category = 'Inspector'
	WHERE UserName IN ('Alex');

-- END OF UPDATE SECTION

-- CREATE SECTION
-- 02-JUL-24
-- O. KARMANSKYY

CREATE TABLE InspectionReports (
    Id UNIQUEIDENTIFIER
	CONSTRAINT PK_InspectionReports_Id -- Y. PAKRHOMENKO RENAME PRIMARY KEY, EASY CHANGE.
	 PRIMARY KEY (Id),
    InspectionId UNIQUEIDENTIFIER NOT NULL,
    InspectionDate DATETIME,
    InspectorName NVARCHAR(255),
    CarId UNIQUEIDENTIFIER NOT NULL,
    Result INT
);

-- END OF CREATE SECTION

-- ALTER SECTION
-- 02--JUL-24

ALTER TABLE Repairs
	DROP COLUMN MechanicName;
GO

ALTER TABLE Repairs
	DROP COLUMN CarBrand;
GO

ALTER TABLE Repairs
	DROP COLUMN CarModel;
GO

-- END OF ALTER SECTION

-- INSERT SECTION
-- 02-JUL-24
-- O. KARMANSKYY

INSERT INTO InspectionReports (Id, InspectionId, InspectionDate, InspectorName, CarId, Result)
	VALUES
	(NEWID(), NEWID(), '2023-04-01T10:00:00', 'John Doe', NEWID(), 1),
	(NEWID(), NEWID(), '2023-04-02T11:00:00', 'Jane Smith', NEWID(), 2),
	(NEWID(), NEWID(), '2023-04-03T09:30:00', 'Mike Johnson', NEWID(), 0),
	(NEWID(), NEWID(), '2023-04-04T14:45:00', 'Emily Davis', NEWID(), 1),
	(NEWID(), NEWID(), '2023-04-05T16:20:00', 'Chris Brown', NEWID(), 2);

-- END OF INSERT SECTION

------------------------------------------------ T-SQL ALREADY EXECUTED THIRD END ------------------------------------------------

------------------------------------------------ T-SQL ALREADY EXECUTED FOURTH START ------------------------------------------------

-- ALTER SECTION
-- 06-JUL-24
-- DROP TRANSITIVE-DEPENDANT ATTRIBUTE FROM DEALS

ALTER TABLE Deals
	DROP COLUMN CustomerId;

-- END OF ALTER SECTION

------------------------------------------------ T-SQL ALREADY EXECUTED FOURTH END ------------------------------------------------

------------------------------------------------ T-SQL ALREADY EXECUTED FIFTH START ------------------------------------------------

-- ALTER SECTION
-- 10-JUL-24

ALTER TABLE Cars
	ALTER COLUMN CustomerId NVARCHAR(100) NULL;

-- END OF ALTER SECTION

------------------------------------------------ T-SQL ALREADY EXECUTED FIFTH END ------------------------------------------------

------------------------------------------------ T-SQL ALREADY EXECUTED SIXTH START ------------------------------------------------

-- CREATE SECTION
-- 16-JUL-24

CREATE TABLE Inspector
(
	Id INT NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	DateOfBirth DATE NOT NULL
);

-- END OF CREATE SECTION

-- INSERT SECTION
-- 16-JUL-24

INSERT INTO Inspector
(
	Id,
	FirstName,
	LastName,
	DateOfBirth
)
	VALUES
		(
			1,
			'Adam',
			'Smith',
			CAST('1990-01-01' AS DATE)
		),
		(
			2,
			'Eva',
			'Smith',
			CAST('1991-01-02' AS DATE)
		),
		(
			3,
			'Mike',
			'Smith',
			CAST('1992-01-03' AS DATE)
		);

-- END OF INSERT SECTION

-- START OF ALTER SECTION
-- 16-JUL-24

ALTER TABLE Inspector
	ADD CONSTRAINT PK_Inspector_Id
		PRIMARY KEY (Id);

-- END OF ALTER SECTION

-- START OF EXECUTION SECTION
-- 18-JUL-24

EXECUTE sp_rename 'Deals.IdNumber',
	'CustomerId', 'COLUMN';

-- END OF EXECUTION SECTION

-- START OF ALTER SECTION
-- 18-JUL-2024

ALTER TABLE Inspections
	ALTER COLUMN InspectionDate DATETIME NULL;

ALTER TABLE Cars
	ALTER COLUMN Year INT NULL;

-- END OF ALTER SECTION

-- START OF UPDATE SECTION
-- 18-JUL-24

UPDATE Repairs
	SET
		TechnicalInfo = 'onsequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper u'
	WHERE Id = '2643C170-65F3-4E8E-800D-35A93BD97A30';

UPDATE Repairs
	SET
		TechnicalInfo = 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut,'
	WHERE Id = 'A528B82E-E369-4888-9363-35275C27656B';

UPDATE Repairs
	SET
		TechnicalInfo = 'icies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nulla'
	WHERE Id = 'A6E435E7-44A5-4B40-8256-1A937B32A241';

UPDATE Repairs
	SET
		TechnicalInfo = 'm quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc,'
	WHERE Id = 'E9046A8D-F100-4ACA-9B7C-D8680C7A81DD';

UPDATE Repairs
	SET
		TechnicalInfo = 'utrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipis'
	WHERE Id = 'F5F60FA4-CCA6-4101-88B1-E8E8DF035C86';

-- END OF UPDATE SECTION

-- START OF CREATE SECTION
-- 18-JUL-24
EXECUTE
('
	CREATE PROCEDURE GetCar (@Id NVARCHAR(100))
		AS
			SELECT Cars.CarId AS carCarId,
					Cars.VinCode AS carVinCode,
					Cars.NumberPlate AS carNumberPlate,
					Cars.Brand AS carBrand,
					Cars.Model AS carModel,
					Cars.Price AS carPrice,
					Cars.NumberOfSeats AS carNumberOfSeats,
					Cars.NumberOfDoors AS carNumberOfDoors,
					Cars.Mileage AS carMileage,
					Cars.MaxFuelCapacity AS carMaxFuelCapacity,
					Cars.CurrentFuel AS carCurrentFuel,
					Cars.Year AS carYear,
					Cars.IsFitForUse AS carIsFitForUse,
					Cars.Engine AS carEngine,
					Cars.Transmission AS carTransmission,
					Cars.Interior AS carInterior,
					Cars.Wheels AS carWheels,
					Cars.Lights AS carLights,
					Cars.Signal AS carSignal,
					Cars.Color AS carColor,
					TransportStatuses.Number AS carStatusId,
					Users.IdNumber AS userIdNumber,
					Users.FirstName AS userFirstName,
					Users.LastName AS userLastName,
					Users.DateOfBirth AS userDateOfBirth,
					Users.UserName AS userUserName,
					Users.Password AS userPassword,
					Users.PassportNumber AS userPassportNumber,
					Users.DrivingLicenseNumber AS userDrivingLicenseNumber,
					Users.BasicDiscount AS userBasicDiscount,
					Users.Category AS userCategory,
					Deals.Id AS dealId,
					Deals.CarId AS dealCarId,
					Deals.VinCode AS dealVinCode,
					Deals.CustomerId AS dealCustomerId,
					Deals.Price AS dealPrice,
					Deals.DealType dealDealType,
					Deals.Name AS dealName,
					Inspections.InspectionId AS inspectionInspectionId,
					Inspections.CarId AS inspectionCarId,
					Inspections.VinCode AS inspectionVinCode,
					Inspections.InspectorId AS inspectionInspectorId,
					Inspections.InspectionDate AS inspectionInspectionDate,
					Inspections.StatusId AS inspectionStatusId,
					Repairs.Id AS repairId,
					Repairs.Date AS repairDate,
					Repairs.CarId repairCarId,
					Repairs.VinCode AS repairVinCode,
					Repairs.MechanicId AS repairMechanicId,
					Repairs.IsSuccessfull AS repairIsSuccessfull,
					Repairs.TotalCost AS repairTotalCost,
					Repairs.TechnicalInfo AS repairTechnicalInfo
			FROM Cars
			LEFT JOIN Users
				ON Cars.CustomerId = Users.IdNumber
			LEFT JOIN Deals
				ON Deals.CarId = Cars.CarId
			LEFT JOIN Inspections
				ON Inspections.CarId = Cars.CarId
			LEFT JOIN Repairs
				ON Repairs.CarId = Cars.CarId
			LEFT JOIN TransportStatuses
				ON Cars.StatusId = TransportStatuses.Number
			WHERE Cars.CarId = @Id;
');

EXECUTE
('
	CREATE PROCEDURE CreateCar
	(
		@carId NVARCHAR(100),
		@vinCode NVARCHAR(100),
		@numberPlate NVARCHAR(50),
		@brand NVARCHAR(500),
		@model NVARCHAR(500),
		@price INT,
		@numberOfSeats INT,
		@numberOfDoors INT,
		@mileage FLOAT,
		@maxFuelCapacity INT,
		@currentFuel FLOAT,
		@year INT,
		@isFitForUse BIT,
		@engine NVARCHAR(500),
		@transmission NVARCHAR(500),
		@interior NVARCHAR(500),
		@wheels NVARCHAR(500),
		@lights NVARCHAR(500),
		@signal NVARCHAR(500),
		@color NVARCHAR(500),
		@statusId INT
	)
		AS
			INSERT INTO Cars
			(
				CarId,
				VinCode,
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
				StatusId
			)
				VALUES
				(
					@carId,
					@vinCode,
					@numberPlate,
					@brand,
					@model,
					@price,
					@numberOfSeats,
					@numberOfDoors,
					@mileage,
					@maxFuelCapacity,
					@currentFuel,
					@year,
					@isFitForUse,
					@engine,
					@transmission,
					@interior,
					@wheels,
					@lights,
					@signal,
					@color,
					@statusId
				);
');

EXECUTE
('
	CREATE PROCEDURE CheckIfCarEntryExist 
	(
		@Id NVARCHAR(100)
	)
		AS
			SELECT COUNT(CarId)
				FROM Cars
				WHERE CarId = @Id;
');

EXECUTE
('
	CREATE PROCEDURE GetAllCarsOfCustomer (@CustomerId NVARCHAR(100))
	AS
		SELECT Cars.CarId AS carCarId,
				Cars.VinCode AS carVinCode,
				Cars.NumberPlate AS carNumberPlate,
				Cars.Brand AS carBrand,
				Cars.Model AS carModel,
				Cars.Price AS carPrice,
				Cars.NumberOfSeats AS carNumberOfSeats,
				Cars.NumberOfDoors AS carNumberOfDoors,
				Cars.Mileage AS carMileage,
				Cars.MaxFuelCapacity AS carMaxFuelCapacity,
				Cars.CurrentFuel AS carCurrentFuel,
				Cars.Year AS carYear,
				Cars.IsFitForUse AS carIsFitForUse,
				Cars.Engine AS carEngine,
				Cars.Transmission AS carTransmission,
				Cars.Interior AS carInterior,
				Cars.Wheels AS carWheels,
				Cars.Lights AS carLights,
				Cars.Signal AS carSignal,
				Cars.Color AS carColor,
				TransportStatuses.Number AS carStatusId,
				Users.IdNumber AS userIdNumber,
				Users.FirstName AS userFirstName,
				Users.LastName AS userLastName,
				Users.DateOfBirth AS userDateOfBirth,
				Users.UserName AS userUserName,
				Users.Password AS userPassword,
				Users.PassportNumber AS userPassportNumber,
				Users.DrivingLicenseNumber AS userDrivingLicenseNumber,
				Users.BasicDiscount AS userBasicDiscount,
				Users.Category AS userCategory,
				Deals.Id AS dealId,
				Deals.CarId AS dealCarId,
				Deals.VinCode AS dealVinCode,
				Deals.CustomerId AS dealCustomerId,
				Deals.Price AS dealPrice,
				Deals.DealType dealDealType,
				Deals.Name AS dealName,
				Inspections.InspectionId AS inspectionInspectionId,
				Inspections.CarId AS inspectionCarId,
				Inspections.VinCode AS inspectionVinCode,
				Inspections.InspectorId AS inspectionInspectorId,
				Inspections.InspectionDate AS inspectionInspectionDate,
				Inspections.StatusId AS inspectionStatusId,
				Repairs.Id AS repairId,
				Repairs.Date AS repairDate,
				Repairs.CarId repairCarId,
				Repairs.VinCode AS repairVinCode,
				Repairs.MechanicId AS repairMechanicId,
				Repairs.IsSuccessfull AS repairIsSuccessfull,
				Repairs.TotalCost AS repairTotalCost,
				Repairs.TechnicalInfo AS repairTechnicalInfo
		FROM Cars
		LEFT JOIN Users
			ON Cars.CustomerId = Users.IdNumber
		LEFT JOIN Deals
			ON Deals.CarId = Cars.CarId
		LEFT JOIN Inspections
			ON Inspections.CarId = Cars.CarId
		LEFT JOIN Repairs
			ON Repairs.CarId = Cars.CarId
		LEFT JOIN TransportStatuses
			ON Cars.StatusId = TransportStatuses.Number
		WHERE Cars.CustomerId = @CustomerId;
');

EXECUTE
('
	CREATE PROCEDURE CheckIfCustomerEntryExist 
	(
		@Id NVARCHAR(100)
	)
		AS
			SELECT COUNT(IdNumber)
				FROM Users
				WHERE IdNumber = @Id;
');

EXECUTE
('
	CREATE PROCEDURE CreateCustomer
	(
		@IdNumber NVARCHAR(100),
		@FirstName NVARCHAR(150),
		@LastName NVARCHAR(150),
		@DateOfBirth DATE,
		@UserName NVARCHAR(150),
		@Password NVARCHAR(250),
		@PassportNumber NVARCHAR(100),
		@DrivingLicenseNumber NVARCHAR(100),
		@BasicDiscount FLOAT,
		@Category NVARCHAR(250) = ''Customer''
	)
		AS
			INSERT INTO Users
			(
				IdNumber,
				FirstName,
				LastName,
				DateOfBirth,
				UserName,
				Password,
				PassportNumber,
				DrivingLicenseNumber,
				BasicDiscount,
				Category
			)
				VALUES
				(
					@IdNumber,
					@FirstName,
					@LastName,
					@DateOfBirth,
					@UserName,
					@Password,
					@PassportNumber,
					@DrivingLicenseNumber,
					@BasicDiscount,
					@Category
				);
');

EXECUTE
('
	CREATE PROCEDURE CreateDeal
	(
		@Id NVARCHAR(100),
		@CarId NVARCHAR(100),
		@VinCode NVARCHAR(100),
		@CustomerId NVARCHAR(100),
		@Price FLOAT,
		@DealType NVARCHAR(50),
		@Name NVARCHAR(250)
	)
		AS
			INSERT INTO Deals
			(
				Id,
				CarId,
				VinCode,
				CustomerId,
				Price,
				DealType,
				Name
			)
				VALUES
				(
					@Id,
					@CarId,
					@VinCode,
					@CustomerId,
					@Price,
					@DealType,
					@Name
				);
');

EXECUTE
('
	CREATE VIEW CarsBulk
	AS
		SELECT Brand,
			Model,
			Year,
			Engine,
			Transmission,
			Wheels,
			Interior,
			Lights,
			Signal,
			NumberOfDoors,
			NumberOfSeats,
			Color,
			VinCode,
			Price,
			IsFitForUse,
			StatusId,
			CarId,
			NumberPlate
		FROM Cars;
');

-- END OF CREATE SECTION

------------------------------------------------ T-SQL ALREADY EXECUTED SIXTH END ------------------------------------------------

------------------------------------------------ T-SQL ALREADY EXECUTED SEVENTH START ------------------------------------------------

-- START OF CREATE SECTION
-- 27-JUL-2024

EXECUTE
('
	CREATE PROCEDURE GetMechanic (@Id NVARCHAR(100))
		AS
			SELECT Mechanicists.Id AS mechanId,
				Mechanicists.Name AS mechanName,
				Mechanicists.Surename AS mechanSurename,
				Mechanicists.Year AS mechanYear,
				Repairs.Id AS repairId,
				Repairs.Date AS repairDate,
				Repairs.CarId AS repairCarId,
				Repairs.VinCode AS repairVinCode,
				Repairs.MechanicId repairMechanicId,
				Repairs.IsSuccessfull AS repairIsSuccessfull,
				Repairs.TotalCost repairTotalCost,
				Repairs.TechnicalInfo AS repairTechnicalInfo
			FROM Mechanicists
			LEFT JOIN
				Repairs ON Mechanicists.Id = Repairs.MechanicId
			WHERE Mechanicists.Id = @Id;
');


EXECUTE
('
	CREATE PROCEDURE CreateRepair
	(
		@id NVARCHAR(500),
		@date DATETIME,
		@carId NVARCHAR(100),
		@vinCode NVARCHAR(100),
		@mechanicId NVARCHAR(100),
		@isSuccessfull BIT,
		@totalCost INT,
		@technicalInfo TEXT
	)
		AS
			INSERT INTO Repairs
			(
				Id,
				Date,
				CarId,
				VinCode,
				MechanicId,
				IsSuccessfull,
				TotalCost,
				TechnicalInfo
			)
				VALUES
				(
					@id,
					@date,
					@carId,
					@vinCode,
					@mechanicId,
					@isSuccessfull,
					@totalCost,
					@technicalInfo
				);
');

EXECUTE
('
	CREATE PROCEDURE UpdateCarIsFitForUse (@isFitForUse BIT, @carId NVARCHAR(100))
		AS
			UPDATE Cars
				SET IsFitForUse = @isFitForUse
				WHERE CarId = @carId;
');

-- END OF CREATE SECTION

------------------------------------------------ T-SQL ALREADY EXECUTED SEVENTH END ------------------------------------------------

------------------------------------------------ T-SQL ALREADY EXECUTED EIGHT START ------------------------------------------------

-- ALTER SECTION START
-- 01-AUG-24

ALTER TABLE Cars
	DROP CONSTRAINT FK_Cars_TransportStatuses_StatusId_Id;

ALTER TABLE Inspections
	DROP CONSTRAINT FK_Inspections_InspectionStatuses_StatusId_Id;

ALTER TABLE TransportStatuses
	DROP CONSTRAINT PK_TransportStatuses_Id;

ALTER TABLE InspectionStatuses
	DROP CONSTRAINT PK_InspectionStatuses_Id;

ALTER TABLE TransportStatuses
	DROP COLUMN Id;

ALTER TABLE InspectionStatuses
	DROP COLUMN Id;

ALTER TABLE TransportStatuses
	ADD CONSTRAINT PK_TransportStatuses_Number
	PRIMARY KEY (Number);

ALTER TABLE InspectionStatuses
	ADD CONSTRAINT PK_InspectionStatuses_Number
	PRIMARY KEY (Number);

-- ALTER SECTION END

-- UPDATE SECTION START
-- 01-AUG-24

UPDATE Cars
	SET StatusId = 3;

UPDATE Inspections
	SET StatusId = 1;

-- UPDATE SECTION END

-- ALTER SECTION START
-- 01-AUG-24

ALTER TABLE Cars
	ADD CONSTRAINT FK_Cars_TransportStatuses_StatusId_Number
		FOREIGN KEY (StatusId)
			REFERENCES TransportStatuses (Number);

ALTER TABLE Inspections
	ADD CONSTRAINT FK_Inspections_InspectionStatuses_StatusId_Number
		FOREIGN KEY (StatusId)
			REFERENCES InspectionStatuses (Number);

-- ALTER SECTION END

------------------------------------------------ T-SQL ALREADY EXECUTED EIGHT END ------------------------------------------------