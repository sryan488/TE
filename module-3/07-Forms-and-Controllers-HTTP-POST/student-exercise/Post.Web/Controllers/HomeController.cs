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
    public class HomeController : Controller
    {

        private IReviewDAO ReviewSqlDAO;
        public HomeController(IReviewDAO reviewSqlDAO)
        {
            this.ReviewSqlDAO = reviewSqlDAO;
        }


        // GET: Home
        public IActionResult Index()
        {
            IList<Review> reviews = ReviewSqlDAO.GetAllReviews();
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
            ReviewSqlDAO.SaveReview(review);

            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
