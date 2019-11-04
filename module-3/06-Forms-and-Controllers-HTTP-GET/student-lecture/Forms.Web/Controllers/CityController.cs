using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms.Web.Controllers
{
    public class CityController : Controller
    {

        /**** DEPENDENCY INJECTION *****/
        // TODO 01: Implement DI by creating contructor arguments and saving off the DAOs in a private variable.
        // Also, get rid of the connection string
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=World;Integrated Security=True";

        private ICityDAO cityDAO;
        public CityController()
        {
            this.cityDAO = new CitySqlDAO(connectionString);
        }

        public IActionResult Index()
        {
            IList<City> cities = cityDAO.GetCities();
            return View(cities);
        }

        // TODO 02: Write the SearchResults action (string countryCode, string district) to do the work of searching for a city. 
        // TODO 03: Create a SearchResults view to display the results of the search
        //          We should be able to run the search using the browser's address bar
        // TODO 04: Since we copied the table from the Index view, let's replace both with a call to a partial view



        // TODO 05: Create a Search Action and View, which presents the user with a search form (countryCode, district) 
        //          (pure HTML - GET). Action=searchresults
        // TODO 06a:DEMO: Run the form and see what is sent by the browser (using browser dev tools).
        //          We should get search results.
        // TODO 06b:DEMO: Change the form to POST and compare the payloads.  Change back to GET for today.


        // TODO 07: Model Binding: Create a CitySearchVM model object to hold all the parameters. 
        //          Change the Action to accept the model as a parameter (model binding). 
        //          Send the model to the view, and update the view.
        
        // TODO 08: Use asp-helper tags to re-write the form.
        
        // TODO 09: If time allows, re-write the actions to show the form AND display the results
        //          Call the partial view here also
            /*** 
             * TODO 09a: Combine the Search action with the SearchResult action.
             *  1. Add a vm parameter to this action
             *  2. If the vm is null, just display the search form.
             *  3. If the vm is not null, then a search has been submitted. Perform the search 
             *      and display the results.
             ***/

        // TODO 10: If time allows, add a SelectList to the view-model for country codes. 
        //          Generate Select List from the Country DAO. (GetCountrySelectList)
        //          This will require us to ask for another "injected" DAO

        /****
         * TODO 11: Write tests for the CityController.
         *      Show how the Mock objects are used to 1) remove integration from the tests, and 2) control the 
         *      data we want to test for.
         ****/
    }
}