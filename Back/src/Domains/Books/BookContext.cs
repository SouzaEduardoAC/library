using Microsoft.EntityFrameworkCore;

namespace library.Domains.Books
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
    }
}