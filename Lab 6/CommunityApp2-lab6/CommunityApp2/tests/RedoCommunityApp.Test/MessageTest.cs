using RedoCommunityApp.Controllers;
using RedoCommunityApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RedoCommunityApp.Test
{
    public class MessageTest
    {
        [Fact]

        public void CanGetMessages()
        {
            //Arrange
            FakeMessageRepository repo = new FakeMessageRepository();
            MessageController controller = new MessageController(repo);

            //Act
            List<Message> messages = controller.Index().ViewData.Model as List<Message>;

            //Assert
            Assert.Equal(repo.GetAllMessages()[0].From.Name, messages[0].From.Name);
            Assert.Equal(repo.GetAllMessages()[1].Date, messages[1].Date);
        }
        [Fact]
        public void CanGetMessageByMember()
        {
            //Arrange
            FakeMessageRepository repo = new FakeMessageRepository();
            MessageController controller = new MessageController(repo);

            Member John = new Member() { Name = "John Doe", Email = "jdoe@fake.com" };

            //Act
            List<Message> messages = controller.MessagesByMember(John).ViewData.Model 
                as List<Message>;
            //Act
            Assert.Equal(repo.GetMessagesByMember(John)[0].Body, messages[0].Body);

        }
    }
}
