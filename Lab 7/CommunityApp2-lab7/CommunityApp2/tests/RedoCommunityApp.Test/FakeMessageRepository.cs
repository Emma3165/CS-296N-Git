using RedoCommunityApp.Models;
using RedoCommunityApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedoCommunityApp
{
    public class FakeMessageRepository : IMessageRepository
    {
        public List<Message> GetAllMessages()
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


            return messages;




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
                if (m.From.Name == member.Name
                    && m.From.Email == member.Email)
                    messagesByMember.Add(m);
            }

            return messagesByMember;
        }

        int IMessageRepository.Add(Message message)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Message> IMessageRepository.GetAllMessages()
        {
            throw new NotImplementedException();
        }

        List<Message> IMessageRepository.GetMessagesByMember(Member member)
        {
            throw new NotImplementedException();
        }

        int IMessageRepository.Update(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
