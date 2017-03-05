using RedoCommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedoCommunityApp.Repositories
{
   public interface IMessageRepository
    {
        List<Message> GetMessagesByMember(Member member);
        List<Message> GetAllMessages();
    }
}
