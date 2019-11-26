using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReviewsAPI.Models;
using ProductReviewsAPI.Services;

namespace ProductReviewsAPI.Controllers
{
    [Route("api/reviews")] // our API is found at http://localhost:xyz/api/reviews
    [ApiController]
    public class ProductReviewsController : ControllerBase
    {
        private DataAccessObject dao;

        public ProductReviewsController(DataAccessObject dao)
        {
            this.dao = dao;
        }

        /// <summary>
        /// Returns all product reviews.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProductReview>> GetAll()
        {
            List<ProductReview> reviews = dao.GetAll();

            // Return 200 OK
            return Ok(reviews);
        }

        [HttpGet("{id}", Name = "GetReviewById")]
        public ActionResult<ProductReview> GetReviewById(int id)
        {
            // See if the review exist
            ProductReview review = dao.Get(id);

            // If it does not, return 404
            if (review == null)
            {
                return NotFound();
            }

            // If it does, return 200
            return Ok(review);
        }

        /// <summary>
        /// Deletes a product review.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // See if the review exists
            ProductReview review = dao.Get(id);

            // If it does not, return 404
            if (review == null)
            {
                return NotFound();
            }

            // Delete from the DAO
            dao.Delete(id);

            // Return 204
            return NoContent();
        }

        [HttpPost]
        public ActionResult<ProductReview> CreateNewReview([FromBody]ProductReview productReview)
        {
            // Save in the dao
            dao.Add(productReview);

            // Return 201 (with a location header: https://localhost:44359/api/reviews/{id})
            // First parameter - Name of the route to generate for API
            // Second parameter - The variables for the route
            // Third parameter - The response body
            return CreatedAtRoute("GetReviewById", new { id = productReview.Id }, productReview);
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]ProductReview productReview)
        {
            // Get the existing review
            ProductReview existingReview = dao.Get(id);
            if (existingReview == null)
            {
                // Return 404 if no found
                return NotFound();
            }

            // Copy over the fields we want to update
            existingReview.Name = productReview.Name;
            existingReview.Title = productReview.Title;
            existingReview.Review = productReview.Review;

            // Save existing review back
            dao.Update(existingReview);
            
            // Return 204
            return NoContent();
        }


    }
}