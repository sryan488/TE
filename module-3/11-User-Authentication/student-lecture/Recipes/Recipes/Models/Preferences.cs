using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    // TODO: Model validation
    public class Preferences
    {
        public string Cuisine { get; set; }
        public SelectList Cuisines { get; set; }
    }
}
