using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Recipes.DAL;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class RecipeController : RecipesBaseController
    {
        private IRecipeDAO recipeDAO = null;
        public RecipeController(IRecipeDAO recipeDAO)
        {
            this.recipeDAO = recipeDAO;
        }

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Index(string cuisine)
        {
            if (cuisine == null || cuisine.Length == 0)
            {
                cuisine = GetPreferredCuisine();
            }
            else
            {
                SetPreferredCuisine(cuisine);
            }
            return View(recipeDAO.GetRecipes(cuisine));
        }

        public IActionResult Detail(int id)
        {
            Recipe recipe = recipeDAO.GetRecipeById(id);
            if (recipe == null)
            {
                // TODO: Comment this!
                return NotFound();
            }
            return View(recipe);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Get any recipe in-progress

            Recipe recipe = GetRecipeInProgress();
            RecipeVM vm = new RecipeVM() { Recipe = recipe };
            CreateSelectLists(vm);
            return View(vm);
        }

        private bool AnyInvalid(IEnumerable<string> keys)
        {
            if (ModelState.IsValid)
            {
                return false;
            }
            foreach (string key in keys)
            {
                if (ModelState.ContainsKey(key) && ModelState[key].ValidationState == ModelValidationState.Invalid)
                {
                    return true;
                }
            }
            return false;
        }

        private void CreateSelectLists(RecipeVM vm)
        {
            vm.Cuisines = new SelectList(recipeDAO.GetCuisines());
            vm.MealTypes = new SelectList(recipeDAO.GetMealTypes());
            vm.Units = new SelectList(recipeDAO.GetUnits());
        }

        [HttpPost]
        public IActionResult Add(RecipeVM vm)
        {
            // Get the current values from Session
            Recipe recipeInProgress = GetRecipeInProgress();
            CreateSelectLists(vm);
            // Validate the fields that are on this form.  If they're no good, no sense in continuing
            string[] fieldsToValidate = {
                "Recipe.Name",
                "Recipe.Description",
                "Recipe.Meal",
                "Recipe.Cuisine",
                "Recipe.PrepTime",
                "Recipe.CookTime",
                "Recipe.Serves",
            };

            if (AnyInvalid(fieldsToValidate))
            {
                return View(vm);
            }

            // Apply values from this view to the one in the cart
            recipeInProgress.Name = vm.Recipe.Name;
            recipeInProgress.Description = vm.Recipe.Description;
            recipeInProgress.Meal = vm.Recipe.Meal;
            recipeInProgress.Cuisine = vm.Recipe.Cuisine;
            recipeInProgress.PrepTime = vm.Recipe.PrepTime;
            recipeInProgress.CookTime = vm.Recipe.CookTime;
            recipeInProgress.Serves = vm.Recipe.Serves;

            // TODO: Get the user id and put it here
            recipeInProgress.CreatedById = 1;

            SaveRecipeInProgress(recipeInProgress);

            vm.Recipe = recipeInProgress;
            // Go to the next view
            return RedirectToAction("Add2");
        }

        [HttpGet]
        public IActionResult Add2()
        {
            // Get the current values from Session
            Recipe recipe = GetRecipeInProgress();
            RecipeVM vm = new RecipeVM() { Recipe = recipe };
            CreateSelectLists(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add2(RecipeVM vm)
        {

            // Get the current values from Session
            Recipe recipeInProgress = GetRecipeInProgress();

            // Since this view does not modify the Recipe object, we'll overwrite with the data from session
            vm.Recipe = recipeInProgress;

            // Validate the fields that are on this form.  If they're no good, no sense in continuing
            string[] fieldsToValidate = {
                "NewIngredient.Name",
                "NewIngredient.Unit",
                "NewIngredient.Quantity",
            };
            if (AnyInvalid(fieldsToValidate))
            {
                CreateSelectLists(vm);
                return View(vm);
            }

            // Add the ingredients from this view to the one in the cart
            recipeInProgress.Ingredients.Add(vm.NewIngredient);

            SaveRecipeInProgress(recipeInProgress);

            // Clear the ingredient field
            vm.NewIngredient = null;

            // Stay on this view to get another ingredient
            vm = new RecipeVM()
            { Recipe = recipeInProgress };
            CreateSelectLists(vm);
            ModelState.Clear();
            return View(vm);
        }

        [HttpGet]
        public IActionResult Add3()
        {
            // Get the current values from Session
            Recipe recipe = GetRecipeInProgress();
            RecipeVM vm = new RecipeVM() { Recipe = recipe };
            CreateSelectLists(vm);
            return View(vm);
        }

        [HttpPost]
        public IActionResult Add3(RecipeVM vm)
        {
            // Get the current values from Session
            Recipe recipeInProgress = GetRecipeInProgress();

            // Validate the fields that are on this form.  If they're no good, no sense in continuing
            string[] fieldsToValidate = {
                "Recipe.Steps",
            };
            if (AnyInvalid(fieldsToValidate))
            {
                vm.Recipe = recipeInProgress;
                CreateSelectLists(vm);
                return View(vm);
            }

            //// Validate the fields that are on this form.  If they're no good, no sense in continuing
            //if (!ModelState.IsValid)
            //{
            //    if (ModelState.ContainsKey("Recipe.Steps")
            //        )
            //        return View(vm);
            //}

            // Apply values from this view to the one in the cart
            recipeInProgress.Steps = vm.Recipe.Steps;

            // Save the recipe
            int recipeId = recipeDAO.CreateRecipe(recipeInProgress);

            // Clear the Session recipe
            ClearRecipeInProgress();

            // Go to the next view
            return RedirectToAction("AddConfirmation", "Recipe", new { id = recipeId });
        }

        [HttpGet]
        public IActionResult AddConfirmation(int id)
        {
            // Get the recipe given the new id
            Recipe recipe = recipeDAO.GetRecipeById(id);
            return View(recipe);
        }

        [HttpPost]
        public IActionResult ClearRecipe()
        {
            // Clear the Session recipe
            ClearRecipeInProgress();
            SetMessage("Add Recipe was cancelled!");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Preferences()
        {
            Preferences pref = new Preferences()
            {
                Cuisine = GetPreferredCuisine()
            };
            return View(pref);
        }

        [HttpPost]
        public IActionResult Preferences(Preferences pref)
        {
            SetPreferredCuisine(pref.Cuisine);
            return RedirectToAction("Index", "Home");
        }

        private void SaveRecipeInProgress(Recipe recipe)
        {
            // Convert the Recipe object to a string using the JSON library
            string json = JsonConvert.SerializeObject(recipe);

            // Put the string into session under the key="RecipeInProgress"
            HttpContext.Session.SetString("RecipeInProgress", json);
        }

        private void ClearRecipeInProgress()
        {
            // Put the string into session under the key="RecipeInProgress"
            HttpContext.Session.Remove("RecipeInProgress");
        }

        private Recipe GetRecipeInProgress()
        {
            Recipe recipe = null;

            // Get the serialized json string from the session, key="Cart"
            string json = HttpContext.Session.GetString("RecipeInProgress");

            if (json == null)
            {
                recipe = new Recipe();
            }
            else
            {
                // De-serialize the json string into a SC object
                recipe = JsonConvert.DeserializeObject<Recipe>(json);
            }
            return recipe;
        }

    }
}