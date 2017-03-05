using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedoCommunityApp.Models;
using Microsoft.EntityFrameworkCore;

namespace RedoCommunityApp.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDBContext context;

        public MessageRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }
        public IEnumerable<Message> GetAllMessages()
        {
            return context.Messages.Include(m=> m.From);
        }

        public List<Message> GetMessagesByMember(Member member)
        {
            return (from m in context.Messages
                    where m.From == member
                    select m).ToList();
        }

        public int Update(Message message)
        {
            context.Messages.Update(message);
            return context.SaveChanges();
        }

        public int Add(Message message)
        {
            context.Messages.Add(message);
            return context.SaveChanges();
        }
    }
}
