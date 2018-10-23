using Microsoft.AspNetCore.Mvc;
using Lab11MyFirstMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11MyFirstMVCApp.Controllers
{
        public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int firstYear, int lastYear)
        {
            return RedirectToAction("Result", new { firstYear, lastYear });
        }

        public ViewResult Result(int firstYear, int lastYear)
        {
            return View(PersonOfTheYear.GetPersons(firstYear, lastYear));
        }
    }
}
