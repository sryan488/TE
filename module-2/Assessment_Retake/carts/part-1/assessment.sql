USE assessment;
GO

SELECT * FROM carts

SELECT * FROM items

-- Select all the columns in cart where the username is kmilner1j
SELECT * FROM carts WHERE username = 'kmilner1j'

-- Select the id and name columns from items where the item was added on or after Jan. 15, 2019 and the weight is null
SELECT id, name FROM items WHERE added >= '2019-01-15' AND weight IS NULL

-- Select username and the cookie_value from carts where the username isn't null, ordered by the created date, latest first
SELECT username, cookie_value FROM carts WHERE username IS NOT NULL ORDER BY created DESC

-- Select the added date and the count of all the items added on that date
SELECT added, COUNT(*) FROM items GROUP BY added ORDER BY added ASC

-- Select the cart's username and created date and the item's name for all carts created in the month of Sept. 2019
SELECT carts.username AS Username, carts.created AS 'Created date', items.name AS 'Item name' FROM carts JOIN items ON carts.id = items.id WHERE carts.created BETWEEN '2019-9-1' AND '2019-9-30'
