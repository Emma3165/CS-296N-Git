using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookInfo.Models;

namespace BookInfo.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> GetAllAuthorsAlphabetic()
        {
            //Tempory development implementation
            var authors = new List<Author>();
            authors.Add(new Author() { Name = "Jane Austen", Birthday = new DateTime(1765, 12, 16) });
            authors.Add(new Author() { Name = "William Shakespere", Birthday = new DateTime(1564, 4, 1) });
            return authors;

        }

        public List<Author> GetAuthorsByBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Author GetAuthorsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
