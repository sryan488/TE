using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recipes.Controllers
{
    public abstract class RecipesBaseController : Controller
    {
        private const string cuisineSessionKey = "PreferredCuisine";
        protected string GetPreferredCuisine()
        {
            return HttpContext.Session.GetString(cuisineSessionKey) ?? "";
        }

        protected void SetPreferredCuisine(string cuisine)
        {
            if (cuisine == null || cuisine.Trim().Length == 0)
            {
                ClearPreferredCuisine();
            }
            else
            {
                HttpContext.Session.SetString(cuisineSessionKey, cuisine);
            }
        }

        protected void ClearPreferredCuisine()
        {
            HttpContext.Session.Remove(cuisineSessionKey);
        }

        protected void SetMessage(string message)
        {
            TempData["message"] = message;
        }
    }
}