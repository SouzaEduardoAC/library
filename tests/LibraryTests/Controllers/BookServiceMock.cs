using System;
using System.Collections.Generic;
using library.Domains.Books;
using System.Linq;

namespace LibraryTests.Controllers
{
    public class BookServiceMock : IBookService
    {
        private readonly List<Book> _books;
        public BookServiceMock() 
        {
            _books = new List<Book>()
            {
                new Book("Head First Agile", "Andrew Stellman, Jennifer Greene", DateTime.Parse("2017-09-10")),
                new Book("Head First Design Patterns", "Andrew Stellman, Jennifer Greene", DateTime.Parse("2016-11-10")), 
                new Book("Head First PMP", "Andrew Stellman, Jennifer Greene", DateTime.Parse("2018-09-10"))
            };
        }

        public Book Create(BookDTO bookDto)
        {
            var book = new Book(bookDto.Title, bookDto.Author, bookDto.ReleaseDate);
            _books.Add(book);
            return book;
        }

        public void Delete(Book book) => _books.Remove(book);

        public List<Book> GetAll() => _books;
        public Book GetById(Guid id) => _books.Find(b => b.ID == id);
        public void Update(Book book, BookDTO bookDTO)
        {
            var newBook = _books.Find(b => b.ID == book.ID);
            newBook.Update(bookDTO.Title, bookDTO.Author, bookDTO.ReleaseDate);
        }
    }
}