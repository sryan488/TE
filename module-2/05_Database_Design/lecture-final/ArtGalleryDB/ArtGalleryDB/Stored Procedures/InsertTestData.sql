CREATE PROCEDURE [dbo].[InsertTestData]
AS
    Insert Person (Name, Address, Phone)
    VALUES  ('Steve Roy', '123 Main Street', '555-1234'),
            ('Sean Ryan', '345 2nd Ave', '555-9876')

RETURN 0
