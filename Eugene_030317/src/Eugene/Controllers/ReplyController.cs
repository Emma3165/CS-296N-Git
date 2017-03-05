using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eugene.Repositories;
using Eugene.Models;
using Eugene.Models.ViewModel;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Eugene.Controllers
{
    public class ReplyController : Controller
    {
        private IMessageRepository messageRepo;

        public ReplyController(IMessageRepository repo)
        {
            messageRepo = repo;
        }

       

        [HttpGet]
        public IActionResult ReplyForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ReplyForm(ReplyViewModel reply)
        {
            Message message = (from m in messageRepo.GetAllMessages()
                where m.MessageID == reply.MessageID
                select m).FirstOrDefault();
            message.Replies.Add(reply.MessageReply);
            messageRepo.Update(message);
            return RedirectToAction("List", "Message");
        }
    }
}

