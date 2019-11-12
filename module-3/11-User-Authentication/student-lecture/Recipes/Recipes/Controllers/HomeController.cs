using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Recipes.DAL;
using Recipes.Models;
using Recipes.Providers.Auth;

namespace Recipes.Controllers
{
    /**********************
     * 
     * TASK LIST:
     * 
     * TODO: Store and get preferences from Session
     * TODO: Document EVERYTHING!!!
     * TODO: Add tests for controllers
     * TODO: Create a base controller class, if I need preferences in multiple places
     * TODO: Create a Partial View to prompt for preferences
     * TODO: Use session for the Add wizard
     * TODO: Add model validation for the Add wizard
     * TODO: SelectList for Cuisines (and maybe meals) (and maybe Unit of Measure)
     * TODO: Default meal to the time of day
     * 
     *********************/
    public class HomeController : RecipesBaseController
    {
        private IRecipeDAO recipeDAO = null;
        public HomeController(IRecipeDAO recipeDAO, IAuthProvider authProvider) : base(authProvider)
        {
            this.recipeDAO = recipeDAO;
        }

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Index()
        {
            Preferences pref = new Preferences()
            {
                Cuisine = GetPreferredCuisine(),

            };
            pref.Cuisines = new SelectList(recipeDAO.GetCuisines());
            return View(pref);
        }

        [HttpGet]
        public IActionResult Preferences()
        {
            Preferences pref = new Preferences()
            {
                Cuisine = GetPreferredCuisine(),
                
            };
            pref.Cuisines = new SelectList(recipeDAO.GetCuisines());
            return View(pref);
        }

        [HttpPost]
        public IActionResult Preferences(Preferences pref)
        {
            if (pref.Cuisine == null || pref.Cuisine.Length == 0)
            {
                ClearPreferredCuisine();
            }
            SetPreferredCuisine(pref.Cuisine);
            SetMessage($"Your preferred cuisine is now {(pref.Cuisine == null || pref.Cuisine == "" ? "Anything" : pref.Cuisine)}. Visit the Preferences page to change it.");
            return RedirectToAction("Index", "Recipe");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // TODO: Protect the Admin page for only Authorized Admins
        public IActionResult Admin()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
