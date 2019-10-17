-- The following queries utilize the "dvdstore" database.

-- 1. All of the films that Nick Stallone has appeared in
-- (30 rows)
SELECT a.first_name, a.last_name, f.title
FROM film f
	JOIN film_actor fa ON f.film_id = fa.film_id
	JOIN actor a ON fa.actor_id = a.actor_id
WHERE a.first_name = 'Nick' AND a.last_name = 'Stallone'

-- 2. All of the films that Rita Reynolds has appeared in
-- (20 rows)
SELECT a.first_name, a.last_name, f.title
FROM film f
	JOIN film_actor fa ON f.film_id = fa.film_id
	JOIN actor a ON fa.actor_id = a.actor_id
WHERE a.first_name = 'Rita' AND a.last_name = 'Reynolds'

-- 3. All of the films that Judy Dean or River Dean have appeared in
-- (46 rows)
SELECT a.first_name, a.last_name, f.title
FROM film f
	JOIN film_actor fa ON f.film_id = fa.film_id
	JOIN actor a ON fa.actor_id = a.actor_id
WHERE a.first_name = 'Judy' AND a.last_name = 'Dean' OR a.first_name = 'River' AND a.last_name = 'Dean'

-- 4. All of the the ‘Documentary’ films
-- (68 rows)
SELECT f.title Title, c.name Category
FROM film f 
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
WHERE c.name = 'Documentary'

-- 5. All of the ‘Comedy’ films
-- (58 rows)
SELECT f.title Title, c.name Category
FROM film f 
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
WHERE c.name = 'Comedy'

-- 6. All of the ‘Children’ films that are rated ‘G’
-- (10 rows)
SELECT f.title Title, c.name Category
FROM film f 
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
WHERE c.name = 'Children' AND f.rating = 'G'


-- 7. All of the ‘Family’ films that are rated ‘G’ and are less than 2 hours in length
-- (3 rows)
SELECT f.title Title, c.name Category
FROM film f 
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
WHERE c.name = 'Family' AND f.rating = 'G' AND f.length < 120


-- 8. All of the films featuring actor Matthew Leigh that are rated ‘G’
-- (9 rows)
SELECT a.first_name, a.last_name, f.title
FROM film f
	JOIN film_actor fa ON f.film_id = fa.film_id
	JOIN actor a ON fa.actor_id = a.actor_id
WHERE a.first_name = 'Matthew' AND a.last_name = 'Leigh' AND f.rating = 'G'


-- 9. All of the ‘Sci-Fi’ films released in 2006
-- (61 rows)
SELECT f.title Title, c.name Category
FROM film f 
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
WHERE c.name = 'Sci-Fi' AND f.release_year = '2006'


-- 10. All of the ‘Action’ films starring Nick Stallone
-- (2 rows)
SELECT a.first_name, a.last_name, f.title
FROM film f
	JOIN film_actor fa ON f.film_id = fa.film_id
	JOIN actor a ON fa.actor_id = a.actor_id
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
WHERE a.first_name = 'Nick' AND a.last_name = 'Stallone' AND c.name = 'Action'

-- 11. The address of all stores, including street address, city, district, and country
-- (2 rows)
SELECT ad.address, ci.city, ad.district, co.country
FROM store s
	JOIN address ad ON s.address_id = ad.address_id
	JOIN city ci ON ad.city_id = ci.city_id
	JOIN country co ON ci.country_id = co.country_id


-- 12. A list of all stores by ID, the store’s street address, and the name of the store’s manager
-- (2 rows)
SELECT s.store_id, ad.address, sta.first_name, sta.last_name
FROM store s
	JOIN address ad ON s.address_id = ad.address_id
	JOIN staff sta ON sta.staff_id = s.manager_staff_id

