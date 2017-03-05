using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace Eugene.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {

            ViewBag.Date = DateTime.Now;
            ViewBag.Temp = 42;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [Route("Home/About/Contact")]
        public IActionResult Contact()
        {

            return View("Contact");
        }

        public IActionResult History()
        {
            return View("History");
        }

    }
}
