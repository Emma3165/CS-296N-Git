using RedoCommunityApp.Controllers;
using RedoCommunityApp.Models;
using System.Collections.Generic;
using Xunit;

namespace RedoCommunityApp.Test
{
    public class MemberTests
    {

        [Fact]
        public void CanGetMembers()
        {
            //Arrange
            FakeMemberRepository repo = new FakeMemberRepository();
            MemberController controller = new MemberController(repo);

            //Act
            List<Member> members = controller.Index().ViewData.Model as List<Member>;

            //Assert
            Assert.Equal(repo.GetAllMembers()[0].Name, members[0].Name);
            Assert.Equal(repo.GetAllMembers()[0].Email, members[0].Email);
            Assert.Equal(repo.GetAllMembers()[1].Name, members[1].Name);
            Assert.Equal(repo.GetAllMembers()[1].Email, members[1].Email);

        }

        [Fact]
        public void CanGetMemberByEmail()
        {
            //Arrange
            FakeMemberRepository repo = new FakeMemberRepository();
            MemberController controller = new MemberController(repo);
            string testEmail = "jdoe@fake.com";

            //Act
            Member member = controller.MemberByEmail(testEmail).ViewData.Model as Member;

            //Assert
            Assert.Equal(repo.GetMemberByEmail(testEmail).Email, member.Email);
            Assert.Equal(repo.GetMemberByEmail(testEmail).Name, member.Name);


        }
    }
}
