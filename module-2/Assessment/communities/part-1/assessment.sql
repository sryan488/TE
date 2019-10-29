USE assessment;
GO
SELECT * FROM properties
-- Select all the columns from communities from rows that are live
SELECT * FROM communities WHERE live = 1

-- Select the name and address from properties where the latitude is less than 0 and were created in the month of June 2019
SELECT name, address FROM properties WHERE latitude < 0 AND created BETWEEN '2019-5-1' AND '2019-5-30'

-- Select the name, latitude, and longitude from communities ordered by the created date, oldest first
SELECT name, latitude, longitude FROM communities ORDER BY created ASC

-- Select created and a count of all the properties created on each date
SELECT created, count(*)
FROM properties
GROUP BY created
ORDER BY created ASC


-- Select a community's name and live status and the address of each property for every community created on or after Oct. 1st, 2019
SELECT communities.name, live, address
FROM communities
	join properties ON communities.id = properties.id
WHERE communities.created >= '2019-10-1'