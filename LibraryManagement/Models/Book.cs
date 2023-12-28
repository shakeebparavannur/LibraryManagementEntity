using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Book
    {

        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Language {  get; set; }

        
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; }
        

    }
}
