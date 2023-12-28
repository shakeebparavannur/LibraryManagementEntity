using AutoMapper;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repository
{
    public class BookService : IBookService
    {
        private readonly LIbraryDbContext context;
        private IMapper mapper;
        public BookService(LIbraryDbContext dbContext,IMapper mapper)
        {
            context = dbContext;
            this.mapper = mapper;
        }

        public async Task<BookDto> AddNewBook(BookDto book)
        {
            var book1 = mapper.Map<Book>(book);
             await context.Books.AddAsync(book1);
            await context.SaveChangesAsync();
            return mapper.Map<BookDto>(book1);
        }

        public async Task<bool> DeleteBook(int id)
        {
            Book book = await context.Books.FirstOrDefaultAsync(x=>x.BookId == id);
            if (book == null)
            {
                return false;
            }
            context.Books.Remove(book);
            context.SaveChangesAsync();
            return true;

        }

        public async Task<Book> GetBookById(int id)
        {
            Book book = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
            if (book == null)
            {
                return null;
            }
            return book;
        }

        public async Task<IEnumerable<BookDto>> GetBookByName(string name)
        {
            IEnumerable<Book> books = await context.Books.Where(x=>x.Title.Contains(name)).ToListAsync();
            if (books == null)
            {
                return null;
            }
            return mapper.Map<List<BookDto>>(books);
        }

        public async Task<IEnumerable<BookDto>> GetBooks()
        {
           IEnumerable<Book> books = await context.Books.ToListAsync();
            IEnumerable<BookDto> booksList = mapper.Map<IEnumerable<BookDto>>(books);

            return booksList;
        }

        public async Task<Book> UpdateBook(Book book)
        {
            Book book1 = await context.Books.FirstOrDefaultAsync(x=>x.BookId==book.BookId);
            if (book1 != null)
            {
                context.Books.Update(book1);
                context.SaveChangesAsync();
                return book1;
            }
            return null;

            
        }
    }
}
