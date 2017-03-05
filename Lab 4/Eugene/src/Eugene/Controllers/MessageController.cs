using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Eugene.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Eugene.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRepository repository;

      

        public MessageController(IMessageRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Messages);

       

        [HttpGet]
        public ViewResult Index()
        {
            var repo = new MessageRepository();
            var messages = repo.GetMessagesBySubject();
            return View(messages);

        }
    }
}
