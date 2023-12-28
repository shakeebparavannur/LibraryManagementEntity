namespace LibraryManagement.Models.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Language { get; set; }
    }
}
