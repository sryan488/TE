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
using Recipes.Providers.Auth;

namespace Recipes.Controllers
{
    public class RecipeController : RecipesBaseController
    {
        // Dependency Injection
        private IRecipeDAO recipeDAO = null;
        public RecipeController(IRecipeDAO recipeDAO, IAuthProvider authProvider) : base(authProvider)
        {
            this.recipeDAO = recipeDAO;
        }

        /// <summary>
        /// /recipe/index
        /// Displays a list of recipes based on the cuisine passed in, of the user's preferred cuisine
        /// </summary>
        /// <param name="cuisine">A string that is the cuisine to show</param>
        /// <returns></returns>
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Index(string cuisine)
        {
            if (cuisine == null || cuisine.Length == 0)
            {
                // Calls the base class method that gets the user's preferrred cuisine from session state
                cuisine = GetPreferredCuisine();
            }
            else
            {
                // Calls the base class method that sets the user's preferrred cuisine into session state
                SetPreferredCuisine(cuisine);
            }

            // Call the DAO to get Recipes, and pass the list into the view
            return View(recipeDAO.GetRecipes(cuisine));
        }

        /// <summary>
        /// Shows detail for a single recipe
        /// </summary>
        /// <param name="id">Id of the recipe to show</param>
        /// <returns></returns>
        public IActionResult Detail(int id)
        {
            // Use the DAO to get the recipe
            Recipe recipe = recipeDAO.GetRecipeById(id);
            if (recipe == null)
            {
                // Recipe not found - 404
                return NotFound();
            }

            // Recipe was found. Invode the Detail view to show it.
            return View(recipe);
        }

        /// <summary>
        /// Add a new Recipe to the database. This starts the 3-page "wizard" for adding a Recipe
        /// </summary>
        /// <returns></returns>

        // TODO: You can only Add a recipe if you are logged in
        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            // Get any recipe in-progress
            Recipe recipe = GetRecipeInProgress();

            // Create and Initialize the ViewModel to be used in the View
            RecipeVM vm = new RecipeVM() { Recipe = recipe };
            // Set the SelectList values in the ViewModel (Cuisine, MealType, UOM)
            CreateSelectLists(vm);

            // Invoke the View
            return View(vm);
        }

        /// <summary>
        /// This is the Post of the first page of the Add wizard.
        /// </summary>
        /// <param name="vm">ViewModel posted from the first form</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(RecipeVM vm)
        {
            // Get the current values from Session
            Recipe recipeInProgress = GetRecipeInProgress();

            // Set the SelectList values in the ViewModel (Cuisine, MealType, UOM)
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

            // Save the work-in-progress into Session
            SaveRecipeInProgress(recipeInProgress);

            vm.Recipe = recipeInProgress;
            // Go to the next view
            return RedirectToAction("Add2");
        }

        /// <summary>
        /// Page 1 re-directs to this GET for page 2
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add2()
        {
            // Get the current values from Session and set up the ViewModel
            Recipe recipe = GetRecipeInProgress();
            RecipeVM vm = new RecipeVM() { Recipe = recipe };
            CreateSelectLists(vm);
            return View(vm);
        }

