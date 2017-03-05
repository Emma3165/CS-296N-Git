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
    public class ReplyController : Controller
    {
        private IMessageRepository messageRepo;

        public ReplyController(IMessageRepository repo)
        {
            messageRepo = repo;
        }
        // GET: /<controller>/
        [HttpGet]
        public ViewResult ReplyForm( int id)
        {
            var replyVm = new ReplyViewModel();
            replyVm.MessageID = id;
            replyVm.MessageReply = new Reply();
            

            return View(replyVm);
        }
        [HttpPost]
       // public IActionResult ReplyForm(int id,  string body)
         public IActionResult ReplyForm(ReplyViewModel reply)   
        {
           
            Message message = (from m in messageRepo.GetAllMessages()
                         where m.MessageID == reply.MessageID
                         select m).FirstOrDefault<Message>();

           
            message.Replies.Add(reply.MessageReply);
            messageRepo.Update(message);

            return RedirectToAction("Index", "Message");
        }
    }
}
