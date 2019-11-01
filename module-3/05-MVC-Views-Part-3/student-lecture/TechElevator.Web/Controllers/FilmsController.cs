using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class FilmsController : Controller
    {
        public IActionResult Index()
        {
            // Get a list of all Film
            MockStarWarsDAO dao = new MockStarWarsDAO();
            IList<Film> films = dao.GetFilms();

            // Pass the list of films into the View
            ViewResult viewResult = View(films);
            return viewResult;
        }

        public IActionResult Details(string id)
        {
            // Create a dao to access the "database"
            MockStarWarsDAO dao = new MockStarWarsDAO();

            // Call the method to get a single film
            Film film = dao.GetFilm(id);

            // Pass the film into the Details view
            return View(film);
        }
    }
}