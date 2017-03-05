using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eugene.Models;
using Xunit;
using Eugene.Controllers;



namespace Eugene.Tests
{
    public class NewsTests
    {
        [Fact]
        public void CanChangeAuthorName()
        {
            //Arrange
            var n = new News { Title = "Snow storm", PublishedDate = new DateTime(2017, 1, 5), Author = "James Smith" };

            //Act
            n.Author = "William Garfield";

            //Assert
            Assert.Equal("William Garfield", n.Author);
            Assert.False( n.Author == "James Smith");
        }

        [Fact]
        public void CanAddAuthor()
        {
            // Arrange
            var n = new News();

            //Act
            n.Author = "Martin Beckett";

            //Assert
            Assert.False(n.Author == "James Brown");
        }
    

        [Fact]
        public void CanChangeTitle()
        {
            //Arrange
            var n = new News { Title = "Snow storm", PublishedDate = new DateTime(2017, 1, 5), Author = "James Smith" };

            //Act
            n.Title = "Flooding";

            //Assert
            Assert.Equal("Flooding", n.Title);
            Assert.False(n.Title == "Snow storm");
        }

        [Fact]
        public void TestSetter()
        {
            //Arrange
            var n = new News(); 

            //Act
            n.Story = "Oscar nominee";
            n.Author = "Joan Leffler";

            //Assert
            Assert.Equal("Oscar nominee", n.Story);
            Assert.NotEqual("Samantha Fox", n.Author);
        }

        [Fact]
        public void DoesGetMembers()
        {
            //Arrange
            FakeMemberRepository repository = new FakeMemberRepository();
            MemberController controller = new MemberController(repository);

            //Act
            List<Member> members = controller.Index().ViewData.Model as List<Member>;

            //Assert
            Assert.Equal(repository.GetAllMemberAlphabetic()[0].Name, members[0].Name);
            Assert.Equal(repository.GetAllMemberAlphabetic()[0].Email, members[0].Email);
            Assert.Equal(repository.GetAllMemberAlphabetic()[1].Name, members[1].Name);
            Assert.Equal(repository.GetAllMemberAlphabetic()[1].Email, members[1].Email);
        }

        [Fact]
        public void CanChangeMemberEmail()
        {
            //Arrange
            var m = new Member { Name = "BryantAdams", Email = "bdams@hotmil.com"};

            //Act
            m.Email = "brtadams@gmail.com";

            //Assert
            Assert.Equal("brtadams@gmail.com" , m.Email);
            Assert.False("Bryant Adams"== m.Email);
        }

        [Fact]
        public void CanGetMessagesBySubject()
        {
            ////Arrange
            //FakeMessageRopository repository = new FakeMessageRopository();
            //MessageController controller = new MessageController(repository);

            ////Act
            //List<Message> messages = controller.Index().ViewData.Model as List<Message>;

            ////Assert
            //Assert.Equal(repository.GetMessagesBySubject()[0].Subject, messages[0].Subject);
            //Assert.True("Meeting" == messages[0].Subject);
            //Assert.False("Event" == messages[2].Subject);
        }

        //[Fact]
        //public void CanGetMessageByTopic()
        //{
        //    //Arrange
        //    FakeMessageRopository repository = new FakeMessageRopository();
        //    MessageController controller = new MessageController(repository);

        //    //Act
        //    List<Message> messages = controller.Index().ViewData.Model as List<Message>;

        //    //Assert
        //    Assert.Equal(repository.GetMessagesBySubject()[0].Topic, messages[0].Topic);
        //    Assert.True("Neigborhood watchdog" == messages[0].Topic);
        //    Assert.False("Yard sale" == messages[2].Topic);

        //}
    }
}
