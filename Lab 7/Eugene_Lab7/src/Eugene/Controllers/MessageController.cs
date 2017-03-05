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
    public class MessageController : Controller
    {
        private IMessageRepository messageRepo;


        public MessageController(IMessageRepository repo)
        {
            messageRepo = repo;

        }
      
        public ViewResult List() => View(messageRepo.GetAllMessages().ToList());

        

        public ViewResult NewMessageForm() => View();
        public ViewResult ReplyForm() => View();

        [HttpPost]
        public IActionResult Add(string subject, string body,DateTime date, Member from, string topic)
        {
            var m = new Message();
            //ViewBag.m.Subject = subject;
            //ViewBag.m.Body = body;
            //ViewBag.m.Date = date;
            //ViewBag.m.From = from;
            //ViewBag.m.Topic = topic;
            messageRepo.Update(m);
            return RedirectToAction("List", "Message");
        }
        public ViewResult MessagesByFrom(Member from)
        {
           
            return View("List", messageRepo.GetAllMessages()
                .Where(m => m.From == from).ToList());
        }

       
        public ViewResult MessagesByTopic(string topic)
        {
 
            return View("List", messageRepo.GetAllMessages()
                .Where(m => m.Topic == topic).ToList());
        }

         public ViewResult MessagesByMember(Member member)
        {

            var messages = messageRepo.GetAllMessages();
            return View(messages);
        }


        //public ViewResult Index()
        //{

        //    return View("List", messageRepo.GetAllMessages().ToList());

        //}
    }
}
