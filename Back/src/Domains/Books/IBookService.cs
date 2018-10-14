using System;
using System.Collections.Generic;

namespace library.Domains.Books
{
    public interface IBookService
    {
        List<Book> GetAll();
        Book GetById(Guid id);
        Book Create(BookDTO bookDto);
        void Update(Book book, BookDTO bookDTO);
        void Delete(Book id);
    }
}