        /// <summary>
        /// The POST for page 2. As the user adds ingredients, this method is called
        /// </summary>
        /// <param name="vm">The ViewModel coming from the post of page 2</param>
        /// <returns></returns>
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
                // If there are validation errors (in the ingrdients), re-show the view so the user sees the errors.
                CreateSelectLists(vm);
                return View(vm);
            }

            // Add the ingredients from this view to the one in the cart
            recipeInProgress.Ingredients.Add(vm.NewIngredient);

            // Store the work-in-progress to Session
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

        /// <summary>
        /// If the user presses Done on page 2, we GET page 3
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Add3()
        {
            // Get the current values from Session
            Recipe recipe = GetRecipeInProgress();
            RecipeVM vm = new RecipeVM() { Recipe = recipe };
            CreateSelectLists(vm);
            return View(vm);
        }

        /// <summary>
        /// The POST of page 3 completes the Add
        /// </summary>
        /// <param name="vm">The ViewModel for the fields posted in page 3 (steps)</param>
        /// <returns></returns>
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
                // If there are any validation errors, re-show the view to the user
                vm.Recipe = recipeInProgress;
                CreateSelectLists(vm);
                return View(vm);
            }

            // Apply values from this view to the one in the cart
            recipeInProgress.Steps = vm.Recipe.Steps;

            // Save the recipe
            int recipeId = recipeDAO.CreateRecipe(recipeInProgress);

            // Clear the Session recipe
            ClearRecipeInProgress();

            // Go to the next view
            return RedirectToAction("AddConfirmation", "Recipe", new { id = recipeId });
        }

        /// <summary>
        /// Once the Add completes, we re-direct to the confirmation page (PRG)
        /// </summary>
        /// <param name="id">The id of the newly added recipe</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddConfirmation(int id)
        {
            // Get the recipe given the new id
            Recipe recipe = recipeDAO.GetRecipeById(id);
            return View(recipe);
        }

        /// <summary>
        /// Given a list of fields that exist in a Model, return true if ANY of those fields violate
        /// the constraints (Data Annotations) defined in the Model.  We must do this (field by field)
        /// because not all of our model fields are going to be displayed in each view.
        /// </summary>
        /// <param name="keys">A list of field names (from the Model) on the form</param>
        /// <returns>True if the are any validation errors, false if not.</returns>
        private bool AnyInvalid(IEnumerable<string> keys)
        {
            // If EVERYTHING in the model is valid, there is no need to look field-by-field
            if (ModelState.IsValid)
            {
                return false;
            }

            // There are some validation errors. Check each field in the list to see if there are validations 
            // related to that field.
            foreach (string key in keys)
            {
                if (ModelState.ContainsKey(key) && ModelState[key].ValidationState == ModelValidationState.Invalid)
                {
                    return true;
                }
            }
            return false;
        }

        // Set all the SelectLists from the DAO, into the given ViewModel
        private void CreateSelectLists(RecipeVM vm)
        {
            vm.Cuisines = new SelectList(recipeDAO.GetCuisines());
            vm.MealTypes = new SelectList(recipeDAO.GetMealTypes());
            vm.Units = new SelectList(recipeDAO.GetUnits());
        }

        /// <summary>
        /// If the user presses CANCEL on Add page 1, Clear the Recipe from session
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult ClearRecipe()
        {
            // Clear the Session recipe
            ClearRecipeInProgress();
            SetMessage("Add Recipe was cancelled!");
            return RedirectToAction("Index");
        }

        /// <summary>
        /// GET and Show the Preferences page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Preferences()
        {
            Preferences pref = new Preferences()
            {
                Cuisine = GetPreferredCuisine()
            };
            return View(pref);
        }

        /// <summary>
        /// POST and save the preferences
        /// </summary>
        /// <param name="pref"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Preferences(Preferences pref)
        {
            SetPreferredCuisine(pref.Cuisine);
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Serialize the given Recipe and store the serialized string into session
        /// </summary>
        /// <param name="recipe">Recipe to "save" into Session</param>
        private void SaveRecipeInProgress(Recipe recipe)
        {
            // Convert the Recipe object to a string using the JSON library
            string json = JsonConvert.SerializeObject(recipe);

            // Put the string into session under the key="RecipeInProgress"
            HttpContext.Session.SetString("RecipeInProgress", json);
        }

        /// <summary>
        /// Remove the serialized Recipe from Session
        /// </summary>
        private void ClearRecipeInProgress()
        {
            // Put the string into session under the key="RecipeInProgress"
            HttpContext.Session.Remove("RecipeInProgress");
        }

        /// <summary>
        /// Read the serialized string from Session, and de-serialize to "rehydrate" the Recipe in progress
        /// </summary>
        /// <returns></returns>
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