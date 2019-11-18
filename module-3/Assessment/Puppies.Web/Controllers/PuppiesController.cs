using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Puppies.Web.DAL;
using Puppies.Web.Models;

namespace Puppies.Web.Controllers
{
    public class PuppiesController : Controller
    {
        private IPuppyDao puppyDao;

        public PuppiesController(IPuppyDao puppyDao)
        {
            this.puppyDao = puppyDao;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Puppy> puppies = puppyDao.GetPuppies();
            return View(puppies);
        }

        public IActionResult Detail(int id)
        {
            Puppy puppy = puppyDao.GetPuppy(id);
            return View(puppy);

        }

        [HttpPost]
        public IActionResult SavePuppy(Puppy newPuppy)
        {
            puppyDao.SavePuppy(newPuppy); 

            return RedirectToAction("Index");
        }
    }
}
