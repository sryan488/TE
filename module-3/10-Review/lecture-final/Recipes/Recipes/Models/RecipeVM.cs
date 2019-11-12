using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class RecipeVM
    {
        public Recipe Recipe { get; set; }

        public Ingredient NewIngredient { get; set; }

        // Select Lists for views
        public SelectList Cuisines { get; set; }
        public SelectList MealTypes { get; set; }
        public SelectList Units { get; set; }

    }
}
