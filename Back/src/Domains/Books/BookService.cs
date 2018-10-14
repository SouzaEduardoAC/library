using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace library.Domains.Books
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;

        private readonly BookContext _context;

        public BookService(ILogger<BookService> logger, BookContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Book GetById(Guid id) => _context.Books.Find(id);

        public List<Book> GetAll() => _context.Books.ToList();

        public Book Create(BookDTO bookDTO)
        {
            var book = new Book(bookDTO.Title, bookDTO.Author, bookDTO.ReleaseDate);
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Update(Book book, BookDTO bookDTO)
        {
            book.Update(bookDTO.Title, bookDTO.Author, bookDTO.ReleaseDate);
            _context.Books.Update(book);
            _context.SaveChanges();
        }
        
        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
            _logger.LogInformation($"Deleted a book with id = {book.ID}");
        }
    }
}