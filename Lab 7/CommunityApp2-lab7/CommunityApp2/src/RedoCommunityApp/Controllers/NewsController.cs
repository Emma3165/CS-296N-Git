using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedoCommunityApp.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RedoCommunityApp.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public ViewResult Index()
        {
            List<News> news = new List<News>();
            News n2 = new News();
            n2.Title = "Free Willie";
            n2.Date = new DateTime(2016, 11, 30);
            n2.Story = "Willie is free Yaaaaaaaaaaaaaaaaaaaaay!!!!";
                

            return View(n2);
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
