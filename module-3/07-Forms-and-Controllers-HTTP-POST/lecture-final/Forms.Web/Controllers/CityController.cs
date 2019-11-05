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
        // Implement DI by creating contructor arguments and saving off the DAOs in a private variable.
        private ICityDAO cityDAO;
        private ICountryDAO countryDAO;
        public CityController(ICityDAO cityDAO, ICountryDAO countryDAO)
        {
            this.cityDAO = cityDAO;
            this.countryDAO = countryDAO;
        }

        public IActionResult Index()
        {
            IList<City> cities = cityDAO.GetCities();
            return View(cities);
        }

        public IActionResult Search(CitySearchVM vm)
        {
            // TODO 01: See View City\Search.cshtml and update labels

            vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);

            // TODO 05: Set the CountryList property on the VM for dropdown display
            IList<Country> countries = countryDAO.GetCountries();
            vm.CountryList = new SelectList(countries, "Code", "Name");


            //List<SelectListItem> selectListItems = new List<SelectListItem>();
            //selectListItems.Add(new SelectListItem("Saturn", "Saturn"));

            return View(vm);
        }

        public IActionResult SearchResults(string countryCode, string district)
        {
            IList<City> cities = cityDAO.GetCities(countryCode, district);
            return View(cities);
        }

        // TODO 04: Add method GetCountrySelectList and
        //          Generate Select List from the Country DAO.
        //          This will require us to ask for another "injected" DAO


        // TODO 06: Create the AddCity action. Use the Post-Redirect-Get pattern to prevent double-adds
        //      [Get] Add() - Shows the Add view
        //      [Post] Add(City) - Accepts form contents, adds the city, and redirects to the confirmation page
        //      [Get] ConfirmAdd(int id) - Displays a confirmation message to the user.
        //    
        

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(City city)
        {
            // Use the DAO to add a city
            cityDAO.AddCity(city);

            // Redirect to the Confirmation page
            return RedirectToAction("ConfirmAdd");
        }

        [HttpGet]
        public IActionResult ConfirmAdd()
        {
            return View();
        }

        // TODO 07: Add a link to the navigation menu for Add City


        // TODO BONUS: create an Action and View for Detail
        // TODO BONUS: create an Action and View for Update
        // TODO BONUS: create an Action and View for Delete


    }
}