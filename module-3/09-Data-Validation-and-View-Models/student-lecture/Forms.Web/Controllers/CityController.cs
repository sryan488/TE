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
            vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);

            if (vm.CountryCode != null && vm.CountryCode.Length > 0)
            {
                ViewData["Message"] = $"{vm.Cities.Count} cities were found";
            }

            // Set the CountryList property on the VM for dropdown display
            IList<Country> countries = countryDAO.GetCountries();
            vm.CountryList = new SelectList(countries, "Code", "Name");

            return View(vm);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(City city)
        {
            // TODO 07: Check model state before updating. If there are errors, return the form to the user.

            // Use the DAO to add a city
            int cityId = cityDAO.AddCity(city);

            // TODO 02b: Add a confirmation message to the user and then re-direct to the search page
            // Does it show up? Why not?

            // TODO 03: Change from ViewData to TempData (here and in Layout, and above).

            // TODO 02a: Redirect to the search page
            return RedirectToAction("ConfirmAdd");
        }

        [HttpGet]
        public IActionResult ConfirmAdd()
        {
            return View();
        }

    }
}