using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using SportsStore.Models;

namespace SportsStore.Tests
{
    public class Class1
    {
        
        [Fact]
        public void GetProductId()
        {
            //Arrange
            var p = new Product();

            //Act
            p.Name = "New Balnace";
            p.Category = "Shoes";

            //Assert
            Assert.Equal("New Balnace", p.Name);
            Assert.NotEqual("Clothing", p.Category);

        }
        
    }
}
