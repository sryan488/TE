using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GETForms.Web.Controllers
{
    public class FilmsController : Controller
    {
        private IFilmDAO filmDAO;
        public FilmsController(IFilmDAO filmDAO)
        {
            this.filmDAO = filmDAO;
        }

        /// <summary>
        /// The request to display an empty search page.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            FilmSearchVM vm = new FilmSearchVM();
            IList<string> Genres = filmDAO.GetGenres();
            vm.GenreList = new SelectList(Genres);

            return View(vm);
        }

        public IActionResult Search(FilmSearchVM vm)
        {
            IList<string> Genres = filmDAO.GetGenres();
            vm.GenreList = new SelectList(Genres);

            return View(vm);
        }



        /// <summary>
        /// Receives the search result request and goes to th database looking for the information.
        /// </summary>
        /// <param name="request">A request model that contains the search parameters.</param>
        /// <returns></returns>
        public IActionResult SearchResult(string Genre, int MinLength, int MaxLength)
        {
            /* Call the DAL and pass the values as a model back to the View */
            IList<Film> films = filmDAO.GetFilmsBetween(Genre, MinLength, MaxLength);
            return View(films);
        }
    }
}