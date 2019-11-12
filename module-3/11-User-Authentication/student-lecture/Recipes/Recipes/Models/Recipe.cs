using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    // TODO: Model validation
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CreatedById { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Steps { get; set; }


        [Required]
        public string Meal { get; set; }
        [Required]
        public string Cuisine { get; set; }
        public string ImageFile { get; set; }

        [Range(1, int.MaxValue)]
        public int PrepTime { get; set; }

        [Range(0, 360)]
        public int CookTime { get; set; }
        
        [Range(1,24)]
        public int Serves { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
            this.Ingredients = new List<Ingredient>();
        }
    }
}
