namespace LibraryManagement.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public int Copy_Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set;}
        public BookCopy BookCopy { get; set; }
        public User User { get; set; }

    }
}
