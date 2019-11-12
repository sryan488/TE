using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{

    // TODO: Model validation
    public class Ingredient
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
