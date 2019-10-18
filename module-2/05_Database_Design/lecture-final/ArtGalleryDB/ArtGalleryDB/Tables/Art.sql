CREATE TABLE [dbo].[Art]
(
    [ArtId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Title] NVARCHAR(50) NOT NULL DEFAULT 'Untitled', 
    [ArtistId] INT NOT NULL, 
    [InStoc] BIT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_Art_Person] FOREIGN KEY (ArtistId) REFERENCES Person(PersonId)
)
