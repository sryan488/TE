CREATE TABLE [dbo].[Purchase]
(
    [PurchaseId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PurchaseDate] DATETIME NOT NULL DEFAULT getdate(), 
    [Price] MONEY NOT NULL, 
    [CustomerId] INT NOT NULL, 
    [ArtId] INT NOT NULL, 
    CONSTRAINT [FK_Purchase_Person] FOREIGN KEY (CustomerId) REFERENCES Person(PersonId), 
    CONSTRAINT [FK_Purchase_Art] FOREIGN KEY (ArtId) REFERENCES Art(ArtId)
)
