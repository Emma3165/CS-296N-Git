using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eugene.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Eugene.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepository memberRepo;


        public MemberController(IMemberRepository repo)
        {
            memberRepo = repo;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public ViewResult Index()
        {
            var repo = new MemberRepository();
            var members = repo.GetAllMemberAlphabetic();
            return View(members);
        }
    }
}
