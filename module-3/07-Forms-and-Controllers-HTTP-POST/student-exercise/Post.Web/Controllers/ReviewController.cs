using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post.Web.DAL;
using Post.Web.Models;

namespace Post.Web.Controllers
{
    public class ReviewController : Controller
    {
        private IReviewDAO reviewSqlDAO;
        public ReviewController(IReviewDAO reviewSqlDAO)
        {
            this.reviewSqlDAO = reviewSqlDAO;
        }


        // GET: Home
        public IActionResult Index()
        {
            IList<Review> reviews = reviewSqlDAO.GetAllReviews();
            return View(reviews);
        }

        [HttpGet]
        public ActionResult NewReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewReview(Review review)
        {
            reviewSqlDAO.SaveReview(review);

            return RedirectToAction("Index");
        }
    }
}