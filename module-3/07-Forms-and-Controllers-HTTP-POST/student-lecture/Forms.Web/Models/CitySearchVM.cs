using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CitySearchVM
    {
        // TODO 02: Data Labels: Use Data Annotations to set the display name so they show in the view
        public string CountryCode { get; set; }
        public string District { get; set; }
        public IList<City> Cities { get; set; }

        // TODO 03: Add a SelectList for the Country List dropdown to the VM
    }
}
