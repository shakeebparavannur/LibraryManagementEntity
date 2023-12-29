using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;

namespace LibraryManagement.Repository
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooks();
        Task<Book> GetBookById(int id);
        Task<IEnumerable<BookDto>> GetBookByName(string name);
        Task<Book> UpdateBook(int id,BookDto book);
        Task<bool> DeleteBook(int id);
        Task<BookDto> AddNewBook (BookDto book);
    }
}
