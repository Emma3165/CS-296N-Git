using CommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityApp.Repositories
{
   public interface IMessageRepository
    {
        List<Message> GetMessagesByMember(Member member);
        List<Message> GetMessageByTopic(string Topic);
    }
}
