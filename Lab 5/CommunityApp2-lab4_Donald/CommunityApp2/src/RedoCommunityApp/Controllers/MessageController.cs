using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedoCommunityApp.Repositories;
using RedoCommunityApp.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RedoCommunityApp.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRepository messageRepo;
        public MessageController(IMessageRepository repo)
        {
            messageRepo = repo;
        }
        // GET: /<controller>/
        

        public ViewResult MessagesByMember(Member member)
        {
           

           var messages =  messageRepo.GetMessagesByMember(member);
            return View(messages);
        }

        public ViewResult Index()
        {
            
            
            var messages = messageRepo.GetAllMessages();
            return View(messages);
        }
    }
}
