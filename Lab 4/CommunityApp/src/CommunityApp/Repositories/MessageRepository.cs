using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityApp.Models;

namespace CommunityApp.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        public List<Message> GetMessageByTopic(string topic)
        {
            List<Message> messages = new List<Message>();
            var Jane = new Member() { Name = "Jane Doe", Email = "jadoe@fake.com" };
            var John = new Member() { Name = "John Doe", Email = "jdoe@fake.com" };

            messages.Add(new Message()
            {
                Subject = "Fun",
                Date = new DateTime(2016, 12, 1),
                Body = "Coding is fun",
                From = John,
                Topic = "Fun and Games"
            });

            messages.Add(new Message()
            {
                Subject = "Games",
                Date = new DateTime(2016, 12, 1),
                Body = "Coding is a game",
                From = John,
                Topic = "Fun and Games"
            });

            messages.Add(new Message()
            {
                Subject = "War",
                Date = new DateTime(2016, 12, 1),
                Body = "Coding is war",
                From = Jane,
                Topic = "War Games"
            });

            var messagesByTopic = new List<Message>();

            foreach (var m in messages)
            {
                if (m.Topic == topic)
                    messagesByTopic.Add(m);
            }
            return messagesByTopic;



            
        }

        public List<Message> GetMessagesByMember(Member member)
        {
            List<Message> messages = new List<Message>();
            var Jane = new Member() { Name = "Jane Doe", Email = "jadoe@fake.com" };
            var John = new Member() { Name = "John Doe", Email = "jdoe@fake.com" };

            messages.Add(new Message()
            {
                Subject = "Fun",
                Date = new DateTime(2016, 12, 1),
                Body = "Coding is fun",
                From = John,
                Topic = "Fun and Games"
            });

            messages.Add(new Message()
            {
                Subject = "Games",
                Date = new DateTime(2016, 12, 1),
                Body = "Coding is a game",
                From = John,
                Topic = "Fun and Games"
            });

            messages.Add(new Message()
            {
                Subject = "War",
                Date = new DateTime(2016, 12, 1),
                Body = "Coding is war",
                From = Jane,
                Topic = "War Games"
            });

            var messagesByMember = new List<Message>();

            foreach (var m in messages)
            {
                if (m.From == member)
                    messagesByMember.Add(m);
            }

            return messagesByMember;
        }
    }
}
