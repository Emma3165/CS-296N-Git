using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eugene.Repositories;
using Eugene.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Eugene.Controllers
{
    public class ReplyController : Controller
    {
        // GET: /<controller>/
        public IActionResult ReplyForm()
        {
            return RedirectToAction("List", "Message");
        }
    }
}
