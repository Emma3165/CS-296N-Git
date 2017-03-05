using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eugene.Models;
using Eugene.Controllers;
using Xunit;

namespace Eugene.Tests
{
    public class MessageTest
    {

        [Fact]
        public void CanGetMessges()
        {
            //Arrange
            FakeMessageRopository repo = new FakeMessageRopository();
            MessageController controller = new MessageController(repo);

            //Act
            List<Message> messages = controller.List().ViewData.Model as List<Message>;

            //Assert
            Assert.Equal(repo.GetAllMessages().ToList()[1].Date, messages[1].Date);
            Assert.True(repo.GetAllMessages().ToList()[0].From.Name == "Paul Jones");

        }

        [Fact]
        public void CanGetMessgesByMember()
        {
            //Arrange
            FakeMessageRopository repo = new FakeMessageRopository();
            MessageController controller = new MessageController(repo);

            Member mbl = new Member() { Name = "Belinda Carlisle", Email = "bcarlisle@gmail.com" };

            //Act
            List<Message> messages = controller.MessagesByMember(mbl).ViewData.Model as List<Message>;

            //Assert
            Assert.Equal(repo.GetMessagesByMember(mbl).ToList()[0].Name, messages[0].Name);

        }

    }

}
