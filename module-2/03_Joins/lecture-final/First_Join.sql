SELECT ci.name, co.name 
FROM city ci
	JOIN country co ON ci.countrycode = co.code
WHERE ci.countrycode = 'USA'
