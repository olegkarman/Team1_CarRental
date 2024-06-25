CREATE DATABASE KarmaRentalThree
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

CREATE TABLE Deals
(
	Name NVARCHAR(250) NOT NULL,
	CustomerId NVARCHAR(100) NOT NULL,
	CONSTRAINT PK_Deals_Name_CustomerId
		PRIMARY KEY (Name, CustomerId),
	CarId NVARCHAR(100) NOT NULL,
	Price FLOAT NOT NULL

	-- ENTITY CONNECTIONS: [Users], [Cars] THROUGH PROPERTIES.
);



CREATE TABLE Users
(
	IdNumber NVARCHAR(100) NOT NULL PRIMARY KEY,
	FirstName NVARCHAR(150) NOT NULL,
	LastName NVARCHAR(150) NOT NULL,
	DateOfBirth Date NOT NULL,
	Password NVARCHAR(250) NOT NULL,
	UserName NVARCHAR(150) NOT NULL,
	BasicDiscount FLOAT NOT NULL,
	PassportNumber NVARCHAR(100) NOT NULL,
	DrivingLicenseNumber NVARCHAR(100) NOT NULL,
	EmployementDate DATETIME NOT NULL
);



CREATE TABLE Mechanicists
(
	Id NVARCHAR(100) NOT NULL PRIMARY KEY,
	Year INT NOT NULL,
	Name NVARCHAR(150) NOT NULL,
	Surename NVARCHAR(150) NOT NULL

	-- ENTITY CONNECTED TO [Repairs], DIRECTLY.
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
	CustomerId NVARCHAR(100) NOT NULL,
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

	-- ENTITY CONNECTIONS: [Deals] (1 - 1), [Inspections] (1 - MANY) V,
	-- [Customer] (MANY - 1), [Repairs] (1 - MANY).
	-- DIRECTLY BY TYPES AND COLLECTIONS OF TYPE.
);

CREATE TABLE Inspections
(
	InspectionId NVARCHAR(100) NOT NULL PRIMARY KEY,
	-- INSPECTION CONNECTION (Car HAS MANY INSPECTIONS),
	CarId NVARCHAR(100) NOT NULL,
	VinCode NVARCHAR(100) NOT NULL,
	FOREIGN KEY (CarId, VinCode)
		REFERENCES Cars (CarId, VinCode),
	InspectionDate DATE NULL,
	InspectorName NVARCHAR(250) NULL,
	Result NVARCHAR(50) NULL,
	-- INSPECTION CONNECTION TO STATUS ENUM.
	FOREIGN KEY (Result)
		REFERENCES InspectionStatuses (Status)

	-- ENTITY CONNECTIONS: [Cars] (MANY - 1) V, [Inspectors] THROUGH PROPERTIES.
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
	CarBrand NVARCHAR(500) NULL,
	CarModel NVARCHAR(500) NULL,
	MechanicName NVARCHAR(250) NULL,
	MechanicId NVARCHAR(100) NOT NULL,
	-- TECHNICAL INFORMATION CAN CONSIST OF MUCH OF DATA.
	TechnicalInfo TEXT NULL,
	IsSuccessfull BIT NOT NULL,
	TotalCost INT NOT NULL
);

-- END OF MAIN ENTITIES

-- ALTERATION SECTION

--ALTER TABLE Inspections
--ADD CONSTRAINT FK_Cars_CarId_VinCode_Inspections
--	FOREIGN KEY (CarId, VinCode)
--		REFERENCES Cars (CarId, VinCode);

-- END OF ALTERATIONS