-- 13. The first and last name of the top ten customers ranked by number of rentals 
-- (#1 should be “ELEANOR HUNT” with 46 rentals, #10 should have 39 rentals)
SELECT TOP 10 cu.first_name, cu.last_name, COUNT(r.rental_id) rentals
FROM rental r
	JOIN customer cu ON cu.customer_id = r.customer_id
GROUP BY cu.first_name, cu.last_name
ORDER BY rentals DESC

-- 14. The first and last name of the top ten customers ranked by dollars spent 
-- (#1 should be “KARL SEAL” with 221.55 spent, #10 should be “ANA BRADLEY” with 174.66 spent)
SELECT TOP 10 cu.first_name, cu.last_name, SUM(p.amount) amount
FROM payment p
	JOIN customer cu ON p.customer_id = cu.customer_id
GROUP BY cu.first_name, cu.last_name
ORDER BY amount DESC


-- 15. The store ID, street address, total number of rentals, total amount of sales (i.e. payments), and average sale of each store 
-- (Store 1 has 7928 total rentals and Store 2 has 8121 total rentals)
SELECT s.store_id, ad.address, COUNT(r.rental_id) 'Total Number of Rentals', SUM(p.amount) 'Total amount of sales' , AVG(p.amount) 'Average sale of each store'
FROM store s
	 JOIN address ad ON s.address_id = ad.address_id
	 JOIN inventory i ON s.store_id = i.store_id
	 JOIN rental r ON i.inventory_id = r.inventory_id
	 JOIN payment p ON r.rental_id = p.rental_id
GROUP BY s.store_id, ad.address
ORDER BY s.store_id ASC


-- 16. The top ten film titles by number of rentals
-- (#1 should be “BUCKET BROTHERHOOD” with 34 rentals and #10 should have 31 rentals)
SELECT TOP 10 f.title, COUNT(*) rental
FROM rental r
	JOIN inventory i ON r.inventory_id = i.inventory_id
	JOIN film f ON i.film_id = f.film_id
GROUP BY f.title
ORDER BY rental DESC

-- 17. The top five film categories by number of rentals 
-- (#1 should be “Sports” with 1179 rentals and #5 should be “Family” with 1096 rentals)
SELECT TOP 5 c.name, COUNT(*) rental
FROM rental r
	JOIN inventory i ON r.inventory_id = i.inventory_id
	JOIN film f ON i.film_id = f.film_id
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
GROUP BY c.name
ORDER BY rental DESC


-- 18. The top five Action film titles by number of rentals 
-- (#1 should have 30 rentals and #5 should have 28 rentals)
SELECT TOP 5 f.title, COUNT(*) rental, c.name
FROM rental r
	JOIN inventory i ON r.inventory_id = i.inventory_id
	JOIN film f ON i.film_id = f.film_id
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
WHERE c.name = 'Action'
GROUP BY f.title, c.name
ORDER BY rental DESC

-- 19. The top 10 actors ranked by number of rentals of films starring that actor 
-- (#1 should be “GINA DEGENERES” with 753 rentals and #10 should be “SEAN GUINESS” with 599 rentals)
SELECT TOP 10 a.first_name, a.last_name, COUNT(*) rental
FROM rental r
	JOIN inventory i ON r.inventory_id = i.inventory_id
	JOIN film f ON i.film_id = f.film_id
	JOIN film_actor fa ON f.film_id = fa.film_id
	JOIN actor a ON fa.actor_id = a.actor_id
GROUP BY a.first_name, a.last_name, a.actor_id
ORDER BY rental DESC

-- 20. The top 5 “Comedy” actors ranked by number of rentals of films in the “Comedy” category starring that actor 
-- (#1 should have 87 rentals and #5 should have 72 rentals)
SELECT TOP 5 a.first_name, a.last_name, COUNT(*) rental, c.name
FROM rental r
	JOIN inventory i ON r.inventory_id = i.inventory_id
	JOIN film f ON i.film_id = f.film_id
	JOIN film_category fc ON f.film_id = fc.film_id
	JOIN category c ON fc.category_id = c.category_id
	JOIN film_actor fa ON f.film_id = fa.film_id
	JOIN actor a ON fa.actor_id = a.actor_id
WHERE c.name = 'Comedy'
GROUP BY a.first_name, a.last_name, fa.actor_id, c.name
ORDER BY rental DESC
