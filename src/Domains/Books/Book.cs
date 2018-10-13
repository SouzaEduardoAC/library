using System;
using System.ComponentModel.DataAnnotations;

namespace library.Domains.Books
{
    public sealed class Book
    {
        private Book() 
        {
        }
        
        public Book(string title, string author, DateTime releaseDate)
        {
            this.ID = Guid.NewGuid();
            this.EntryDate = DateTime.Now;
            this.Title = title;
            this.Author = author;
            this.ReleaseDate = releaseDate;
        }

        [Key]
        public Guid ID { get; private set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Title { get; private set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; private set; }
        
        [Required]
        public DateTime EntryDate { get; private set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z\s',]*$")]
        public string Author { get; private set; }

        public void Update(string title, string author, DateTime releaseDate)
        {
            this.Title = title;
            this.Author = author;
            this.ReleaseDate = releaseDate;
        }
    }
}
