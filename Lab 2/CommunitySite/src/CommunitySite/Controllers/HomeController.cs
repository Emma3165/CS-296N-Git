using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunitySite.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            DateTime now = DateTime.Now;
            string today = now.ToString("MMMM dd, yyyy");

            ViewBag.Today = today;
            return View();
        }

        public ViewResult About()
        {
            return View();

        }

        public ViewResult History()
        {
            return View();
        }
    }
}
