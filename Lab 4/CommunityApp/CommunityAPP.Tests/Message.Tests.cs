using CommunityApp.Controllers;
using CommunityApp.Models;
using CommunityApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CommunityAPP.Tests
{
    public class MessageTests
    {
     

        [Fact]
        public void GetMessagesByMember()
        {
            //Arrange
            MessageRepository repository = new MessageRepository();
            MessageController controller = new MessageController(repository);
            FakeMemberRepository mem = new FakeMemberRepository();
            Member John = mem.GetMemberByEmail("jdoe@fake.com");


            //Act
            List<Message> messages = controller.MessagesByMember(John)
                .ViewData.Model as List<Message>;

            //Assert
            Assert.Equal(repository.GetMessagesByMember(John)[0].Topic, messages[0].Topic );

        

        }
    }
}
