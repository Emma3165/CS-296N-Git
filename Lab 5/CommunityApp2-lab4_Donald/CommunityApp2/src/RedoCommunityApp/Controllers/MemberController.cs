using Microsoft.AspNetCore.Mvc;
using RedoCommunityApp.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RedoCommunityApp.Controllers
{
    public class MemberController : Controller
    {
        private IMemberRepository memberRepo;

        public MemberController(IMemberRepository repo)
        {
            memberRepo = repo;
        }
        // GET: /<controller>/
        public ViewResult Index()
        {
            var members = memberRepo.GetAllMembers();
            return View(members);
        }

        public ViewResult MemberByEmail(string email)
        {
            var member = memberRepo.GetMemberByEmail(email);
            return View(member);
        }
    }
}
