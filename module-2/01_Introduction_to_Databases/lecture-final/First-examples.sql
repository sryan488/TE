/*
This is a block comment
*/

-- This is a comment
-- Select all rows from city
SELECT * FROM city;  -- This is also a comment

-- Select 3 columns from city with populations > 5 million
SELECT name, district, population 
FROM city
WHERE population > 5000000
ORDER BY name DESC

-- Select 3 columns from city with populations between 5 and 8 million
SELECT name, district, population 
FROM city
WHERE population BETWEEN 5000000 AND 8000000
ORDER BY name DESC

-- Select 3 columns from city with populations between 5 and 8 million
SELECT name, district, population 
FROM city
WHERE population >= 5000000 AND population <= 8000000
ORDER BY name DESC

-- Select the cities in OH, MI and KY
SELECT * 
FROM city
WHERE countrycode = 'USA'
AND (district = 'Ohio' OR district = 'Michigan' OR district = 'Kentucky');

-- Select the cities in OH, MI and KY
SELECT * 
FROM city
WHERE countrycode = 'USA'
AND district IN ('Ohio', 'Michigan', 'Kentucky');

-- Select cities in states starting with 'M'
SELECT * 
FROM city
WHERE countrycode = 'USA'
AND district LIKE 'M%';

-- Select cities in states ending in 'NA'
SELECT * 
FROM city
WHERE countrycode = 'USA'
AND district LIKE '%NA';

-- Select cities in states which have a 'Z' in their names
SELECT * 
FROM city
WHERE countrycode = 'USA'
AND district LIKE '%Z%';



