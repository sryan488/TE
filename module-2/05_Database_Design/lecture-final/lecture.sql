-- Switch the context to the 'master' database
Use master;
GO

-- If our DB already exists, drop it.
DROP DATABASE IF EXISTS ArtGallery;

-- Create the ArtGallery DB
CREATE DATABASE ArtGallery;
GO

-- Use the new database
USE ArtGallery;
GO

CREATE TABLE Person (
	PersonId	int NOT NULL IDENTITY(1,1),
	FirstName	nvarchar(30) NOT NULL,
	LastName	nvarchar(30) NOT NULL,
	Address		nvarchar(100) NULL,
	PhoneNumber varchar(15) NULL,
	constraint PK_Person PRIMARY KEY (PersonId)
);

CREATE TABLE Art (
	ArtId int identity(100, 10) primary key,
	Title nvarchar(50) NOT NULL Default('Untitled'),
	ArtistId int NOT NULL,
	InStock bit NOT NULL DEFAULT(1),
	constraint FK_Art_Person FOREIGN KEY (ArtistId) REFERENCES Person(PersonId)
)

CREATE TABLE Purchase (
	PurchaseId int identity primary key,
	PurchaseDate datetime,
	Price money,
	CustomerId int NOT NULL,
	ArtId int NOT NULL,
	constraint FK_Purchase_Person FOREIGN KEY (CustomerId) REFERENCES Person(PersonId),
	constraint FK_Purchase_Art FOREIGN KEY (ArtId) REFERENCES Art(ArtId)
)

-- Do a bunch of inserts of Test Data here....





