using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class BookCopy
    {
        [Key]
        public int CopyId { get; set; }
        public int BookId { get; set; }
        public bool IsAvailable { get; set; }

        public Book Book { get; set; }
    }
}
