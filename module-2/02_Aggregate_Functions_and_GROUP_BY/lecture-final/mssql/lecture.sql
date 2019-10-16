-- ORDERING RESULTS

-- Populations of all countries in descending order
SELECT name, population
FROM country
ORDER BY population DESC


--Names of countries and continents in ascending order
SELECT name, continent
FROM country
ORDER BY continent, name

-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
SELECT TOP 10 lifeexpectancy, name
FROM country
ORDER BY lifeexpectancy DESC

-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
SELECT name + ', ' + district AS 'City, State'
FROM city
WHERE district IN ('California', 'Washington', 'Oregon')
ORDER BY district, name

-- Showing "Order by n"
SELECT name, district
FROM city
WHERE district IN ('California', 'Washington', 'Oregon')
ORDER BY 2, 1

-- Show how ISNULL might be used...
select name, ISNULL( STR(indepyear, 20), 'Not Independent') AS 'Independence Year'
from country

-- AGGREGATE FUNCTIONS

-- Count of all countries
SELECT COUNT(*)
FROM country

-- Count of countries in Asia
SELECT COUNT(*)
FROM country
WHERE continent = 'Asia'

-- Count with distinct
SELECT COUNT(DISTINCT district) As 'Number of States'
FROM city
WHERE countrycode = 'USA'

-- Average Life Expectancy in the World
SELECT AVG(lifeexpectancy)
FROM country

-- Total population in Ohio
SELECT SUM(population)
FROM city
WHERE district = 'Ohio'

-- The surface area of the smallest country in the world
SELECT MIN(surfacearea)
FROM country

-- The 10 largest countries in the world


-- The number of countries who declared independence in 1991

-- GROUP BY

-- Population by continent
SELECT continent, SUM(  CAST(population AS bigint)  )
FROM country
GROUP BY continent
ORDER by 2 DESC

-- Count the number of countries where each language is spoken, ordered from most countries to least
SELECT language, COUNT(*) As 'Count'
FROM countrylanguage
GROUP BY language
ORDER BY Count DESC

-- Average life expectancy of each continent ordered from highest to lowest
SELECT continent, AVG(lifeexpectancy)
FROM country
GROUP BY continent
ORDER BY 2 DESC

-- Exclude Antarctica from consideration for average life expectancy
SELECT continent, AVG(lifeexpectancy)
FROM country
WHERE lifeexpectancy IS NOT NULL
GROUP BY continent
ORDER BY 2 DESC

-- Sum of the population of cities in each state in the USA ordered by state name

-- The average population of cities in each state in the USA ordered by state name

-- SUBQUERIES
-- Find the names of cities under a given government leader

SELECT * 
FROM city
WHERE countrycode IN ('ASM', 'GUM', 'MNP', 'PRI', 'UMI', 'USA', 'VIR')

SELECT * 
FROM city
WHERE countrycode IN (SELECT code FROM country WHERE headofstate = 'George W. Bush')


-- The surface area of the smallest country in the world (using a sub-query)
SELECT * 
FROM country
WHERE surfacearea = (SELECT MIN(surfacearea) FROM country)

-- Find the names of cities whose country they belong to has not declared independence yet
SELECT id, name, countrycode as code 
FROM city
WHERE countrycode IN (
	-- Subquery will find countries which have not yet declared
	SELECT code FROM country WHERE indepyear IS NULL
)

-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
