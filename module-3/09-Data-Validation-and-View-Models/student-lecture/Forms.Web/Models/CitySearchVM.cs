using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CitySearchVM
    {
        // Data Labels: Use Data Annotations to set the display name so they show in the view
        [Display(Name = "Country", Description = "Enter a country code")]
        public string CountryCode { get; set; }

        [Display(Name = "District (e.g., State)")]
        public string District { get; set; }
        public IList<City> Cities { get; set; }

        // SelectList for the Country List dropdown to the VM
        public SelectList CountryList { get; set; }
    }
}
