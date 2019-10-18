CREATE TABLE [dbo].[Person]
(
    [PersonId] INT NOT NULL IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(100) NULL, 
    [Phone] VARCHAR(20) NULL, 
    CONSTRAINT [PK_Person] PRIMARY KEY (PersonId)
)
