using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommunityApp.Repositories;
using CommunityApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunityApp.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRepository messageRepo;
        public MessageController(IMessageRepository repo)
        {
            messageRepo = repo;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult MessagesByMember(Member member)
        {
            MessageRepository repo = new MessageRepository();
            MemberRepository mem = new MemberRepository();

            repo.GetMessagesByMember(member);
            return View(repo);
        }
    }
}
