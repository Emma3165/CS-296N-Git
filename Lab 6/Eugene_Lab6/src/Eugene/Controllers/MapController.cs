using System;
using Microsoft.AspNetCore.Mvc;


namespace Eugene.Controllers
{
    public class MapController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}