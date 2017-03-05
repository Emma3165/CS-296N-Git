using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunitySite.Controllers;
using CommunitySite.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunitySite.Controllers
{
    public class NewsController : Controller
    {
        // GET: /<controller>/
        public IActionResult News()
        {
            News[] storys = 
            {
                new News
                {
                    Title = "Webster Attacked!",
                    Date = "Dec 21, 2016",
                    Story = "Our beloved hound dog Webster was injured today. Everyone please remeber to keep an eye on your dogs behaviour and intervene when needed."
                },
                new News
                {
                    Title = "Reading dog body language.",
                    Date = "Dec 22, 2016",
                    Story = "Check out this handy guide, http://www.akc.org/content/dog-training/articles/how-to-read-dog-body-language/"
                }
            };

        
            return View(storys);
        }

        [Route("/News/Archive/")]
        public ViewResult Archive()
        {
            return View();
        }
    }
}
