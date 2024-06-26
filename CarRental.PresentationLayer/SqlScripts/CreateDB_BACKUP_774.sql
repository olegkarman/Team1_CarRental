CREATE DATABASE KarmaCarRentalGoTwo
	GO
-- THE IMPLEMENTATION OF ENUMS ON THE DATABASE... O_o

CREATE TABLE TransportStatuses
(
	Id INT NOT NULL,
	-- DUE TO ENUM-INDEX CAN DUPLICATE BUT NOT STRING-VALUE.
	Status NVARCHAR(50) NOT NULL PRIMARY KEY
);

CREATE TABLE InspectionStatuses
(
	Id INT NOT NULL,
	Status NVARCHAR(50) NOT NULL PRIMARY KEY
);

-- END OF ENUMS

-- TABLES OF THE MAIN ENTITIES

CREATE TABLE Users
(
	-- ABSTRACT USER
	IdNumber NVARCHAR(100) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	DateOfBirth Date NOT NULL,
	Password NVARCHAR(250) NOT NULL,
	UserName NVARCHAR(150) NOT NULL,
<<<<<<< HEAD
	
=======
	-- CUSTOMER
	BasicDiscount FLOAT NULL,
	PassportNumber NVARCHAR(100) NULL,
	DrivingLicenseNumber NVARCHAR(100) NULL,
	-- INSPECTOR
	EmployementDate DATETIME NULL

	-- CONNECTIONS TO: [Cars] (1 — MANY), [Deals] (1 — MANY), [Inspections] (1 — MANY).
>>>>>>> origin/master
);

CREATE TABLE Customers
(
	Id int IDENTITY not null PRIMARY KEY,
	PassportNumber NVARCHAR(100) not null,
	DrivingLicenseNumber NVARCHAR(100) not null,
	BasicDiscount FLOAT NOT NULL,
	UserId INT NOT NULL UNIQUE
);



CREATE TABLE Deals
(
	Name NVARCHAR(250) NOT NULL,
	CustomerId NVARCHAR(100) NOT NULL, -- IT IS NOT IdNumber FROM User, IT IS PassportNumber... O_o
	-- SO NO COMPROMISE OF FIRST NROMAL-FORM, Я ДУМЯЮ... о_О
	CONSTRAINT PK_Deals_Name_CustomerId
		PRIMARY KEY (Name, CustomerId),
	IdNumber NVARCHAR(100) NOT NULL,
	FOREIGN KEY (IdNumber)
		REFERENCES Users (IdNumber),
	CarId NVARCHAR(100) NOT NULL,
	Price FLOAT NOT NULL

	-- ENTITY CONNECTIONS: [Users] (MANY - 1), [Cars] (MANY - 1), THROUGH PROPERTIES.
);

CREATE TABLE Mechanicists
(
	Id NVARCHAR(100) NOT NULL PRIMARY KEY,
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
	FOREIGN KEY (Status)
		REFERENCES TransportStatuses (Status),
	-- DEAL CONNECTION (Car HAS ONE DEAL)
	Name NVARCHAR(250) NOT NULL,
	CustomerId NVARCHAR(100) UNIQUE NOT NULL,
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
	Year DATE NULL,
	IsFitForUse BIT NULL

	-- ENTITY CONNECTIONS: [Deals] (1 — 1) V, [Inspections] (1 — MANY) V,
	-- [Customer] (MANY - 1) V, [Repairs] (1 - MANY).
	-- DIRECTLY BY TYPES AND COLLECTIONS OF TYPE.
);

CREATE TABLE Inspections
(
	InspectionId NVARCHAR(100) NOT NULL PRIMARY KEY,
	-- INSPECTION CONNECTION TO Car, (MANY - 1).
	CarId NVARCHAR(100) NOT NULL,
	VinCode NVARCHAR(100) NOT NULL,
	FOREIGN KEY (CarId, VinCode)
		REFERENCES Cars (CarId, VinCode),
	-- INSPECTION CONNECTION TO STATUS ENUM.
	Result NVARCHAR(50) NULL,
	FOREIGN KEY (Result)
		REFERENCES InspectionStatuses (Status),
	-- CONNECTION INSPECTOR
	IdNumber NVARCHAR(100) NOT NULL,
	FOREIGN KEY (IdNumber)
		REFERENCES Users (IdNumber),
	InspectionDate DATE NULL
	--InspectorName NVARCHAR(250) NULL, TRANSITIVE DEPENDANCY???


	-- ENTITY CONNECTIONS: [Cars] (MANY - 1) V, [Inspectors] (MANY — 1) V THROUGH PROPERTIES.
);

CREATE TABLE Repairs
(
	Id NVARCHAR(500) NOT NULL PRIMARY KEY,
	Date DATETIME NOT NULL,
	-- CONNECTION TO CARS (REPAIR HAS ONE CAR, CAR HAS MANY REPAIRS)
	CarId NVARCHAR(100) NOT NULL,
	VinCode NVARCHAR(100) NOT NULL,
	FOREIGN KEY (CarId, VinCode)
		REFERENCES Cars (CarId, VinCode),
	MechanicName NVARCHAR(250) NULL,
	MechanicId NVARCHAR(100) NOT NULL,
	-- CONNECTION TO MECHANICISTS (ONE MECHANIC HAS MANY REPAIRS)
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
	ALTER TABLE Customers
	ADD Constraint FK_Customers_Users_UserId FOREIGN KEY (UserId)
	REFERENCES Users(ID)
--ALTER TABLE Inspections
--ADD CONSTRAINT FK_Cars_CarId_VinCode_Inspections
--	FOREIGN KEY (CarId, VinCode)
--		REFERENCES Cars (CarId, VinCode);

-- END OF ALTERATIONS

<<<<<<< HEAD
INSERT INTO Users
VALUES  ('Olga', 'Ivanenko', '1999-06-23', '12345678', 'Olga'),
('Alex', 'Petrov', '1985-12-14', '87654321', 'Alex'),
('Maria', 'Sidorova', '1992-03-30', '12348765', 'Maria'),
('Igor', 'Kuznetsov', '1978-07-22', '56781234', 'Igor'),
('Elena', 'Nikolaeva', '1995-11-05', '43215678', 'Elena')
=======
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
>>>>>>> origin/master

INSERT INTO Customers
VALUES ('19990623O', '19990623DL',0.5, 1),
('19851214A', '19851214DL',0.5, 2),
('19920330M', '19920330DL',0.5, 3),
 ('19780722I', '19780722DL',0.5, 4),
('19951105E', '19951105DL',0.5, 5)
<<<<<<< HEAD
=======

-- END OF COPY OF DANIIL IBRAHIMOV SCRIPT
>>>>>>> origin/master
