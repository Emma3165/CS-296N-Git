using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eugene.Models;


namespace Eugene.Controllers
{
    public class NewsController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }

       
        public IActionResult TodayNews()
        {

            ViewBag.Title = "Trump Inauguration";
            ViewBag.Story = "Trup Inauguration has less crowd than woman march";

            return View();
        }
       
        public IActionResult Archive()
        {
            return View();
        }
    }
}