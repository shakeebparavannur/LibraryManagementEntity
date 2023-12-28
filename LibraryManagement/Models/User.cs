using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class User
    {

        public Guid UserId { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email {  get; set; }
        public string Password { get; set; }
        public bool IsActived { get; set; }
        public int BooksInHand { get; set; }

        public ICollection<Borrowing> Borrowings { get; set; }

    }
}
