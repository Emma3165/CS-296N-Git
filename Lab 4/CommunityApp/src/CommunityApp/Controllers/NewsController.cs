using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityApp.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityApp.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<News> news = new List<News>();
            var n1 = new News();
            n1.Title = "Free Willie";
            n1.Date = new DateTime(2016, 11, 30);
            n1.Story = "Willie is free Yaaaaaaaaaaaaaaaaaaaaay!!!!";
                

            return View(n1);
        }
        [HttpGet]
        public IActionResult Archive()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TodayNews()
        {
            return View();
        }


    }
}
