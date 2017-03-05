using Xunit;
using CommunityApp.Models;
using System;
namespace CommunityAPP.Test
{
    public class NewsTest
    {
       [Fact]
        public void CanCreateNewsTitle()
        {
            //Arrange
            var n = new News();


            //Act
            n.Title = "Yee haw";

            //Assert
            Assert.True(n.Title == "Yee haw");


        }
        [Fact]
        public void CanCreateNewsDate()
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

    }
}
