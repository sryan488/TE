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
        /// Returns all prouct reviews.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public ActionResult<List<ProductReview>> GetAll()
        {
            List<ProductReview> reviews = dao.GetAll();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductReview> GetReviewById(int id)
        {
            ProductReview review = dao.Get(id);

            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            ProductReview review = dao.Get(id);

            if (review == null)
            {
                return NotFound();
            }

            dao.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<ProductReview> CreateNewReview([FromBody]ProductReview productReview)
        {
            dao.Add(productReview);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]ProductReview productReview)
        {
            ProductReview existingReview = dao.Get(id);
            if(existingReview == null)
            {
                return NotFound();
            }

            //Copy over the fields we want to update
            existingReview.Name = productReview.Name;
            existingReview.Title = productReview.Title;
            existingReview.Review = productReview.Review;

            //Save existing review back
            dao.Update(existingReview);

            return NoContent();
        }

    }
}