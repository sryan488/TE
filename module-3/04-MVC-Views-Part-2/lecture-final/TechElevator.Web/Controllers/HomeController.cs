using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechElevator.Web.Controllers
{
    public class HomeController : Controller
    {

        /****
         * TODO 01: Add an About page to the Home Controller
         * TODO 02: Add navigation for the Home and About page
         * TODO 03: Add a Films controller
         * TODO 04: Add an Index page to list all the files
         * TODO 05: Add a navigation to the Films/Index page
         * TODO 06: Add a Details page to show a single film
         * TODO 07: Add links from the Index page items to the Details page
         * TODO 08: Add an aside to the _Layout, and to the Films/Index and Films/Details page
         * 
        ****/
        public IActionResult Index()
        {
            return View();
        }
    }
}