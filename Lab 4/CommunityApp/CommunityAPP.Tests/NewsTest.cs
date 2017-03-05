using Xunit;
using CommunityApp.Models;
using System;

namespace CommunityAPP.Test
{
    public class NewsTest
    {
        [Fact]
        public void TestTitleGetter()
        {
            //Arrange
            var n = new News();


            //Act
            n.Title = "Yee haw";

            //Assert
            Assert.Equal("Yee haw", n.Title);


        }
        [Fact]
        public void TestNewsDateConstructor()
        {
            //Arrange
            var n = new News();


            //Act
            n.Date = new DateTime(2017, 1, 17);


            //Assert
            Assert.True(n.Date.Day == 17 &&
                n.Date.Year == 2017
                && n.Date.Month == 1);


        }

        [Fact]
        public void TestNewsStoryGetter()
        {
            //Arrange
            var n = new News();
            
            //Act
            n.Story = "This is a test";

            //Assert
            Assert.Equal("This is a test", n.Story );

        }

        [Fact]
        public void TestNewsStorySetter()
        {
            //Arrange
            var n = new News();

            //Act
            n.Story = "This is a test";
            n.Story = "This is a test 2";

            //Assert
            Assert.NotEqual("This is a test", n.Story);
            Assert.Equal("This is a test 2", n.Story);

        }

    }
}
