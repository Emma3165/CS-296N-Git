using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eugene.Models;
using Eugene.Repositories;


namespace Eugene.Tests
{
    public class FakeMessageRopository : IMessageRepository
    {
        public IEnumerable<Message> Messages
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Message> GetAllMessages()
        {
            var messages = new List<Message>();
            Member memberPaul = new Member { Name = "Paul Jones" };
            Member memberSandra = new Member { Name = "Sandra Bullock" };
            Member memberSean = new Member { Name = "Sean Banks" };
            messages.Add(new Message() { Subject = "Meeting", Body = "City hall meeting", Date = new DateTime(2016, 11, 22), From = memberPaul, Topic = "Neigborhood watchdog" });
            messages.Add(new Message() { Subject = "Event", Body = "Fund raising for new school supply", Date = new DateTime(2016, 8, 16), From = memberSandra, Topic = "Fund raising" });
            messages.Add(new Message() { Subject = "Sale", Body = "Community art event for veteran housing", Date = new DateTime(2016, 10, 14), From = memberSean, Topic = "Art sale" });
            messages.Add(new Message() { Subject = "Sale", Body = "Community yard sale event for senior housing", Date = new DateTime(2016, 10, 21), From = memberSean, Topic = "Yard sale" });
            return messages;
        }

        public IEnumerable<Message> GetMessagesByMember(Member member)
        {
            var messages = new List<Message>();
            Member memberPaul = new Member() { Name = "Paul Anka", Email = "panka@gmail.com" };
            Member memberKelvin = new Member() { Name = "Kelivn Lawrence", Email = "klawrence@hotmail.com" };


            messages.Add(new Message() { Subject = "Meeting", Body = "City hall meeting", Date = new DateTime(2016, 11, 22), From = memberPaul, Topic = "Neigborhood watchdog" });
            messages.Add(new Message() { Subject = "Event", Body = "Fund raising for new school supply", Date = new DateTime(2016, 8, 16), From = memberKelvin, Topic = "Fund raising" });

            return messages;
        }

     


        IEnumerable<Message> IMessageRepository.GetMessagesBySubject()
        {
            var messages = new List<Message>();
            Member memberPaul = new Member() { Name = "Paul Anka", Email = "panka@gmail.com" };
            Member memberKelvin = new Member() { Name = "Kelivn Lawrence", Email = "klawrence@hotmail.com" };


            messages.Add(new Message() { Subject = "Meeting", Body = "City hall meeting", Date = new DateTime(2016, 11, 22), From = memberPaul, Topic = "Neigborhood watchdog" });
            messages.Add(new Message() { Subject = "Event", Body = "Fund raising for new school supply", Date = new DateTime(2016, 8, 16), From = memberKelvin, Topic = "Fund raising" });

            return messages;
        }
    }

}

