-- Switch the content to the 'master' database
Use master;
GO

-- If our DB already exists, drop it.
DROP DATABASE IF EXISTS ArtGallery;


-- Create the ArtGAllery DB
CREATE DATABASE ArtGallery;
GO

CREATE TABLE Person (
	PersonId    int NOT NULL IDENTITY(1,1),
	FirstName   nvarchar(30) NOT NULL,
	LastName    nvarchar(30) NOT NULL,
	Address     nvarchar(100) NULL,
	PhoneNumber varchar(15) NULL,
	constraint PK_Person PRIMARY KEY (PersonId)
);

CREATE TABLE Art (
	ArtId int IDENTITY(100, 10) PRIMARY KEY,
	Title nvarchar(50) NOT NULL DEFAULT('Untitled'),
	ArtistId int NOT NULL,
	InStock bit NOT NULL DEFAULT(1),
	CONSTRAINT FK_Art_Person FOREIGN KEY (ArtistId) REFERENCES Person(PersonId)
);

CREATE TABLE Purchase (
	PurchaseId int IDENTITY PRIMARY KEY,
	PurchaseDate datetime,
	Price money,
	CustomerId int NOT NULL,
	ArtId int NOT NULL,
	CONSTRAINT FK_Purchase_Person FOREIGN KEY (CustomerId) REFERENCES Person(PersonId),
	CONSTRAINT FK_Purchase_Art FOREIGN KEY (ArtId) REFERENCES Art(ArtId)
)


