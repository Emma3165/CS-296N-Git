using BookInfo.Controllers;
using BookInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BookInfo.Tests
{
    public class AuthorTests
    {
        public AuthorTests()
        {
        }
        [Fact]
        // Test AuthorController getting a list of authors
        public void DoesGetAuthors()
        {
            //Arrange
            FakeAuthorRepository repository = new FakeAuthorRepository();
            HomeController controller = new HomeController(repository);

            //Act
            List<Author> authors = controller.Authors().ViewData.Model as List<Author>;

            //Assert
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[0].Name, authors[0].Name);
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[0].Birthday, authors[0].Birthday);
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[1].Name, authors[1].Name);
            Assert.Equal(repository.GetAllAuthorsAlphabetic()[1].Name, authors[1].Name);
        }
    }
}
