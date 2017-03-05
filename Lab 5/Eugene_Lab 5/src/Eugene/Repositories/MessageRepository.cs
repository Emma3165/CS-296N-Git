using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eugene.Repositories;
using Microsoft.EntityFrameworkCore;
using Eugene.Models;


namespace Eugene.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;
        public MessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Message> Messages => context.Messages;

        public IEnumerable<Message> GetAllMessages()
        {
            return context.Messages.Include(m => m.From);
        }

        public IEnumerable<Message> GetMessagesByMember(Member member)
        {
            return (from m in context.Messages
                    where m.From == member
                    select m).ToList();

        }
        public IEnumerable<Message> GetMessagesBySubject()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessagesBySubject(string subject)
        {
            //var messages = new List<Message>();
            //messages.Add(new Message() { Subject = "Meeting", Body = "City hall meeting", Date = new DateTime(2016, 11, 22), From = "Paul Jones", Topic = "Neigborhood watchdog" });
            //messages.Add(new Message() { Subject = "Event", Body = "Fund raising for new school supply", Date = new DateTime(2016, 8, 16), From = "Sandra Bullock", Topic = "Fund raising" });
            //messages.Add(new Message() { Subject = "Sale", Body = "Community art event for veteran housing", Date = new DateTime(2016, 10, 14), From = "Sean Banks", Topic = "Art sale" });
            //messages.Add(new Message() { Subject = "Sale", Body = "Community yard sale event for senior housing", Date = new DateTime(2016, 10, 21), From = "Sean Banks", Topic = "Yard sale" });
            return context.Messages.Where(m => m.Subject == subject);
        }

        public List<Message> GetMessagesByTopic()
        {
            throw new NotImplementedException();
        }
    }
    
}
