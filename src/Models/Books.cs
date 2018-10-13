using System;

namespace library.Models
{
    public class Books
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string Author { get; set; }
    }
}