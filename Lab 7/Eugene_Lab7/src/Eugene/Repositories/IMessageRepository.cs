using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eugene.Repositories;
using Eugene.Models;

namespace Eugene.Repositories
{
    public interface IMessageRepository
    {

        IEnumerable<Message> GetAllMessages();
        IEnumerable<Message> GetMessagesByMember(Member member);
        IEnumerable<Message> Messages { get; }

        IEnumerable<Message> GetMessagesBySubject();
       
        int Update(Message message);
    }
}
