-- INSERT

-- 1. Add Klingon as a spoken language in the USA
INSERT INTO countrylanguage
	(countrycode, language, isofficial, percentage)
	VALUES
	('USA', 'Klingon', 1, 99.9)

SELECT * FROM countrylanguage WHERE countrycode IN ('USA')

-- 2. Add Klingon as a spoken language in Great Britain
INSERT INTO countrylanguage
	(countrycode, language, isofficial, percentage)
	VALUES
	('GBR', 'Klingon', 0, 2.04)

--Here is another way...
--INSERT INTO countrylanguage
--	(countrycode, language, isofficial, percentage)
--	VALUES
--	((SELECT code FROM country WHERE name = 'United Kingdom'), 'Klingon', 0, 2.04)


-- UPDATE

-- 1. Update the capital of the USA to Houston
SELECT * FROM city WHERE name = 'Houston'

UPDATE country
	SET capital = 3796  -- city id for Houston
	WHERE code = 'USA'


-- 2. Update the capital of the USA to Washington DC and the head of state
UPDATE country
	SET capital = 3813, 
	headofstate = 'Craig'
WHERE code = 'USA'

Select country.*, city.name AS 'Capital City'
from country 
	JOIN city on country.capital = city.id
where code = 'USA'

UPDATE city
	SET name = 'Washington'
WHERE id = 3813

INSERT INTO city
(name, countrycode, district, population)
VALUES
('Richfield', 'USA', 'Ohio', 20000)

SELECT * FROM CITY


-- DELETE

DELETE FROM city WHERE id = 4080 -- after deleting and adding it again, the id went to 4081, 4080 is used and gone forever

-- 1. Delete English as a spoken language in the USA
DELETE countrylanguage
WHERE countrycode = 'USA' AND language = 'English'

-- 2. Delete all occurrences of the Klingon language 
DELETE countrylanguage
WHERE language = 'Klingon'


-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

-- 3. Try deleting the country USA. What happens?


-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA

-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'


-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.
BEGIN TRAN
	Select * FROM countrylanguage
	DELETE from countrylanguage
	SELECT * FROM countrylanguage
ROLLBACK TRAN

SELECT * FROM countrylanguage


SELECT * FROM country WHERE code IN ('USA', 'CAN')

BEGIN TRAN
SELECT * FROM country WHERE code IN ('USA', 'CAN')
UPDATE country
SET population = population - 100000000
	WHERE code = 'CAN'
	SELECT * FROM country WHERE code IN ('USA', 'CAN')

	ROLLBACK TRAN

UPDATE country
	SET population = population + 100000000
	WHERE code = 'USA'
	SELECT * FROM country WHERE code IN ('USA', 'CAN')
COMMIT TRAN
	SELECT * FROM country WHERE code IN ('USA', 'CAN')


-- 2. Try updating all of the cities to be in the USA and roll it back

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.