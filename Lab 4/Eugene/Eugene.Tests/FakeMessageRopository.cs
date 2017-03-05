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
        public List<Message> GetMessagesBySubject()
        {
            var messages = new List<Message>();
            messages.Add(new Message() { Subject = "Meeting", Body = "City hall meeting", Date = new DateTime(2016, 11, 22), From = "Paul Jones", Topic = "Neigborhood watchdog" });
            messages.Add(new Message() { Subject = "Event", Body = "Fund raising for new school supply", Date = new DateTime(2016,8, 16), From = "Sandra Bullock", Topic = "Fund raising" });
            messages.Add(new Message() { Subject = "Sale", Body = "Community art event for veteran housing", Date = new DateTime(2016, 10, 14), From = "Sean Banks", Topic = "Art sale" });
            messages.Add(new Message() { Subject = "Sale", Body = "Community yard sale event for senior housing", Date = new DateTime(2016, 10, 21), From = "Sean Banks", Topic = "Yard sale" });
            return messages;
        }

        public List<Message> GetMessagesByTopic()
        {
            var messages = new List<Message>();
            messages.Add(new Message() { Subject = "Meeting", Body = "City hall meeting", Date = new DateTime(2016, 11, 22), From = "Paul Jones", Topic = "Neigborhood watchdog" });
            messages.Add(new Message() { Subject = "Event", Body = "Fund raising for new school supply", Date = new DateTime(2016, 8, 16), From = "Sandra Bullock", Topic = "Fund raising" });
            messages.Add(new Message() { Subject = "Sale", Body = "Community art event for veteran housing", Date = new DateTime(2016, 10, 14), From = "Sean Banks", Topic = "Art sale" });
            messages.Add(new Message() { Subject = "Sale", Body = "Community yard sale event for senior housing", Date = new DateTime(2016, 10, 21), From = "Sean Banks", Topic = "Yard sale" });
            return messages;
        }
    }
}
